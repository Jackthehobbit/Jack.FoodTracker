using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    class CategoryPresenter
    {
        private readonly ICategoryView CategoryView;
        private readonly FoodTracker FoodTracker;

        private readonly AddCategoryPresenter AddCategoryPresenter;
        private readonly CategoryLookupPresenter CategoryLookupPresenter;
        private readonly CategoryItemPresenter CategoryItemPresenter;

        private bool _inEditMode;

        private bool InEditMode
        {
            get { return _inEditMode; }
            set
            {
                _inEditMode = value;

                if (_inEditMode)
                {
                    CategoryView.EditButtonText = "Save";
                    CategoryView.DeleteButtonText = "Cancel";
                }
                else
                {
                    CategoryView.EditButtonText = "Edit";
                    CategoryView.DeleteButtonText = "Delete";
                }

                CategoryItemPresenter.Enabled = _inEditMode;

                CategoryView.MoveUpButtonEnabled = !_inEditMode;
                CategoryView.MoveDownButtonEnabled = !_inEditMode;
                AddCategoryPresenter.Enabled = !_inEditMode;
                CategoryLookupPresenter.Enabled = !_inEditMode;
            }
        }

        public CategoryPresenter(ICategoryView categoryView, FoodTracker foodTracker)
        {
            CategoryView = categoryView;
            FoodTracker = foodTracker;
            _inEditMode = false;

            CategoryLookupPresenter = new CategoryLookupPresenter(CategoryView.CategoryLookupView, FoodTracker, false);
            AddCategoryPresenter = new AddCategoryPresenter(CategoryView.AddCategoryView, FoodTracker, CategoryLookupPresenter);
            CategoryItemPresenter = new CategoryItemPresenter(CategoryView.CategoryItemView);

            CategoryLookupPresenter.SelectedCategoryChanged += new EventHandler(OnSelectedCategoryChanged);
            CategoryView.EditButtonClick += new EventHandler(OnEditCategoryButtonClick);
            CategoryView.DeleteButtonClick += new EventHandler(OnDeleteCategoryButtonClick);
            CategoryView.MoveUpButtonClick += new EventHandler(OnCategoryMoveUpButtonClick);
            CategoryView.MoveDownButtonClick += new EventHandler(OnCategoryMoveDownButtonClick);

            bool enabled;

            if(CategoryLookupPresenter.SelectedCategory != null)
            {
                enabled = true;
                CategoryItemPresenter.Set(CategoryLookupPresenter.SelectedCategory);
            }
            else
            {
                enabled = false;
            }

            CategoryItemPresenter.Enabled = enabled;
            CategoryView.DeleteButtonEnabled = enabled;
            CategoryView.EditButtonEnabled = enabled;
            CategoryView.MoveUpButtonEnabled = enabled;
            CategoryView.MoveDownButtonEnabled = enabled;
        }

        private void OnSelectedCategoryChanged(object sender, EventArgs e)
        {
            bool enabled;

            if (CategoryLookupPresenter.SelectedCategory != null)
            {
                CategoryItemPresenter.Set(CategoryLookupPresenter.SelectedCategory);

                enabled = true;
            }
            else
            {
                CategoryItemPresenter.Reset();

                enabled = false;
            }

            CategoryView.DeleteButtonEnabled = enabled;
            CategoryView.EditButtonEnabled = enabled;
            CategoryView.MoveUpButtonEnabled = enabled;
            CategoryView.MoveDownButtonEnabled = enabled;
        }

        private void OnEditCategoryButtonClick(object sender, EventArgs e)
        {
            if (!InEditMode)
            {
                InEditMode = true;
            }
            else
            {
                try
                {
                    FoodCategory selectedFoodCat = CategoryLookupPresenter.SelectedCategory;

                    FoodTracker.EditFoodCategory(CategoryItemPresenter.Name, selectedFoodCat);

                    InEditMode = false;
                    CategoryLookupPresenter.UpdateCategories(selectedFoodCat);
                }
                catch (ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }

            }
        }

        private void OnDeleteCategoryButtonClick(object sender, EventArgs e)
        {
            FoodCategory selectedFoodCategory = CategoryLookupPresenter.SelectedCategory;

            if (InEditMode)
            {
                CategoryItemPresenter.Set(selectedFoodCategory);

                InEditMode = false;
            }
            else
            {
                try
                {
                    DialogResult delete = MessageBox.Show("Are you sure you want to delete " + CategoryItemPresenter.Name + "?", "Delete Category?", MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        FoodTracker.DeleteCategory(selectedFoodCategory);

                        int categoryIndex = CategoryLookupPresenter.SelectedCategoryIndex;

                        CategoryLookupPresenter.UpdateCategories(categoryIndex);
                    }
                }
                catch (ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }
            }
        }

        private void OnCategoryMoveUpButtonClick(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = CategoryLookupPresenter.Categories;

            int selectedIndex = CategoryLookupPresenter.SelectedCategoryIndex;

            if (selectedIndex > 0)
            {
                FoodCategory fCat = fCatList.ElementAt(selectedIndex);
                FoodCategory fCatAbove = fCatList.ElementAt(selectedIndex - 1);

                FoodTracker.SwapCategoryOrder(fCat, fCatAbove);

                CategoryLookupPresenter.UpdateCategories(fCat);
            }
        }

        private void OnCategoryMoveDownButtonClick(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = CategoryLookupPresenter.Categories;

            int selectedIndex = CategoryLookupPresenter.SelectedCategoryIndex;

            if (selectedIndex < fCatList.Count - 1)
            {
                FoodCategory fCat = fCatList.ElementAt(selectedIndex);
                FoodCategory fCatBelow = fCatList.ElementAt(selectedIndex + 1);

                FoodTracker.SwapCategoryOrder(fCat, fCatBelow);

                CategoryLookupPresenter.UpdateCategories(fCat);
            }
        }
    }
}
