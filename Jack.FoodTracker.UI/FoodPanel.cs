﻿using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class FoodPanel : RightPanel
    {
        private FoodTracker fTracker;

        private bool inEditMode;

        public FoodPanel()
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

        private IList<FoodCategory> sortCategories(IList<FoodCategory> cats)
        {
            IList<FoodCategory> newCats = cats.OrderBy(o => o.Name).ToList();

            FoodCategory uncategorisedCat = newCats.First(o => o.Name == "Uncategorised");
            newCats.Remove(uncategorisedCat);
            newCats.Add(uncategorisedCat);

            return newCats;
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
                
                DialogResult delete = MessageBox.Show("Are you sure you want to delete "+ pnlFoodItem.GetName(),"Delete Food?",MessageBoxButtons.YesNo);

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
    }
}
