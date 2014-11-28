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
        private readonly CategoryLookupPresenter CategoryLookupPresenter;

        public IList<Food> SearchResults { get; set; }

        public FoodLookupPresenter(IFoodLookupView foodLookupView, FoodTracker foodTracker)
        {
            FoodLookupView = foodLookupView;
            FoodTracker = foodTracker;
            CategoryLookupPresenter = new CategoryLookupPresenter(FoodLookupView.CategoryLookupView, FoodTracker, false, true);

            CategoryLookupPresenter.SelectedCategoryChanged += new EventHandler(OnCategoriesSelectedIndexChanged);

            SetFoodList();
        }

        private void OnCategoriesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchResults != null)
            {
                SetFoodList(SearchResults);
            }
            else
            {
                SetFoodList(0);
            }
        }

        public void SetFoodList()
        {
            FoodCategory selectedCategory = CategoryLookupPresenter.SelectedCategory;

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
            FoodCategory selectedCategory = CategoryLookupPresenter.SelectedCategory;

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
            SearchResults = searchResults;

            if (searchResults.Count == 0)
            {
                FoodLookupView.Foods = searchResults;
            }

            FoodCategory selectedCategory = CategoryLookupPresenter.SelectedCategory;

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
            get { return CategoryLookupPresenter.SelectedCategory; }
            set { CategoryLookupPresenter.UpdateCategories(value); }
        }

        public int SelectedCategoryIndex
        {
            get { return CategoryLookupPresenter.SelectedCategoryIndex; }
            set { CategoryLookupPresenter.UpdateCategories(value); }
        }

        public bool ViewEnabled
        {
            get { return FoodLookupView.Enabled; }
            set { FoodLookupView.Enabled = value; }
        }

        public void SetCatList(IList<FoodCategory> fCatList)
        {
            CategoryLookupPresenter.Categories = fCatList;
        }

        public void UpdateCategories()
        {
            CategoryLookupPresenter.UpdateCategories();
        }

        public void UpdateCategories(int selectedIndex)
        {
            CategoryLookupPresenter.UpdateCategories(selectedIndex);
        }

        public void UpdateCategories(FoodCategory selectedCategory)
        {
            CategoryLookupPresenter.UpdateCategories(selectedCategory);
        }
    }
}
