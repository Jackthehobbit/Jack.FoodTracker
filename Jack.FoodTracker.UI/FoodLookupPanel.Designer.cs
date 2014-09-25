﻿using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    partial class FoodLookupPanel
    {
        private void InitializeComponent(IList<FoodCategory> cats)
        {
            Label lCategory = new System.Windows.Forms.Label();
            Label lFood = new System.Windows.Forms.Label();
            this.lbCategory = new System.Windows.Forms.ListBox();
            this.lbFood = new System.Windows.Forms.ListBox();

            int topLeftX = 0;
            int topLeftY = 0;

            this.SuspendLayout();

            //lCategory
            lCategory.AutoSize = true;
            lCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCategory.Location = new System.Drawing.Point(topLeftX + 61, topLeftY);
            lCategory.Name = "lCategory";
            lCategory.Size = new System.Drawing.Size(39, 24);
            lCategory.Text = "Category";

            //lFood
            lFood.AutoSize = true;
            lFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lFood.Location = new System.Drawing.Point(topLeftX + 235, topLeftY);
            lFood.Name = "lFood";
            lFood.Size = new System.Drawing.Size(55, 24);
            lFood.Text = "Food";

            //lbCategory
            this.lbCategory.FormattingEnabled = true;
            this.lbCategory.Location = new System.Drawing.Point(topLeftX, topLeftY + 34);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(120, 212);
            this.lbCategory.TabIndex = 0;
            this.lbCategory.DataSource = cats;
            this.lbCategory.DisplayMember = "Name";
            this.lbCategory.SelectedValueChanged += new System.EventHandler(this.lbCategories_SelectedValueChanged);

            //lbFood
            this.lbFood.FormattingEnabled = true;
            this.lbFood.Location = new System.Drawing.Point(topLeftX + 202, topLeftY + 34);
            this.lbFood.Name = "lbFood";
            this.lbFood.Size = new System.Drawing.Size(120, 212);
            this.lbFood.TabIndex = 1;

            this.Controls.Add(lCategory);
            this.Controls.Add(lFood);
            this.Controls.Add(lbCategory);
            this.Controls.Add(lbFood);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
