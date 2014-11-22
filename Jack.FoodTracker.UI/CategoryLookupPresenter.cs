using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    class CategoryLookupPresenter
    {
        private readonly ICategoryLookupView CategoryLookupView;
        private readonly FoodTracker FoodTracker;
        private readonly bool ShowUncategorised;

        public CategoryLookupPresenter(ICategoryLookupView categoryLookupView, FoodTracker foodTracker, bool showUncategorised)
        {
            CategoryLookupView = categoryLookupView;
            FoodTracker = foodTracker;
            ShowUncategorised = showUncategorised;

            UpdateCategories(0);
        }

        public event EventHandler SelectedCategoryChanged
        {
            add { CategoryLookupView.SelectedCategoryChanged += value; }
            remove { CategoryLookupView.SelectedCategoryChanged -= value; }
        }

        public FoodCategory SelectedCategory
        {
            get { return CategoryLookupView.SelectedCategory; }
            set { CategoryLookupView.SelectedCategory = value; }
        }

        public int SelectedCategoryIndex
        {
            get { return CategoryLookupView.SelectedCategoryIndex; }
            set { CategoryLookupView.SelectedCategoryIndex = value; }
        }

        public IList<FoodCategory> Categories
        {
            get { return CategoryLookupView.Categories; }
            set { CategoryLookupView.Categories = value; }
        }

        public bool Enabled
        {
            get { return CategoryLookupView.Enabled; }
            set { CategoryLookupView.Enabled = value; }
        }

        public void UpdateCategories(int selectedIndex)
        {
            IList<FoodCategory> categories = FoodTracker.GetAllFoodCategories(ShowUncategorised);

            if (categories.Count == 0)
            {
                CategoryLookupView.SelectedCategoryIndex = -1;
            }

            CategoryLookupView.Categories = categories;

            if (categories.Count != 0)
            {
                CategoryLookupView.SelectedCategoryIndex = selectedIndex > 0 ? selectedIndex - 1 : 0;
            }

        }

        public void UpdateCategories(FoodCategory selectedFCat)
        {
            IList<FoodCategory> categories = FoodTracker.GetAllFoodCategories(ShowUncategorised);

            if (categories.Count == 0)
            {
                CategoryLookupView.SelectedCategoryIndex = -1;
            }

            CategoryLookupView.Categories = categories;

            CategoryLookupView.SelectedCategory = selectedFCat;
        }
    }
}
