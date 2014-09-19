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
        private FoodTracker fTracker;

        private FoodContext context = new FoodContext();

        private bool inEditMode;

        public MainForm()
        {
            InitializeComponent();

            inEditMode = false;

            FoodRepository fRepository = new FoodRepository(context);
            FoodCategoryRepository fCatRepository = new FoodCategoryRepository(context);

            fTracker = new FoodTracker(fRepository, fCatRepository);

            IList<FoodCategory> fCatList = fTracker.GetAllFoodCategories();

            IList<FoodCategory> fCatList2 = new List<FoodCategory>(fCatList);

            cbCategoryEdit.DataSource = fCatList2;
            cbCategoryEdit.DisplayMember = "Name";

            lbCategory.DataSource = fCatList;
            lbCategory.DisplayMember = "Name";

            if (fCatList.Count == 0)
            {
                btnAddFood.Enabled = false;
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if(inEditMode)
            {
                //Save the edited changes to the database
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

                Food selectedFood = (Food)lbFood.SelectedItem;

                try
                {
                    fTracker.EditFood(dto, selectedFood);
                    if(!dto.Category.Equals(lbCategory.SelectedItem))
                    {
                        lbCategory.SelectedItem = dto.Category;
                        lbFood.SelectedItem = selectedFood;
                    }

                    switchEditMode();
                }
                catch(ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }
            }
            else
            {
                switchEditMode();
            }

            
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            //Button is displaying Cancel when in edit mode
            if(inEditMode)
            {
                //Return food back to original values
                setFoodInfo();

                //Return to normal mode
                switchEditMode();
            }
            else
            {
                
                DialogResult delete = MessageBox.Show("Are you sure you want to delete "+ tbName.Text,"Delete Food?",MessageBoxButtons.YesNo);

                if(delete == DialogResult.Yes)
                {
                    Food selectedFood = (Food)lbFood.SelectedValue;

                    fTracker.DeleteFood(selectedFood);

                    int foodIndex = lbFood.SelectedIndex;

                    setFoodCatInfo(foodIndex > 0 ? foodIndex - 1 : 0);
                }
                
            }
        }

        private void lbCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            setFoodCatInfo(0);
            
        }

        private void lbFood_SelectedValueChanged(object sender, EventArgs e)
        {
            setFoodInfo();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            AddFoodForm addFood = new AddFoodForm(fTracker);
            DialogResult result = addFood.ShowDialog();

            if(result == DialogResult.OK && addFood.GetFoodCategorySelected().Equals(lbCategory.SelectedItem))
            {
                 setFoodCatInfo(lbFood.SelectedIndex);
            }

            
        }


        private void switchEditMode()
        {
            if (inEditMode)
            {
                btnEditFood.Text = "Edit";
                btnDeleteFood.Text = "Delete";
            }
            else
            {
                btnEditFood.Text = "Save";
                btnDeleteFood.Text = "Cancel";
            }

            inEditMode = !inEditMode;

            lbCategory.Enabled = !inEditMode;
            lbFood.Enabled = !inEditMode;

            tbName.Enabled = inEditMode;
            cbCategoryEdit.Enabled = inEditMode;
            tbDesc.Enabled = inEditMode;
            tbCalories.Enabled = inEditMode;
            tbSugar.Enabled = inEditMode;
            tbFat.Enabled = inEditMode;
            tbSatFat.Enabled = inEditMode;
            tbSalt.Enabled = inEditMode;
        }

        private void setFoodCatInfo(int foodIndex)
        {
            FoodCategory selectedCategory = (FoodCategory)lbCategory.SelectedValue;

            if(selectedCategory != null)
            {
                IList<Food> fList = fTracker.GetFoodByCategory(selectedCategory);

                lbFood.DataSource = fList;
                lbFood.DisplayMember = "Name";

                if (fList.Count == 0)
                {
                    tbName.Text = "";
                    cbCategoryEdit.SelectedIndex = -1;
                    tbDesc.Text = "";
                    tbCalories.Text = "";
                    tbSugar.Text = "";
                    tbFat.Text = "";
                    tbSatFat.Text = "";
                    tbSalt.Text = "";

                    btnDeleteFood.Enabled = false;
                    btnEditFood.Enabled = false;
                }
                else
                {
                    if (foodIndex != -1)
                    {
                        lbFood.SelectedIndex = foodIndex;
                    }

                    btnDeleteFood.Enabled = true;
                    btnEditFood.Enabled = true;
                }
            }         
        }

        private void setFoodInfo()
        {
            Food selectedFood = (Food)lbFood.SelectedValue;

            if(selectedFood != null)
            {
                tbName.Text = selectedFood.Name;
                cbCategoryEdit.SelectedItem = selectedFood.Category;
                tbDesc.Text = selectedFood.Description;
                tbCalories.Text = "" + selectedFood.Calories;
                tbSugar.Text = "" + selectedFood.Sugars;
                tbFat.Text = "" + selectedFood.Fat;
                tbSatFat.Text = "" + selectedFood.Saturates;
                tbSalt.Text = "" + selectedFood.Salt;
            }    
        }

        
    }
}
