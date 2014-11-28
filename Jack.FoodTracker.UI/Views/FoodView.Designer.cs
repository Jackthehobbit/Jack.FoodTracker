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
            this.btnEditFood = new System.Windows.Forms.Button();
            this.foodSearchView = new Jack.FoodTracker.FoodSearchView();
            this.foodItemView = new Jack.FoodTracker.FoodItemView();
            this.foodLookupView = new Jack.FoodTracker.FoodLookupView();
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
            // 
            // foodSearchView
            // 
            this.foodSearchView.Location = new System.Drawing.Point(149, 51);
            this.foodSearchView.Name = "foodSearchView";
            this.foodSearchView.Size = new System.Drawing.Size(460, 29);
            this.foodSearchView.TabIndex = 23;
            // 
            // foodItemView
            // 
            this.foodItemView.Calories = "";
            this.foodItemView.Category = null;
            this.foodItemView.CategoryIndex = -1;
            this.foodItemView.Description = "";
            this.foodItemView.Enabled = false;
            this.foodItemView.Fat = "";
            this.foodItemView.FoodName = "";
            this.foodItemView.Location = new System.Drawing.Point(428, 117);
            this.foodItemView.Name = "foodItemView";
            this.foodItemView.Salt = "";
            this.foodItemView.SatFat = "";
            this.foodItemView.Size = new System.Drawing.Size(255, 256);
            this.foodItemView.Sugar = "";
            this.foodItemView.TabIndex = 24;
            // 
            // foodLookupView
            // 
            this.foodLookupView.Location = new System.Drawing.Point(55, 117);
            this.foodLookupView.Name = "foodLookupView";
            this.foodLookupView.SelectedFood = null;
            this.foodLookupView.SelectedFoodIndex = -1;
            this.foodLookupView.Size = new System.Drawing.Size(262, 255);
            this.foodLookupView.TabIndex = 25;
            // 
            // FoodView
            // 
            this.Controls.Add(this.foodLookupView);
            this.Controls.Add(this.foodItemView);
            this.Controls.Add(this.foodSearchView);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.lTitle);
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
        private Label lTitle;
        private FoodSearchView foodSearchView;
        private FoodLookupView foodLookupView;
    }
}
