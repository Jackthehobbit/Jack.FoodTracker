using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
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

        public AddFoodPresenter(IAddFoodView addFoodView, FoodTracker foodTracker)
        {
            AddFoodView = addFoodView;
            FoodTracker = foodTracker;
            FoodItemPresenter = new FoodItemPresenter(AddFoodView.FoodItemView, FoodTracker, FoodTracker.GetAllFoodCategories(true));

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

                    FoodCategory newCategory = FoodTracker.AddCategory(categoryDto);

                    dto.Category = newCategory;
                }

                FoodTracker.AddFood(dto);

                AddFoodView.DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public FoodCategory GetFoodCategorySelected()
        {
            return FoodItemPresenter.GetSelectedCategory();
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            AddFoodView.DialogResult = DialogResult.Cancel;
        }
    }
}
