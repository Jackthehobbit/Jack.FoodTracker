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
            this.lCategory = new System.Windows.Forms.Label();
            this.lFood = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.ListBox();
            this.lbFood = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lCategory
            // 
            this.lCategory.AutoSize = true;
            this.lCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCategory.Location = new System.Drawing.Point(21, 3);
            this.lCategory.Name = "lCategory";
            this.lCategory.Size = new System.Drawing.Size(85, 24);
            this.lCategory.TabIndex = 0;
            this.lCategory.Text = "Category";
            // 
            // lFood
            // 
            this.lFood.AutoSize = true;
            this.lFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFood.Location = new System.Drawing.Point(162, 3);
            this.lFood.Name = "lFood";
            this.lFood.Size = new System.Drawing.Size(55, 24);
            this.lFood.TabIndex = 1;
            this.lFood.Text = "Food";
            // 
            // lbCategory
            // 
            this.lbCategory.DisplayMember = "Name";
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.Location = new System.Drawing.Point(3, 36);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(120, 212);
            this.lbCategory.TabIndex = 0;
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
            // FoodLookupView
            // 
            this.Controls.Add(this.lCategory);
            this.Controls.Add(this.lFood);
            this.Controls.Add(this.lbCategory);
            this.Controls.Add(this.lbFood);
            this.Name = "FoodLookupView";
            this.Size = new System.Drawing.Size(253, 252);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lCategory;
        private Label lFood;
    }
}
