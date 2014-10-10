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
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnDeleteFood = new System.Windows.Forms.Button();
            this.lTitle = new System.Windows.Forms.Label();
            this.lFoodItem = new System.Windows.Forms.Label();
            this.btnEditFood = new System.Windows.Forms.Button();
            this.foodSearchView = new Jack.FoodTracker.FoodSearchView();
            this.SuspendLayout();
            // 
            // btnAddFood
            // 
            this.btnAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFood.Location = new System.Drawing.Point(99, 409);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(75, 23);
            this.btnAddFood.TabIndex = 22;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.OnAddFoodButtonClick);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.Enabled = false;
            this.btnDeleteFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFood.Location = new System.Drawing.Point(567, 409);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFood.TabIndex = 15;
            this.btnDeleteFood.Text = "Delete";
            this.btnDeleteFood.UseVisualStyleBackColor = true;
            this.btnDeleteFood.Click += new System.EventHandler(this.OnDeleteFoodButtonClick);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(356, 5);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(76, 31);
            this.lTitle.TabIndex = 12;
            this.lTitle.Text = "Food";
            // 
            // lFoodItem
            // 
            this.lFoodItem.AutoSize = true;
            this.lFoodItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFoodItem.Location = new System.Drawing.Point(538, 136);
            this.lFoodItem.Name = "lFoodItem";
            this.lFoodItem.Size = new System.Drawing.Size(95, 24);
            this.lFoodItem.TabIndex = 9;
            this.lFoodItem.Text = "Food Item";
            // 
            // btnEditFood
            // 
            this.btnEditFood.Enabled = false;
            this.btnEditFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFood.Location = new System.Drawing.Point(486, 409);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Size = new System.Drawing.Size(75, 23);
            this.btnEditFood.TabIndex = 8;
            this.btnEditFood.Text = "Edit";
            this.btnEditFood.UseVisualStyleBackColor = true;
            this.btnEditFood.Click += new System.EventHandler(this.OnEditFoodButtonClick);
            // 
            // foodSearchView
            // 
            this.foodSearchView.Location = new System.Drawing.Point(149, 51);
            this.foodSearchView.Name = "foodSearchView";
            this.foodSearchView.Size = new System.Drawing.Size(460, 29);
            this.foodSearchView.TabIndex = 23;
            // 
            // FoodView
            // 
            this.Controls.Add(this.foodSearchView);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lFoodItem);
            this.Controls.Add(this.btnEditFood);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FoodView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnDeleteFood;
        private System.Windows.Forms.Button btnEditFood;
        private System.Windows.Forms.Button btnAddFood;
        private FoodItemView foodItemView;
        private FoodLookupView foodLookupView;
        private Label lTitle;
        private Label lFoodItem;
        private FoodSearchView foodSearchView;
    }
}
