using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jack.FoodTracker.Entities;

namespace Jack.FoodTracker
{
    public partial class CategoryLookupView : UserControl, ICategoryLookupView
    {
        public CategoryLookupView()
        {
            InitializeComponent();
        }

        public IList<FoodCategory> Categories
        {
            get { return (IList<FoodCategory>)lbCategories.DataSource; }
            set { lbCategories.DataSource = value; }
        }

        public FoodCategory SelectedCategory
        {
            get { return (FoodCategory)lbCategories.SelectedItem; }
            set { lbCategories.SelectedItem = value; }
        }

        public int SelectedCategoryIndex
        {
            get { return lbCategories.SelectedIndex; }
            set { lbCategories.SelectedIndex = value; }
        }

        public event EventHandler SelectedCategoryChanged
        {
            add { lbCategories.SelectedIndexChanged += value; }
            remove { lbCategories.SelectedIndexChanged -= value; }
        }
    }
}
