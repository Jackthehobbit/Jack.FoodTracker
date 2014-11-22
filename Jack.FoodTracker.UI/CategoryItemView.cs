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
    public partial class CategoryItemView : UserControl, ICategoryItemView
    {
        public CategoryItemView()
        {
            InitializeComponent();
        }

        public string CategoryName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
    }
}
