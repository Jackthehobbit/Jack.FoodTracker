using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class AddFoodForm : Form
    {
        private readonly FoodTracker fTracker;
        private readonly FoodItemPresenter FoodItemPresenter;

        public AddFoodForm(FoodTracker fTracker)
        {
            InitializeComponent();

            this.fTracker = fTracker;

            // Create Food Item Panel
            foodItemView = new FoodItemView();
            foodItemView.AutoSize = true;
            foodItemView.Location = new System.Drawing.Point(1, 69);
            foodItemView.TabIndex = 0;

            FoodItemPresenter = new FoodItemPresenter(foodItemView, fTracker.GetAllFoodCategories(true));

            Controls.Add(this.foodItemView);
        }

        private void OnAddFoodButtonClick(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = FoodItemPresenter.GetInputs();

                fTracker.AddFood(dto);

                DialogResult = DialogResult.OK;
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
            DialogResult = DialogResult.Cancel;
        }
    }
}
