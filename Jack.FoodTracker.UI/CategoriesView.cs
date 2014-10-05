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

            IList<FoodCategory> fCats = fTracker.GetAllFoodCategories(false);

            lbCategories.DataSource = fCats;
            lbCategories.DisplayMember = "Name";

            tbEditCatName.Enabled = false;
        }

        private void OnCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            tbEditCatName.Text = ((FoodCategory)lbCategories.SelectedItem).Name;
        }

        private void OnAddCategoriesButtonClick(object sender, EventArgs e)
        {
            try
            {
                fTracker.AddCategory(tbAddCatName.Text);
                updateCategoriesListBox();
                tbAddCatName.Text = "";
            }
            catch(ArgumentException aex)
            {
                MessageBox.Show(aex.Message);
            }
        }

        private void updateCategoriesListBox()
        {
            IList<FoodCategory> fCats = fTracker.GetAllFoodCategories(false);

            lbCategories.DataSource = fCats;
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
                    updateCategoriesListBox();
                    lbCategories.SelectedItem = selectedFoodCat;
                }
                catch(ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }

            }
        }

        private void switchEditMode()
        {
            inEditMode = !inEditMode;

            if(inEditMode)
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

                        updateCategoriesListBox();

                        lbCategories.SelectedIndex = categoryIndex > 0 ? categoryIndex - 1 : 0;
                    }
                }
                catch(ArgumentException aex)
                {
                    MessageBox.Show(aex.Message);
                }
            }
        }
    }
}
