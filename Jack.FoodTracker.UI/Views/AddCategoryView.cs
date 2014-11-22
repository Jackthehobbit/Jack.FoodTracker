using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class AddCategoryView : UserControl, IAddCategoryView
    {
        public AddCategoryView()
        {
            InitializeComponent();
        }

        public string CategoryName
        {
            get { return tbAddCatName.Text; }
            set { tbAddCatName.Text = value; }
        }

        public event EventHandler AddCategoryClicked
        {
            add { btnAddCategory.Click += value; }
            remove { btnAddCategory.Click -= value; }
        }
    }
}
