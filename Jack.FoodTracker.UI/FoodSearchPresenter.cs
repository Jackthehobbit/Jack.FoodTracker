using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Jack.FoodTracker
{
    class FoodSearchPresenter
    {
        private readonly IFoodSearchView FoodSearchView;
        private readonly FoodTracker FoodTracker;
        private readonly FoodLookupPresenter FoodLookupPresenter;
        private readonly Regex keyVal = new Regex("(.*?)(<=|>=|=>|=<|!=|=|<|>)(.*)");

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
                IList<FoodCategory> fCatList = FoodTracker.GetAllFoodCategories(true);
                FoodLookupPresenter.SetCatList(fCatList);
            }                      
        }

        public void SearchHandler(object sender, KeyPressEventArgs e)
       {
            if(e.KeyChar == (char)13)
            {
                GetSearchResults();
            }
        } 

        public void GetSearchResults()
        {
          String searchText = FoodSearchView.SearchText.ToLower();
          IList<Food> searchResults = FoodTracker.GetAllFood();
          IList<FoodCategory> fCatList = FoodTracker.GetAllFoodCategories(true);
          IList<FoodCategory> finalCatList = new List<FoodCategory>(fCatList);

          if (searchText.Contains("=") | searchText.Contains(">")|searchText.Contains("<"))
          {
              
              String key;
              String exp;
              String val;

              
                  String[] searchstrings = searchText.Split(new char[] { ';' });
                  foreach (string s in searchstrings)
                  {
                      convertKeyValue(s, out key, out exp, out val);
                      searchResults = SearchForFood(searchResults, key, exp, val);
                  }
              
   
           }
           else
           {
           searchResults = FoodTracker.SearchFoodByName(FoodSearchView.SearchText);
           }

         
          foreach (FoodCategory item in fCatList)
          {
              Food findCat = searchResults.Where(x => x.Category.Id.Equals(item.Id)).FirstOrDefault();

              if (findCat == null)
              {
                  finalCatList.Remove(item);
              }
          }
          FoodLookupPresenter.SetCatList(finalCatList);
          FoodLookupPresenter.SetFoodList(searchResults);
         
        }

        private void convertKeyValue(String searchText, out String key, out String exp, out String val)
        {

            Match matches = keyVal.Match(searchText);
            key = matches.Groups[1].Value;
            exp = matches.Groups[2].Value;
            val = matches.Groups[3].Value;
            if (key == null || exp == null || val == null)
            {
                throw new ArgumentException("Error when searching");
            }
        }
        public IList<Food> SearchForFood(IList<Food> searchResults, String Key, String Exp, String Value)
        {
            int numericValue;
            double dNumericValue;
            if (searchResults == null)
            {
                throw new ArgumentException("Error during search please try again");
            }

            if (Key == "" || Value == ""|| Exp == "")
            {
                return searchResults;
            }
            switch (Key.Trim())
            {
                case "name":
                    if (Exp =="!=")
                    {
                        return searchResults.Where(x => x.Name.ToLower() != Value.Trim()).ToList();
                    }
                    else
                    {
                        return searchResults.Where(x => x.Name.ToLower() == Value.Trim()).ToList();
                    }
                case "desc":
                case "description":
                    if (Exp == "!=")
                    {
                        return searchResults.Where(x => !x.Description.ToLower().Contains(Value.Trim())).ToList();
                    }
                    else
                    {
                        return searchResults.Where(x => x.Description.ToLower().Contains(Value.Trim())).ToList();
                    }
                case "category":
                case "cat":
                    if (Exp == "!=")
                    {
                        return searchResults.Where(x => x.Category.Name.ToLower() != Value.Trim()).ToList();
                    }
                    else
                    {
                        return searchResults.Where(x => x.Category.Name.ToLower() == Value.Trim()).ToList();
                    }
                case "cal":
                case "calories":
                    if (!Int32.TryParse(Value,out numericValue))
                    {
                        throw new ArgumentException("Calories has to be a number in order to search");
                    }
                    else
                    {
                        switch (Exp)
                        {
                        case "=":
                            return searchResults.Where(x => x.Calories == numericValue).ToList();
                        case ">":
                            return searchResults.Where(x=> x.Calories > numericValue).ToList();
                        case "<":
                            return searchResults.Where(x=> x.Calories < numericValue).ToList();
                        case "<=":
                        case "=<":
                            return searchResults.Where(x=> x.Calories <= numericValue).ToList();
                        case ">=":
                        case "=>":
                            return searchResults.Where(x=> x.Calories >= numericValue).ToList();
                        case "!=":
                            return searchResults.Where(x=> x.Calories != numericValue).ToList();
                        default:
                            throw new ArgumentException(Exp + "is not a valid search expression for calories");
                        }
                    }
                case "sugar":
                case "sugars":
                    if (!Int32.TryParse(Value,out numericValue))
                    {
                        throw new ArgumentException("Sugar has to be a number in order to search");
                    }
                    else
                    {
                        switch (Exp)
                        {
                        case "=":
                            return searchResults.Where(x=> x.Sugars == numericValue).ToList();
                        case ">":
                            return searchResults.Where(x=> x.Sugars > numericValue).ToList();
                        case "<":
                            return searchResults.Where(x=> x.Sugars < numericValue).ToList();
                        case "<=":
                        case "=<":
                            return searchResults.Where(x=> x.Sugars <= numericValue).ToList();
                        case ">=":
                        case "=>":
                            return searchResults.Where(x=> x.Sugars >= numericValue).ToList();
                        case "!=":
                            return searchResults.Where(x=> x.Sugars != numericValue).ToList();
                        default:
                            throw new ArgumentException(Exp + "is not a valid search expression for sugar");
                        }
                    }
                case "fat":
                case "fats":
                    if (!double.TryParse(Value,out dNumericValue))
                    {
                        throw new ArgumentException("Fat has to be a number in order to search");
                    }
                    else
                    {
                        switch (Exp)
                        {
                        case "=":
                            return searchResults.Where(x => x.Fat == dNumericValue).ToList();
                        case ">":
                            return searchResults.Where(x => x.Fat > dNumericValue).ToList();
                        case "<":
                            return searchResults.Where(x => x.Fat < dNumericValue).ToList();
                        case "<=":
                        case "=<":
                            return searchResults.Where(x => x.Fat <= dNumericValue).ToList();
                        case ">=":
                        case "=>":
                            return searchResults.Where(x => x.Fat >= dNumericValue).ToList();
                        case "!=":
                            return searchResults.Where(x => x.Fat != dNumericValue).ToList();
                        default:
                            throw new ArgumentException(Exp + "is not a valid search expression for fat");
                        }
                    }
                case "satfat":
                case "satfats":
                case "saturates":
                    if (!double.TryParse(Value,out dNumericValue))
                    {
                        throw new ArgumentException("Saturates has to be a number in order to search");
                    }
                    else
                    {
                        switch (Exp)
                        {
                        case "=":
                            return searchResults.Where(x => x.Saturates == dNumericValue).ToList();
                        case ">":
                            return searchResults.Where(x => x.Saturates > dNumericValue).ToList();
                        case "<":
                            return searchResults.Where(x => x.Saturates < dNumericValue).ToList();
                        case "<=":
                        case "=<":
                            return searchResults.Where(x => x.Saturates <= dNumericValue).ToList();
                        case ">=":
                        case "=>":
                            return searchResults.Where(x => x.Saturates >= dNumericValue).ToList();
                        case "!=":
                            return searchResults.Where(x => x.Saturates != dNumericValue).ToList();
                        default:
                            throw new ArgumentException(Exp + "is not a valid search expression for saturates");
                        }
                    }
                case "salt":
                    if (!double.TryParse(Value,out dNumericValue))
                    {
                        throw new ArgumentException("Salt has to be a number in order to search");
                    }
                    else
                    {
                        switch (Exp)
                        {
                        case "=":
                            return searchResults.Where(x => x.Salt == dNumericValue).ToList();
                        case ">":
                            return searchResults.Where(x => x.Salt > dNumericValue).ToList();
                        case "<":
                            return searchResults.Where(x => x.Salt < dNumericValue).ToList();
                        case "<=":
                        case "=<":
                            return searchResults.Where(x => x.Salt <= dNumericValue).ToList();
                        case ">=":
                        case "=>":
                            return searchResults.Where(x => x.Salt >= dNumericValue).ToList();
                        case "!=":
                            return searchResults.Where(x => x.Salt != dNumericValue).ToList();
                        default:
                            throw new ArgumentException(Exp + "is not a valid search expression for Salt");
                        }
                    }
                default:
                    throw new ArgumentException(Key.Trim()+"is not a valid search key");
              }
                    

            }

    }
}



