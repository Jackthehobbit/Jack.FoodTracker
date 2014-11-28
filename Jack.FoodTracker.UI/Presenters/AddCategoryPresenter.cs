using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                CategoryDTO newCategory = new CategoryDTO()
                {
                    Name = AddCategoryView.CategoryName
                };

                FoodTracker.AddCategory(newCategory);
                CategoryLookupPresenter.UpdateCategories(CategoryLookupPresenter.SelectedCategory);
                AddCategoryView.CategoryName = "";
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
        }

        public bool Enabled
        {
            get { return AddCategoryView.Enabled; }
            set { AddCategoryView.Enabled = value; }
        }
    }
}
