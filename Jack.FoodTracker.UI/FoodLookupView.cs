using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class FoodLookupView : UserControl, IFoodLookupView
    {
        private ListBox lbFood;
        private ListBox lbCategory;

        public FoodLookupView()
        {
            InitializeComponent();
        }

        public IList<Food> Foods
        {
            set { lbFood.DataSource = value; }
        }

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

        public int SelectedFoodIndex
        {
            get { return lbFood.SelectedIndex; }
            set { lbFood.SelectedIndex = value; }
        }

        public IList<FoodCategory> Categories
        {
            set { lbCategory.DataSource = value; }
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

        public event EventHandler CategorySelectedChanged
        {
            add { lbCategory.SelectedIndexChanged += value; }
            remove { lbCategory.SelectedIndexChanged -= value; }
        }

        public event EventHandler FoodSelectedChanged
        {
            add { lbFood.SelectedIndexChanged += value; }
            remove { lbFood.SelectedIndexChanged -= value; }
        }
    }
}

