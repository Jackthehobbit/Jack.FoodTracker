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

            foodItemView = new FoodItemView(fCatList2);
            foodItemView.AutoSize = true;
            foodItemView.Location = new System.Drawing.Point(425, 177); 
            foodItemView.Enabled = false;

            foodLookupView = new FoodLookupView(fTracker, fCatList);
            foodLookupView.AutoSize = true;
            foodLookupView.Location = new System.Drawing.Point(46, 143);
            foodLookupView.lbFood.SelectedIndexChanged += new System.EventHandler(this.FoodListItemChanged);

            FoodSearchPresenter foodSearchPresenter = new FoodSearchPresenter(foodSearchView, fTracker, foodLookupView);

            Controls.Add(foodItemView);
            Controls.Add(foodLookupView);

            foodLookupView.BringToFront();

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
                FoodDTO dto = foodItemView.GetInputs();

                Food selectedFood = foodLookupView.SelectedFood;

                try
                {
                    fTracker.EditFood(dto, selectedFood);

                    if(!dto.Category.Equals(foodLookupView.SelectedCategory))
                    {
                        foodLookupView.SelectedCategory = dto.Category;
                        foodLookupView.SelectedFood = selectedFood;
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

                DialogResult delete = MessageBox.Show("Are you sure you want to delete " + foodItemView.GetName() + "?", "Delete Food?", MessageBoxButtons.YesNo);

                if(delete == DialogResult.Yes)
                {
                    Food selectedFood = foodLookupView.SelectedFood;

                    fTracker.DeleteFood(selectedFood);

                    int foodIndex = foodLookupView.SelectedFoodindex;

                    foodLookupView.SetFoodList(foodIndex > 0 ? foodIndex - 1 : 0);
                }
                
            }
        }

        private void OnAddFoodButtonClick(object sender, EventArgs e)
        {
            using(AddFoodForm addFood = new AddFoodForm(fTracker))
            {
                DialogResult result = addFood.ShowDialog();

                if (result == DialogResult.OK && addFood.GetFoodCategorySelected().Equals(foodLookupView.SelectedCategory))
                {
                    foodLookupView.SetFoodList();
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

            foodLookupView.Enabled = !inEditMode;
            btnAddFood.Enabled = !inEditMode;

            foodItemView.Enabled = inEditMode;
        }

        private void setFood()
        {
            Food selectedFood = foodLookupView.SelectedFood;

            if(selectedFood != null)
            {
                foodItemView.SetInputs(selectedFood);

                btnDeleteFood.Enabled = true;
                btnEditFood.Enabled = true;
            }
            else
            {
                foodItemView.ClearInputs();

                btnDeleteFood.Enabled = false;
                btnEditFood.Enabled = false;
            }
        }
    }
}
