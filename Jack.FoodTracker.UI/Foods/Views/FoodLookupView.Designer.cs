using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    partial class FoodLookupView
    {

        private void InitializeComponent()
        {
            this.lFood = new System.Windows.Forms.Label();
            this.lbFood = new System.Windows.Forms.ListBox();
            this.categoryLookupView = new Jack.FoodTracker.CategoryLookupView();
            this.SuspendLayout();
            // 
            // lFood
            // 
            this.lFood.AutoSize = true;
            this.lFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFood.Location = new System.Drawing.Point(162, 0);
            this.lFood.Name = "lFood";
            this.lFood.Size = new System.Drawing.Size(55, 24);
            this.lFood.TabIndex = 1;
            this.lFood.Text = "Food";
            // 
            // lbFood
            // 
            this.lbFood.DisplayMember = "Name";
            this.lbFood.FormattingEnabled = true;
            this.lbFood.Location = new System.Drawing.Point(129, 36);
            this.lbFood.Name = "lbFood";
            this.lbFood.Size = new System.Drawing.Size(120, 212);
            this.lbFood.TabIndex = 1;
            // 
            // categoryLookupView
            // 
            this.categoryLookupView.Categories = null;
            this.categoryLookupView.Location = new System.Drawing.Point(9, 0);
            this.categoryLookupView.Name = "categoryLookupView";
            this.categoryLookupView.SelectedCategory = null;
            this.categoryLookupView.SelectedCategoryIndex = -1;
            this.categoryLookupView.Size = new System.Drawing.Size(114, 263);
            this.categoryLookupView.TabIndex = 2;
            // 
            // FoodLookupView
            // 
            this.Controls.Add(this.categoryLookupView);
            this.Controls.Add(this.lFood);
            this.Controls.Add(this.lbFood);
            this.Name = "FoodLookupView";
            this.Size = new System.Drawing.Size(262, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Label lFood;
        private CategoryLookupView categoryLookupView;
    }
}
