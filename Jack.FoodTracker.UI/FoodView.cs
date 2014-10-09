using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class FoodView : RightView
    {
        private FoodTracker fTracker;

        private bool inEditMode;

        public FoodView(FoodTracker fTracker)
        {
            this.fTracker = fTracker;

            InitializeComponent();

            //Get Food Categories
            IList<FoodCategory> fCatList = fTracker.GetAllFoodCategories(true);

            IList<FoodCategory> fCatList2 = new List<FoodCategory>(fCatList);

            pnlFoodItem = new FoodItemView(fCatList2);
            pnlFoodItem.AutoSize = true;
            pnlFoodItem.Location = new System.Drawing.Point(425, 177); 
            pnlFoodItem.Enabled = false;

            pnlFoodLookup = new FoodLookupView(fTracker, fCatList);
            pnlFoodLookup.AutoSize = true;
            pnlFoodLookup.Location = new System.Drawing.Point(46, 143);
            pnlFoodLookup.lbFood.SelectedIndexChanged += new System.EventHandler(this.FoodListItemChanged);

            Controls.Add(pnlFoodItem);
            Controls.Add(pnlFoodLookup);

            pnlFoodLookup.BringToFront();

            inEditMode = false;

            if (fCatList.Count == 0)
            {
                btnAddFood.Enabled = false;
            }
        }

        private void OnEditFoodButtonClick(object sender, EventArgs e)
        {
            if(inEditMode)
            {
                //Save the edited changes to the database
                FoodDTO dto = pnlFoodItem.GetInputs();

                Food selectedFood = pnlFoodLookup.SelectedFood;

                try
                {
                    fTracker.EditFood(dto, selectedFood);

                    if(!dto.Category.Equals(pnlFoodLookup.SelectedCategory))
                    {
                        pnlFoodLookup.SelectedCategory = dto.Category;
                        pnlFoodLookup.SelectedFood = selectedFood;
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

        private void OnDeleteFoodButtonClick(object sender, EventArgs e)
        {
            //Button is displaying Cancel when in edit mode
            if(inEditMode)
            {
                //Return food back to original values
                setFood();

                //Return to normal mode
                switchEditMode();
            }
            else
            {

                DialogResult delete = MessageBox.Show("Are you sure you want to delete " + pnlFoodItem.GetName() + "?", "Delete Food?", MessageBoxButtons.YesNo);

                if(delete == DialogResult.Yes)
                {
                    Food selectedFood = pnlFoodLookup.SelectedFood;

                    fTracker.DeleteFood(selectedFood);

                    int foodIndex = pnlFoodLookup.SelectedFoodindex;

                    pnlFoodLookup.SetFoodList(foodIndex > 0 ? foodIndex - 1 : 0);
                }
                
            }
        }

        private void OnAddFoodButtonClick(object sender, EventArgs e)
        {
            using(AddFoodForm addFood = new AddFoodForm(fTracker))
            {
                DialogResult result = addFood.ShowDialog();

                if (result == DialogResult.OK && addFood.GetFoodCategorySelected().Equals(pnlFoodLookup.SelectedCategory))
                {
                    pnlFoodLookup.SetFoodList();
                }
            }
        }

        private void FoodListItemChanged(object sender, EventArgs e)
        {
            setFood();
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

            pnlFoodLookup.Enabled = !inEditMode;
            btnAddFood.Enabled = !inEditMode;

            pnlFoodItem.Enabled = inEditMode;
        }

        private void setFood()
        {
            Food selectedFood = pnlFoodLookup.SelectedFood;

            if(selectedFood != null)
            {
                pnlFoodItem.SetInputs(selectedFood);

                btnDeleteFood.Enabled = true;
                btnEditFood.Enabled = true;
            }
            else
            {
                pnlFoodItem.ClearInputs();

                btnDeleteFood.Enabled = false;
                btnEditFood.Enabled = false;
            }
        }

        private void SearchBarTextChanged(object sender, EventArgs e)
        {
            IList<FoodCategory> fCatList = fTracker.GetAllFoodCategories(true);
            if (tbSearch.Text == "")
            {
                pnlFoodLookup.setCatList(fCatList);
               // pnlFoodLookup.SetFoodList();
            }
            else
            {
                IList<Food> searchResults = fTracker.SearchFoodByName(tbSearch.Text);
                if( searchResults.Count != 0)
                {
                    IList<FoodCategory> cats = fTracker.GetAllFoodCategories(false);
                    foreach (FoodCategory item in fCatList)
                    {

                        try
                        {
                            Food findCat = searchResults.Where(x => x.Category.Id.Equals(item.Id)).First();
                        }
                        catch (InvalidOperationException)
                        {
                            cats.Remove(item);
                        }


                    }
                    pnlFoodLookup.setCatList(cats);
                    pnlFoodLookup.SetFoodList(searchResults);
                }
                else
                {
                    
                    pnlFoodLookup.SetFoodList(searchResults);
                }
               
                
             }
             
            
        }
    }
}
