using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using Jack.FoodTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class MainForm : Form, IMainView
    {
        public FoodView FoodView { get; private set; }

        public MainForm(FoodTracker FoodTracker)
        {
            InitializeComponent();
            FoodView = new FoodView();
            CategoriesView CategoriesView = new CategoriesView(FoodTracker);

            _CurrentView = CategoriesView;
            Controls.Add(_CurrentView);
        }


        private RightView _CurrentView;
        public RightView CurrentView
        {
            get { return _CurrentView; }

            set
            {
                Controls.Remove(_CurrentView);
                Controls.Add(value);
                _CurrentView = value;
            }
        }
    }
}
