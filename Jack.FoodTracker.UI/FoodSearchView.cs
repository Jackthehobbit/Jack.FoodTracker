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
    public partial class FoodSearchView : UserControl, IFoodSearchView
    {
        public FoodSearchView()
        {
            InitializeComponent();
        }

        public string SearchText
        {
            get { return tbSearch.Text; }
        }

        public event EventHandler SearchBarTextChanged
        {
            add { tbSearch.TextChanged += value; }
            remove { tbSearch.TextChanged -= value; }
        }
    }
}
