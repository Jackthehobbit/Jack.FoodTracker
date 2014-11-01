using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            FoodSearchView.SearchBarTextChanged += new EventHandler(GetSearchResults);
        }

        public void GetSearchResults(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = FoodTracker.GetAllFoodCategories(true);

            if (FoodSearchView.SearchText == "")
            {
                FoodLookupPresenter.SetCatList(fCatList);
            }
            else
            {
                if (FoodSearchView.SearchText.Contains(";"))
                {
                    String[] splitString;
                    String[] splitString2;
                    string name;
                    string desc;
                    string calories;
                    string caloriesSearchType;
                    
                    String[] searchstrings = FoodSearchView.SearchText.ToLower().Split(new char[] { ';' });
                    foreach (string s in searchstrings)
                    {
                       if(s.Contains("name"))
                       {
                           splitString = s.Split(new char[]{'='});
                           name = splitString[1]; 
                           splitString = null;
                       }
                       if(s.Contains("desc"))
                       {
                           splitString = s.Split(new char[]{'='});
                           desc = splitString[1];
                           splitString=null;
                       }
                       if(s.Contains("calories"))
                       {
                           splitString = s.Split(new char[] { '=' });
                           calories = splitString[1];
                           splitString2 = splitString[0].Split(new char[]{'s'});
                           caloriesSearchType = splitString2[1];
                       }
                    }
                }
                    
                 else
                 {
                        IList<Food> searchResults = FoodTracker.SearchFoodByName(FoodSearchView.SearchText);
                        IList<FoodCategory> finalCatList = new List<FoodCategory>(fCatList);

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
               }
            }
        }
    }

