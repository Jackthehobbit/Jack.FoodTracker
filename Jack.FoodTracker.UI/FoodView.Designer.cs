using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    partial class FoodView
    {
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            Label lTitle = new System.Windows.Forms.Label();
            Label lSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            Label lFoodItem = new System.Windows.Forms.Label();
            this.btnEditFood = new System.Windows.Forms.Button();

            Controls.Add(this.btnSearch);
            Controls.Add(this.btnAddFood);
            Controls.Add(this.btnDeleteFood);
            Controls.Add(lTitle);
            Controls.Add(lSearch);
            Controls.Add(this.tbSearch);
            Controls.Add(lFoodItem);
            Controls.Add(this.btnEditFood);
            

            this.SuspendLayout();

            int topLeftY = 5;
            int topLeftX = 46;

            //btnSearch
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(597, topLeftY + 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;

            //btnAddFood
            this.btnAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(271, topLeftY + 404);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(75, 23);
            this.btnAddFood.TabIndex = 22;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.OnAddFoodButtonClick);

            //btnDeleteFood
            this.btnDeleteFood.Enabled = false;
            this.btnDeleteFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFood.Location = new System.Drawing.Point(597, topLeftY + 404);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFood.TabIndex = 15;
            this.btnDeleteFood.Text = "Delete";
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.OnDeleteFoodButtonClick);

            //lTitle
            lTitle.AutoSize = true;
            lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lTitle.Location = new System.Drawing.Point(356, topLeftY);
            lTitle.Name = "label10";
            lTitle.Size = new System.Drawing.Size(76, 31);
            lTitle.TabIndex = 12;
            lTitle.Text = "Food";

            //lSearch
            lSearch.AutoSize = true;
            lSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lSearch.Location = new System.Drawing.Point(135, topLeftY + 51);
            lSearch.Name = "label9";
            lSearch.Size = new System.Drawing.Size(57, 17);
            lSearch.TabIndex = 11;
            lSearch.Text = "Search:";

            //tbSearch
            this.tbSearch.Location = new System.Drawing.Point(198, topLeftY + 49);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(393, 20);
            this.tbSearch.TabIndex = 10;
            this.tbSearch.TextChanged += new System.EventHandler(this.SearchBarTextChanged);

            //lFoodItem
            lFoodItem.AutoSize = true;
            lFoodItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lFoodItem.Location = new System.Drawing.Point(547, topLeftY + 127);
            lFoodItem.Name = "label8";
            lFoodItem.Size = new System.Drawing.Size(95, 24);
            lFoodItem.TabIndex = 9;
            lFoodItem.Text = "Food Item";

            //btnEditFood
            this.btnEditFood.Enabled = false;
            this.btnEditFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFood.Location = new System.Drawing.Point(518, topLeftY + 404);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Size = new System.Drawing.Size(75, 23);
            this.btnEditFood.TabIndex = 8;
            this.btnEditFood.Text = "Edit";
            this.btnEditFood.UseVisualStyleBackColor = true;
            this.btnEditFood.Click += new System.EventHandler(this.OnEditFoodButtonClick);

            this.Name = "Food Panel";

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnEditFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnSearch;
        private FoodItemView pnlFoodItem;
        private FoodLookupView pnlFoodLookup;
    }
}
