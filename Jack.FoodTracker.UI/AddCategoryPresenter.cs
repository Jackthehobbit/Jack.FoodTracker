using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    class AddCategoryPresenter
    {
        private readonly IAddCategoryView AddCategoryView;
        private readonly FoodTracker FoodTracker;

        private readonly CategoryLookupPresenter CategoryLookupPresenter;

        public AddCategoryPresenter(IAddCategoryView addCategoryView, FoodTracker foodTracker, CategoryLookupPresenter categoryLookupPresenter)
        {
            AddCategoryView = addCategoryView;
            FoodTracker = foodTracker;
            CategoryLookupPresenter = categoryLookupPresenter;

            AddCategoryView.AddCategoryClicked += new EventHandler(OnAddCategoriesButtonClick);
        }

        private void OnAddCategoriesButtonClick(object sender, EventArgs e)
        {
            try
            {
                FoodTracker.AddCategory(AddCategoryView.CategoryName);
                CategoryLookupPresenter.UpdateCategories(CategoryLookupPresenter.SelectedCategory);
                AddCategoryView.CategoryName = "";
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show(aex.Message);
            }
        }

        public bool Enabled
        {
            get { return AddCategoryView.Enabled; }
            set { AddCategoryView.Enabled = value; }
        }
    }
}
