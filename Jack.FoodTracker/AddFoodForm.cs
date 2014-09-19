using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            cbCategoryEdit.DataSource = fTracker.GetAllFoodCategories();
            cbCategoryEdit.DisplayMember = "Name";

            btnAddFood.DialogResult = DialogResult.OK;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = new FoodDTO()
                {
                    Name = tbName.Text,
                    Category = (FoodCategory)cbCategoryEdit.SelectedItem,
                    Description = tbDesc.Text,
                    Calories = tbCalories.Text,
                    Sugar = tbSugar.Text,
                    Fat = tbFat.Text,
                    Saturates = tbSatFat.Text,
                    Salt = tbSalt.Text
                };

                fTracker.AddFood(dto);

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public FoodCategory GetFoodCategorySelected()
        {
            return (FoodCategory)cbCategoryEdit.SelectedItem;
        }       
    }
}
