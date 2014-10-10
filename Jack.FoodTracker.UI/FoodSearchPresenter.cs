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
        private readonly FoodLookupView FoodLookupView;

        public FoodSearchPresenter(IFoodSearchView foodSearchView, FoodTracker foodTracker, FoodLookupView foodLookupView)
        {
            FoodSearchView = foodSearchView;
            FoodTracker = foodTracker;
            FoodLookupView = foodLookupView;

            FoodSearchView.SearchBarTextChanged += new EventHandler(GetSearchResults);
        }

        public void GetSearchResults(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = FoodTracker.GetAllFoodCategories(true);

            if(FoodSearchView.SearchText == "")
            {
                FoodLookupView.SetCatList(fCatList);
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

                FoodLookupView.SetCatList(finalCatList);
                FoodLookupView.SetFoodList(searchResults);
            }
        }
    }
}
