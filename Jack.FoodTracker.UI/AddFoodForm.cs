using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class AddFoodForm : Form, IAddFoodView
    {
        public AddFoodForm()
        {
            InitializeComponent();

            // Create Food Item Panel
            FoodItemView = new FoodItemView();
            FoodItemView.AutoSize = true;
            FoodItemView.Location = new System.Drawing.Point(1, 69);
            FoodItemView.TabIndex = 0;

            Controls.Add(this.FoodItemView);
        }

        public FoodItemView FoodItemView { get; private set; }

        public event EventHandler AddFoodClick
        {
            add { btnAddFood.Click += value; }
            remove { btnAddFood.Click -= value; }
        }

        public event EventHandler CancelClick
        {
            add { btnCancel.Click += value; }
            remove { btnCancel.Click -= value; }
        }
    }
}
