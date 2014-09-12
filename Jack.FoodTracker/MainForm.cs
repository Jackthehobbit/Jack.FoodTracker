using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
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
    public partial class MainForm : Form
    {
        private FoodTracker ftracker;

        private FoodContext context = new FoodContext();

        public MainForm()
        {
            InitializeComponent();

            FoodRepository fRepository = new FoodRepository(context);
            FoodCategoryRepository fCatRepository = new FoodCategoryRepository(context);

            ftracker = new FoodTracker(fRepository, fCatRepository);

            IList<FoodCategory> fCatList = ftracker.GetAllFoodCategories();

            lbCategory.DataSource = fCatList;
            lbCategory.DisplayMember = "Name";

            cbCategoryEdit.DataSource = fCatList;
            cbCategoryEdit.DisplayMember = "Name";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = new FoodDTO();

                dto.Name = tbName.Text;
                dto.Description = tbDesc.Text;
                dto.Calories = tbCalories.Text;
                dto.Sugar = tbSugar.Text;
                dto.Fat = tbFat.Text;
                dto.Saturates = tbSatFat.Text;
                dto.Salt = tbSalt.Text;

                ftracker.AddFood(dto);

                tbName.Text = "";
                tbDesc.Text = "";
                tbCalories.Text = "";
                tbSugar.Text = "";
                tbFat.Text = "";
                tbSatFat.Text = "";
                tbSalt.Text = "";
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            FoodCategory selectedCategory = (FoodCategory)lbCategory.SelectedValue;

            IList<Food> fList = ftracker.GetFoodByCategory(selectedCategory);

            lbFood.DataSource = fList;
            lbFood.DisplayMember = "Name";
        }

        private void lbFood_SelectedValueChanged(object sender, EventArgs e)
        {
            Food selectedFood = (Food)lbFood.SelectedValue;

            tbName.Text = selectedFood.Name;
            tbDesc.Text = selectedFood.Description;
            tbCalories.Text = "" + selectedFood.Calories;
            tbSugar.Text = "" + selectedFood.Sugars;
            tbFat.Text = "" + selectedFood.Fat;
            tbSatFat.Text = "" + selectedFood.Saturates;
            tbSalt.Text = "" + selectedFood.Salt;
            
        }
    }
}
