using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using Jack.FoodTracker;
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

        private bool inEditMode;

        public MainForm()
        {
            InitializeComponent();

            //Create Repositories
            FoodContext context = new FoodContext();
            FoodRepository fRepository = new FoodRepository(context);
            FoodCategoryRepository fCatRepository = new FoodCategoryRepository(context);

            fTracker = new FoodTracker(fRepository, fCatRepository);

            //Get Food Categories
            IList<FoodCategory> fCatList = sortCategories(fTracker.GetAllFoodCategories());

            IList<FoodCategory> fCatList2 = sortCategories(new List<FoodCategory>(fCatList));

            pnlFoodItem = new FoodItemPanel(fCatList2);
            pnlFoodItem.AutoSize = true;
            pnlFoodItem.Location = new Point(425, 177); 
            pnlFoodItem.Enabled = false;

            groupBox1.Controls.Add(pnlFoodItem);

            lbCategory.DataSource = fCatList;
            lbCategory.DisplayMember = "Name";

            inEditMode = false;

            if (fCatList.Count == 0)
            {
                btnAddFood.Enabled = false;
            }
        }

        private IList<FoodCategory> sortCategories(IList<FoodCategory> cats)
        {
            IList<FoodCategory> newCats = cats.OrderBy(o => o.Name).ToList();

            FoodCategory uncategorised = newCats.First(o => o.Name == "Uncategorised");
            newCats.Remove(uncategorised);
            newCats.Add(uncategorised);

            return newCats;
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if(inEditMode)
            {
                //Save the edited changes to the database
                FoodDTO dto = pnlFoodItem.GetInputs();

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
                
                DialogResult delete = MessageBox.Show("Are you sure you want to delete "+ pnlFoodItem.GetName(),"Delete Food?",MessageBoxButtons.YesNo);

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
            using(AddFoodForm addFood = new AddFoodForm(fTracker))
            {
                DialogResult result = addFood.ShowDialog();

                if (result == DialogResult.OK && addFood.GetFoodCategorySelected().Equals(lbCategory.SelectedItem))
                {
                    setFoodCatInfo(lbFood.SelectedIndex);
                }
            }
        }


        private void switchEditMode()
        {
            inEditMode = !inEditMode;

            if (inEditMode)
            {
                btnEditFood.Text = "Save";
                btnDeleteFood.Text = "Cancel";
            }
            else
            {
                btnEditFood.Text = "Edit";
                btnDeleteFood.Text = "Delete";
            }

            lbCategory.Enabled = !inEditMode;
            lbFood.Enabled = !inEditMode;
            btnAddFood.Enabled = !inEditMode;

            pnlFoodItem.Enabled = inEditMode;
        }

        private void setFoodCatInfo(int foodIndex)
        {
            FoodCategory selectedCategory = (FoodCategory)lbCategory.SelectedValue;

            if(selectedCategory != null)
            {
                IList<Food> fList = fTracker.GetFoodByCategory(selectedCategory);

                fList = fList.OrderBy(o => o.Name).ToList();

                lbFood.DataSource = fList;
                lbFood.DisplayMember = "Name";

                if (fList.Count == 0)
                {
                    pnlFoodItem.ClearInputs();

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
                pnlFoodItem.SetInputs(selectedFood);
            }    
        }

        
    }
}
