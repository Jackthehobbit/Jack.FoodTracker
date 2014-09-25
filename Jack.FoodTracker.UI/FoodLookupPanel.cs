﻿using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class FoodLookupPanel : Panel
    {
        public ListBox lbFood { get; private set; }

        public Food SelectedFood
        {
            get
            {
                return (Food)lbFood.SelectedItem;
            }

            set
            {
                lbFood.SelectedItem = value;
            }
        }

        public int SelectedFoodindex
        {
            get
            {
                return lbFood.SelectedIndex;
            }

            set
            {
                lbFood.SelectedIndex = value;
            }
        }

        public FoodCategory SelectedCategory
        {
            get
            {
                return (FoodCategory)lbCategory.SelectedItem;
            }

            set
            {
                lbCategory.SelectedItem = value;
            }
        }

        private ListBox lbCategory;
        private readonly FoodTracker fTracker;

        public FoodLookupPanel(FoodTracker fTracker, IList<FoodCategory> cats)
        {
            InitializeComponent(cats);
            this.fTracker = fTracker;
        }

        private void lbCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            SetFoodList(0);
        }

        public void SetFoodList()
        {
            FoodCategory selectedCategory = (FoodCategory)lbCategory.SelectedValue;

            if (selectedCategory != null)
            {
                IList<Food> fList = fTracker.GetFoodByCategory(selectedCategory);

                fList = fList.OrderBy(o => o.Name).ToList();

                Food currentFood = (Food)lbFood.SelectedItem;

                if (fList.Count == 0)
                {
                    lbFood.SelectedIndex = -1;
                }

                lbFood.DataSource = fList;
                lbFood.DisplayMember = "Name";

                if (fList.Contains(currentFood))
                {
                    lbFood.SelectedItem = currentFood;
                }
            }
        }

        public void SetFoodList(int foodIndex)
        {
            FoodCategory selectedCategory = (FoodCategory)lbCategory.SelectedValue;

            if (selectedCategory != null)
            {
                IList<Food> fList = fTracker.GetFoodByCategory(selectedCategory);

                fList = fList.OrderBy(o => o.Name).ToList();

                if (fList.Count == 0)
                {
                    lbFood.SelectedIndex = -1;
                }

                lbFood.DataSource = fList;
                lbFood.DisplayMember = "Name";

                if (fList.Count > 0)
                {
                    lbFood.SelectedIndex = foodIndex;
                }
            }
        }
    }
}
