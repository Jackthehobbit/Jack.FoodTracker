using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    class FoodLookupPresenter
    {
        private readonly IFoodLookupView FoodLookupView;
        private readonly FoodTracker FoodTracker;
        public FoodLookupPresenter(IFoodLookupView foodLookupView, FoodTracker foodTracker, IList<FoodCategory> foodCategories)
        {
            FoodLookupView = foodLookupView;
            FoodTracker = foodTracker;

            FoodLookupView.CategorySelectedChanged += new EventHandler(OnCategoriesSelectedIndexChanged);

            FoodLookupView.Categories = foodCategories;
        }

        private void OnCategoriesSelectedIndexChanged(object sender, EventArgs e)
        {
            if(FoodSearchPresenter.searchResults != null)
            {
                SetFoodList(FoodSearchPresenter.searchResults);
            }
            else
            {
                SetFoodList(0);
            }
            
        }

        public void SetFoodList()
        {
            FoodCategory selectedCategory = FoodLookupView.SelectedCategory;

            if (selectedCategory != null)
            {

                IList<Food> fList = FoodTracker.GetFoodByCategory(selectedCategory);

                fList = fList.OrderBy(o => o.Name).ToList();

                Food currentFood = FoodLookupView.SelectedFood;

                if (fList.Count == 0)
                {
                    FoodLookupView.SelectedFoodIndex = -1;
                }

                FoodLookupView.Foods = fList;

                if (fList.Contains(currentFood))
                {
                   FoodLookupView.SelectedFood = currentFood;
                }
            }
        }

        public void SetFoodList(int foodIndex)
        {
            FoodCategory selectedCategory = FoodLookupView.SelectedCategory;

            if (selectedCategory != null)
            {
                IList<Food> fList = FoodTracker.GetFoodByCategory(selectedCategory);

                fList = fList.OrderBy(o => o.Name).ToList();

                if (fList.Count == 0)
                {
                    FoodLookupView.SelectedFoodIndex = -1;
                }

                FoodLookupView.Foods = fList;

                if (fList.Count > 0)
                {
                    FoodLookupView.SelectedFoodIndex = foodIndex;
                }
            }
        }

        public void SetFoodList(IList<Food> searchResults)
        {
            if (searchResults.Count == 0)
            {
                FoodLookupView.Foods = searchResults;
            }

            FoodCategory selectedCategory = FoodLookupView.SelectedCategory;

            if (selectedCategory != null)
            {
                IList<Food> fList = searchResults.Where(x => x.Category.Id == selectedCategory.Id).ToList();

                fList = fList.OrderBy(o => o.Name).ToList();

                Food currentFood = FoodLookupView.SelectedFood;

                if (fList.Count == 0)
                {
                    FoodLookupView.SelectedFoodIndex = -1;
                }

                FoodLookupView.Foods = fList;

                if (fList.Contains(currentFood))
                {
                    FoodLookupView.SelectedFood = currentFood;
                }
            }
        }

        public event EventHandler FoodSelectedChanged
        {
            add { FoodLookupView.FoodSelectedChanged += value; }
            remove { FoodLookupView.FoodSelectedChanged -= value; }
        }

        public Food SelectedFood
        {
            get { return FoodLookupView.SelectedFood; }
            set { FoodLookupView.SelectedFood = value; }
        }

        public int SelectedFoodIndex
        {
            get { return FoodLookupView.SelectedFoodIndex; }
            set { FoodLookupView.SelectedFoodIndex = value; }
        }

        public FoodCategory SelectedCategory
        {
            get { return FoodLookupView.SelectedCategory; }
            set { FoodLookupView.SelectedCategory = value; }
        }

        public bool ViewEnabled
        {
            get { return FoodLookupView.Enabled; }
            set { FoodLookupView.Enabled = value; }
        }

        internal void SetCatList(IList<FoodCategory> fCatList)
        {
            FoodLookupView.Categories = fCatList;
        }
    }
}
