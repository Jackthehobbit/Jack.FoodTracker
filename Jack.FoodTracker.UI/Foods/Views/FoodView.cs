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
    public partial class FoodView : RightView, IFoodView
    {
        public IFoodItemView FoodItemView { get; private set; }
        public IFoodLookupView FoodLookupView { get; private set; }
        public IFoodSearchView FoodSearchView { get; private set; }

        public FoodView()
        {
            InitializeComponent();

            FoodItemView = foodItemView;
            FoodLookupView = foodLookupView;
            FoodSearchView = foodSearchView;
        }

        public bool AddFoodButtonEnabled
        {
            set { btnAddFood.Enabled = value; }
        }

        public string EditFoodButtonText
        {
            set { btnEditFood.Text = value; }
        }

        public bool EditFoodButtonEnabled
        {
            set { btnEditFood.Enabled = value; }
        }

        public string DeleteFoodButtonText
        {
            set { btnDeleteFood.Text = value; }
        }

        public bool DeleteFoodButtonEnabled
        {
            set { btnDeleteFood.Enabled = value; }
        }

        public event EventHandler AddFoodClick
        {
            add { btnAddFood.Click += value; }
            remove { btnAddFood.Click -= value; }
        }

        public event EventHandler EditFoodClick
        {
            add { btnEditFood.Click += value; }
            remove { btnEditFood.Click -= value; }
        }

        public event EventHandler DeleteFoodClick
        {
            add { btnDeleteFood.Click += value; }
            remove { btnDeleteFood.Click -= value; }
        }
    }
}
