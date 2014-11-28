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
    class AddFoodPresenter
    {
        private readonly IAddFoodView AddFoodView;
        private readonly FoodItemPresenter FoodItemPresenter;
        private readonly FoodTracker FoodTracker;

        private FoodCategory newCategory;

        public AddFoodPresenter(IAddFoodView addFoodView, FoodTracker foodTracker)
        {
            AddFoodView = addFoodView;
            FoodTracker = foodTracker;
            FoodItemPresenter = new FoodItemPresenter(AddFoodView.FoodItemView, FoodTracker);

            AddFoodView.AddFoodClick += new EventHandler(OnAddFoodButtonClick);
            AddFoodView.CancelClick += new EventHandler(OnCancelButtonClick);
        }

        private void OnAddFoodButtonClick(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = FoodItemPresenter.GetInputs();

                if (dto.Category == null)
                {
                    CategoryDTO categoryDto = new CategoryDTO()
                    {
                        Name = FoodItemPresenter.GetNewCategoryName()
                    };

                    newCategory = FoodTracker.AddCategory(categoryDto);

                    dto.Category = newCategory;
                }

                FoodTracker.AddFood(dto);

                AddFoodView.DialogResult = DialogResult.OK;
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message);
            }
        }

        public FoodCategory GetFoodCategorySelected()
        {
            if(FoodItemPresenter.GetSelectedCategory() != null)
            {
                return FoodItemPresenter.GetSelectedCategory();
            }
            else
            {
                return newCategory;
            }
            
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            AddFoodView.DialogResult = DialogResult.Cancel;
        }
    }
}
