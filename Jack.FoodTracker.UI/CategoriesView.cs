using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jack.FoodTracker;
using Jack.FoodTracker.Entities;

namespace Jack.FoodTracker
{
    public partial class CategoriesView : RightView
    {
        private readonly FoodTracker fTracker;
        private bool inEditMode;

        public CategoriesView(FoodTracker fTracker)
        {
            this.fTracker = fTracker;
            inEditMode = false;

            InitializeComponent();

            lbCategories.DisplayMember = "Name";

            bool enabled = false;

            tbEditCatName.Enabled = enabled;
            btnCategoryMoveDown.Enabled = enabled;
            btnCategoryMoveUp.Enabled = enabled;
            btnDeleteCategory.Enabled = enabled;
            btnEditCategory.Enabled = enabled;

            updateCategoriesListBox(0);
        }

        private void OnCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            bool enabled;

            if (lbCategories.SelectedItem != null)
            {
                tbEditCatName.Text = ((FoodCategory)lbCategories.SelectedItem).Name;

                enabled = true;
            }
            else
            {
                tbEditCatName.Text = "";

                enabled = false;
            }

            btnCategoryMoveDown.Enabled = enabled;
            btnCategoryMoveUp.Enabled = enabled;
            btnDeleteCategory.Enabled = enabled;
            btnEditCategory.Enabled = enabled;
            
        }

        private void OnAddCategoriesButtonClick(object sender, EventArgs e)
        {
            try
            {
                fTracker.AddCategory(tbAddCatName.Text);
                updateCategoriesListBox((FoodCategory)lbCategories.SelectedItem);
                tbAddCatName.Text = "";
            }
            catch(ArgumentException aex)
            {
                MessageBox.Show(aex.Message);
            }
        }

        private void OnEditCategoryButtonClick(object sender, EventArgs e)
        {
            if(!inEditMode)
            {
                switchEditMode();
            }
            else
            {
                try
                {
                    FoodCategory selectedFoodCat = (FoodCategory)lbCategories.SelectedItem;

                    fTracker.EditFoodCategory(tbEditCatName.Text, selectedFoodCat);

                    switchEditMode();
                    updateCategoriesListBox(selectedFoodCat);
                }
                catch(ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }

            }
        }

        private void OnDeleteCategoryButtonClick(object sender, EventArgs e)
        {
            FoodCategory selectedFoodCategory = (FoodCategory)lbCategories.SelectedItem;

            if(inEditMode)
            {
                tbEditCatName.Text = selectedFoodCategory.Name;

                switchEditMode();
            }
            else
            {
                try
                {
                    DialogResult delete = MessageBox.Show("Are you sure you want to delete "+ tbEditCatName.Text + "?","Delete Category?",MessageBoxButtons.YesNo);

                    if (delete == DialogResult.Yes)
                    {
                        fTracker.DeleteCategory(selectedFoodCategory);

                        int categoryIndex = lbCategories.SelectedIndex;

                        updateCategoriesListBox(categoryIndex);
                    }
                }
                catch(ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }
            }
        }

        private void OnCategoryMoveUpButtonClick(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = (IList<FoodCategory>)lbCategories.DataSource;

            int selectedIndex = lbCategories.SelectedIndex;

            if(selectedIndex > 0)
            {
                FoodCategory fCat = fCatList.ElementAt(selectedIndex);
                FoodCategory fCatAbove = fCatList.ElementAt(selectedIndex - 1);

                fTracker.SwapCategoryOrder(fCat, fCatAbove);

                updateCategoriesListBox(fCat);
            }  
        }

        private void OnCategoryMoveDownButtonClick(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = (IList<FoodCategory>)lbCategories.DataSource;

            int selectedIndex = lbCategories.SelectedIndex;

            if (selectedIndex < fCatList.Count-1)
            {
                FoodCategory fCat = fCatList.ElementAt(selectedIndex);
                FoodCategory fCatBelow = fCatList.ElementAt(selectedIndex + 1);

                fTracker.SwapCategoryOrder(fCat, fCatBelow);

                updateCategoriesListBox(fCat);
            } 
        }

        private void switchEditMode()
        {
            inEditMode = !inEditMode;

            if (inEditMode)
            {
                btnEditCategory.Text = "Save";
                btnDeleteCategory.Text = "Cancel";
            }
            else
            {
                btnEditCategory.Text = "Edit";
                btnDeleteCategory.Text = "Delete";
            }

            tbEditCatName.Enabled = inEditMode;

            btnCategoryMoveUp.Enabled = !inEditMode;
            btnCategoryMoveDown.Enabled = !inEditMode;
            btnAddCategory.Enabled = !inEditMode;
            lbCategories.Enabled = !inEditMode;
        }

        private void updateCategoriesListBox(int selectedIndex)
        {
            IList<FoodCategory> fCats = fTracker.GetAllFoodCategories(false);

            if(fCats.Count == 0)
            {
                lbCategories.SelectedIndex = -1;
            }

            lbCategories.DataSource = fCats;

            if(fCats.Count != 0)
            {
                lbCategories.SelectedIndex = selectedIndex > 0 ? selectedIndex - 1 : 0;
            }
            
        }

        private void updateCategoriesListBox(FoodCategory selectedFCat)
        {
            IList<FoodCategory> fCats = fTracker.GetAllFoodCategories(false);

            if (fCats.Count == 0)
            {
                lbCategories.SelectedIndex = -1;
            }

            lbCategories.DataSource = fCats;

            lbCategories.SelectedItem = selectedFCat;
        }
    }
}
