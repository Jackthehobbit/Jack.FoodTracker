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

        public AddFoodForm(FoodTracker fTracker)
        {
            InitializeComponent();

            this.fTracker = fTracker;

            // Create Food Item Panel
            pnlFoodItem = new FoodItemPanel(fTracker.GetAllFoodCategories());
            pnlFoodItem.AutoSize = true;
            pnlFoodItem.Location = new System.Drawing.Point(1, 69);
            pnlFoodItem.Name = "pnlFoodItem";
            pnlFoodItem.TabIndex = 0;

            Controls.Add(this.pnlFoodItem);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = pnlFoodItem.GetInputs();

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
            return pnlFoodItem.GetSelectedCategory();
        }
    }
}
