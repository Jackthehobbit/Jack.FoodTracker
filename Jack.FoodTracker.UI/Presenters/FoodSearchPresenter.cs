using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Jack.FoodTracker
{
    class FoodSearchPresenter
    {
        private readonly IFoodSearchView FoodSearchView;
        private readonly FoodTracker FoodTracker;
        private readonly FoodLookupPresenter FoodLookupPresenter;
        public FoodSearchPresenter(IFoodSearchView foodSearchView, FoodTracker foodTracker, FoodLookupPresenter foodLookupPresenter)
        {
            FoodSearchView = foodSearchView;
            FoodTracker = foodTracker;
            FoodLookupPresenter = foodLookupPresenter;

            FoodSearchView.SearchBarTextChanged += new EventHandler(ClearSearchResults);
            FoodSearchView.SearchEntered += new KeyPressEventHandler(SearchHandler);
        }

        public void ClearSearchResults(object sender, EventArgs e)
        {
            if (FoodSearchView.SearchText == "")
            {
                FoodLookupPresenter.SearchResults = null;
                FoodLookupPresenter.UpdateCategories();
            }
        }

        public void SearchHandler(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                FoodLookupPresenter.SearchResults = null;
                GetSearchResults();
            }
        }

        private IList<FoodCategory> GetNonEmptyFoodCategories(IList<Food> foods)
        {
            IList<FoodCategory> fCatList = FoodTracker.GetNonEmptyFoodCategories(true);
            IList<FoodCategory> fCatListResult = new List<FoodCategory>(fCatList);

            foreach (FoodCategory item in fCatList)
            {
                Food findCat = foods.Where(x => x.Category.Id.Equals(item.Id)).FirstOrDefault();

                if (findCat == null)
                {
                    fCatListResult.Remove(item);
                }
            }

            return fCatListResult;
        }


        public void GetSearchResults()
        {
            String searchText = FoodSearchView.SearchText;
            if (searchText.Trim() != "")
            {
                IList<Food> searchResults = new List<Food>();

                searchResults = FoodTracker.GetAllFood();

                String[] searchstrings = searchText.Split(new char[] { ' ' });

                foreach (string s in searchstrings)
                {
                    String key;
                    String exp;
                    String val;

                    SearchService SearchService = new SearchService();

                    if (s.Contains("=") || s.Contains(">") || s.Contains("<"))
                    {
                        SearchService.ConvertComparison(s, out key, out exp, out val);
                    }
                    else
                    {
                        key = "name";
                        exp = "=";
                        val = s;
                    }

                    searchResults = SearchForFood(SearchService, searchResults, key, exp, val);
                }

                IList<FoodCategory> finalCatList = GetNonEmptyFoodCategories(searchResults);

                FoodLookupPresenter.SetCatList(finalCatList);
                FoodLookupPresenter.SetFoodList(searchResults);
            }
        }

        public IList<Food> SearchForFood(SearchService SearchService, IList<Food> searchResults, String Key, String Exp, String Value)
        {
            int numericValue;
            double dNumericValue;
            if (searchResults == null)
            {
                throw new ArgumentException("Error during search please try again");
            }

            if (Key == "" || Value == "" || Exp == "")
            {
                return searchResults;
            }

            Key = Key.ToLower();

            switch (Key.Trim())
            {
                case "name":
                    return SearchService.ApplySearchContains<Food>(searchResults, "Name", Exp, Value, true);
                case "desc":
                case "description":
                    return SearchService.ApplySearchContains<Food>(searchResults, "Description", Exp, Value, true);
                case "category":
                case "cat":
                    FoodCategory cat = FoodTracker.GetAllFoodCategories(true).Where(x => x.Name.ToLower() == Value).FirstOrDefault();

                    return SearchService.ApplySearchEquals<Food>(searchResults, "Category", Exp, cat);
                case "cal":
                case "calories":
                    if (!Int32.TryParse(Value, out numericValue))
                    {
                        throw new ArgumentException("Calories has to be a number in order to search");
                    }
                    else
                    {
                        return SearchService.ApplySearchNumerical<Food>(searchResults, "Calories", Exp, numericValue);
                    }
                case "sugar":
                case "sugars":
                    if (!Double.TryParse(Value, out dNumericValue))
                    {
                        throw new ArgumentException("Sugar has to be a number in order to search");
                    }
                    else
                    {
                        return SearchService.ApplySearchNumerical<Food>(searchResults, "Sugars", Exp, dNumericValue);
                    }
                case "fat":
                case "fats":
                    if (!double.TryParse(Value, out dNumericValue))
                    {
                        throw new ArgumentException("Fat has to be a number in order to search");
                    }
                    else
                    {
                        return SearchService.ApplySearchNumerical<Food>(searchResults, "Fat", Exp, dNumericValue);
                    }
                case "satfat":
                case "satfats":
                case "saturates":
                    if (!double.TryParse(Value, out dNumericValue))
                    {
                        throw new ArgumentException("Saturates has to be a number in order to search");
                    }
                    else
                    {
                        return SearchService.ApplySearchNumerical<Food>(searchResults, "Saturates", Exp, dNumericValue);
                    }
                case "salt":
                    if (!double.TryParse(Value, out dNumericValue))
                    {
                        throw new ArgumentException("Salt has to be a number in order to search");
                    }
                    else
                    {
                        return SearchService.ApplySearchNumerical<Food>(searchResults, "Salt", Exp, dNumericValue);
                    }
                default:
                    throw new ArgumentException(Key.Trim() + "is not a valid search key");
            }
        }

        public bool ViewEnabled
        {
            get { return FoodSearchView.Enabled; }
            set { FoodSearchView.Enabled = value; }
        }
    }
}



