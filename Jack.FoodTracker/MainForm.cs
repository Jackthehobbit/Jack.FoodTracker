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

        private bool inEditMode;

        public MainForm()
        {
            InitializeComponent();

            inEditMode = false;

            FoodRepository fRepository = new FoodRepository(context);
            FoodCategoryRepository fCatRepository = new FoodCategoryRepository(context);

            ftracker = new FoodTracker(fRepository, fCatRepository);

            IList<FoodCategory> fCatList = ftracker.GetAllFoodCategories();

            IList<FoodCategory> fCatList2 = new List<FoodCategory>(fCatList);

            cbCategoryEdit.DataSource = fCatList2;
            cbCategoryEdit.DisplayMember = "Name";

            lbCategory.DataSource = fCatList;
            lbCategory.DisplayMember = "Name";
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if(inEditMode)
            {
                inEditMode = false;
                btnEditFood.Text = "Edit";
                btnDeleteFood.Text = "Delete";

                lbCategory.Enabled = true;
                lbFood.Enabled = true;

                //Save the edited changes to the database
                
            }
            else
            {
                inEditMode = true;
                btnEditFood.Text = "Save";
                btnDeleteFood.Text = "Cancel";

                lbCategory.Enabled = false;
                lbFood.Enabled = false;
            }

            switchFoodEnabled();
        }

        private void switchFoodEnabled()
        {
            tbName.Enabled = !tbName.Enabled;
            cbCategoryEdit.Enabled = !cbCategoryEdit.Enabled;
            tbDesc.Enabled = !tbDesc.Enabled;
            tbCalories.Enabled = !tbCalories.Enabled;
            tbSugar.Enabled = !tbSugar.Enabled;
            tbFat.Enabled = !tbFat.Enabled;
            tbSatFat.Enabled = !tbSatFat.Enabled;
            tbSalt.Enabled = !tbSalt.Enabled;
        }

        private void lbCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            FoodCategory selectedCategory = (FoodCategory)lbCategory.SelectedValue;

            IList<Food> fList = ftracker.GetFoodByCategory(selectedCategory);

            lbFood.DataSource = fList;
            lbFood.DisplayMember = "Name";

           

            if(fList.Count == 0)
            {
                tbName.Text = "";
                cbCategoryEdit.SelectedIndex = -1;
                tbDesc.Text = "";
                tbCalories.Text = "";
                tbSugar.Text = "";
                tbFat.Text = "";
                tbSatFat.Text = "";
                tbSalt.Text = "";
            }
            
        }

        private void lbFood_SelectedValueChanged(object sender, EventArgs e)
        {
            Food selectedFood = (Food)lbFood.SelectedValue;

            tbName.Text = selectedFood.Name;
            cbCategoryEdit.SelectedIndex = lbCategory.SelectedIndex;
            tbDesc.Text = selectedFood.Description;
            tbCalories.Text = "" + selectedFood.Calories;
            tbSugar.Text = "" + selectedFood.Sugars;
            tbFat.Text = "" + selectedFood.Fat;
            tbSatFat.Text = "" + selectedFood.Saturates;
            tbSalt.Text = "" + selectedFood.Salt;
        }
    }
}
