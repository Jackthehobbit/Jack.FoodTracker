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
    public partial class LeftView : UserControl
    {
        private MainForm MainView;
        public LeftView(MainForm mainView)
        {
            InitializeComponent();
            Size = new System.Drawing.Size(200, 500);
            Location = new System.Drawing.Point(0, 0);
            MainView = mainView;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            MainView.CurrentView = MainView.CategoryView;
        }

        private void btnFoods_Click(object sender, EventArgs e)
        {
            MainView.CurrentView = MainView.FoodView;
        }

        

    

    }
    }

