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
    class FoodPresenter
    {
        private readonly IFoodView FoodView;

        private readonly FoodItemPresenter FoodItemPresenter;
        private readonly FoodLookupPresenter FoodLookupPresenter;
        private readonly FoodSearchPresenter FoodSearchPresenter;

        private readonly FoodTracker FoodTracker;

        private bool _inEditMode;
        private bool InEditMode
        {
            get { return _inEditMode; }

            set
            {
                _inEditMode = value;

                if (_inEditMode)
                {
                    FoodView.EditFoodButtonText = "Save";
                    FoodView.DeleteFoodButtonText = "Cancel";
                }
                else
                {
                    FoodView.EditFoodButtonText = "Edit";
                    FoodView.DeleteFoodButtonText = "Delete";
                }

                FoodLookupPresenter.ViewEnabled = !_inEditMode;
                FoodView.AddFoodButtonEnabled = !_inEditMode;
                FoodSearchPresenter.ViewEnabled = !_inEditMode;

                FoodItemPresenter.ViewEnabled = _inEditMode;
            }
        }

        public FoodPresenter(IFoodView foodView, FoodTracker foodTracker)
        {
            FoodView = foodView;
            FoodTracker = foodTracker;

            FoodItemPresenter = new FoodItemPresenter(FoodView.FoodItemView, FoodTracker);
            FoodLookupPresenter = new FoodLookupPresenter(FoodView.FoodLookupView, FoodTracker);
            FoodSearchPresenter = new FoodSearchPresenter(FoodView.FoodSearchView, FoodTracker, FoodLookupPresenter);

            FoodView.AddFoodClick += new EventHandler(OnAddFoodButtonClick);
            FoodView.EditFoodClick += new EventHandler(OnEditFoodButtonClick);
            FoodView.DeleteFoodClick += new EventHandler(OnDeleteFoodButtonClick);
            FoodLookupPresenter.FoodSelectedChanged += new System.EventHandler(OnFoodListItemChanged);

            setFood();

            InEditMode = false;

            if (FoodTracker.GetAllFoodCategories(true).Count == 0)
            {
                FoodView.AddFoodButtonEnabled = false;
            }
        }

        private void OnEditFoodButtonClick(object sender, EventArgs e)
        {
            if (InEditMode)
            {
                //Save the edited changes to the database
                FoodDTO dto = FoodItemPresenter.GetInputs();

                Food selectedFood = FoodLookupPresenter.SelectedFood;

                try
                {
                    if (dto.Category == null)
                    {
                         CategoryDTO categoryDto = new CategoryDTO()
                        {
                            Name = FoodItemPresenter.GetNewCategoryName()
                        };

                        FoodCategory newCategory = FoodTracker.AddCategory(categoryDto);

                        dto.Category = newCategory;
                    }

                    FoodTracker.EditFood(dto, selectedFood);

                    FoodItemPresenter.UpdateCategories();

                    if (!dto.Category.Equals(FoodLookupPresenter.SelectedCategory))
                    {
                        FoodLookupPresenter.SelectedCategory = dto.Category;
                        FoodLookupPresenter.SelectedFood = selectedFood;
                    }

                    InEditMode = false;
                }
                catch(ValidationException vex)
                {
                    MessageBox.Show(vex.Message);
                }
            }
            else
            {
                InEditMode = true;
            }
        }

        private void OnDeleteFoodButtonClick(object sender, EventArgs e)
        {
            //Button is displaying Cancel when in edit mode
            if (InEditMode)
            {
                //Return food back to original values
                setFood();

                //Return to normal mode
                InEditMode = false;
            }
            else
            {

                DialogResult delete = MessageBox.Show("Are you sure you want to delete " + FoodItemPresenter.GetName() + "?", "Delete Food?", MessageBoxButtons.YesNo);

                if (delete == DialogResult.Yes)
                {
                    Food selectedFood = FoodLookupPresenter.SelectedFood;

                    FoodCategory selectedCategory = selectedFood.Category;

                    FoodTracker.DeleteFood(selectedFood);

                    int foodIndex = FoodLookupPresenter.SelectedFoodIndex;
                    int categoryIndex = FoodLookupPresenter.SelectedCategoryIndex;

                    if(selectedCategory.Foods.Count == 0)
                    {
                        FoodLookupPresenter.UpdateCategories(categoryIndex > 0 ? categoryIndex - 1 : 0);
                    }
                    else
                    {
                        FoodLookupPresenter.SetFoodList(foodIndex > 0 ? foodIndex - 1 : 0);
                    }
                }
            }
        }

        private void OnAddFoodButtonClick(object sender, EventArgs e)
        {
            using (AddFoodForm addFood = new AddFoodForm())
            {
                AddFoodPresenter addFoodPresenter = new AddFoodPresenter(addFood, FoodTracker);
                DialogResult result = addFood.ShowDialog();

                FoodLookupPresenter.UpdateCategories(FoodLookupPresenter.SelectedCategory);
                FoodItemPresenter.UpdateCategories();
            }
        }

        private void OnFoodListItemChanged(object sender, EventArgs e)
        {
            setFood();
        }

        private void setFood()
        {
            Food selectedFood = FoodLookupPresenter.SelectedFood;

            if (selectedFood != null)
            {
                FoodItemPresenter.SetInputs(selectedFood);

                FoodView.DeleteFoodButtonEnabled = true;
                FoodView.EditFoodButtonEnabled = true;
            }
            else
            {
                FoodItemPresenter.ClearInputs();

                FoodView.DeleteFoodButtonEnabled = false;
                FoodView.EditFoodButtonEnabled = false;
            }
        }
    }
}
