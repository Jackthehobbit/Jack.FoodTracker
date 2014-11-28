using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    partial class FoodItemView
    {
        private void InitializeComponent()
        {
            this.lName = new System.Windows.Forms.Label();
            this.lDesc = new System.Windows.Forms.Label();
            this.lCategory = new System.Windows.Forms.Label();
            this.lCalories = new System.Windows.Forms.Label();
            this.lSugar = new System.Windows.Forms.Label();
            this.lFat = new System.Windows.Forms.Label();
            this.lSatFat = new System.Windows.Forms.Label();
            this.lSalt = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.tbCalories = new System.Windows.Forms.TextBox();
            this.tbSugar = new System.Windows.Forms.TextBox();
            this.tbFat = new System.Windows.Forms.TextBox();
            this.tbSatFat = new System.Windows.Forms.TextBox();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.lFoodItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(52, 45);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name:";
            // 
            // lDesc
            // 
            this.lDesc.AutoSize = true;
            this.lDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDesc.Location = new System.Drawing.Point(27, 71);
            this.lDesc.Name = "lDesc";
            this.lDesc.Size = new System.Drawing.Size(63, 13);
            this.lDesc.TabIndex = 1;
            this.lDesc.Text = "Description:";
            // 
            // lCategory
            // 
            this.lCategory.AutoSize = true;
            this.lCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCategory.Location = new System.Drawing.Point(38, 97);
            this.lCategory.Name = "lCategory";
            this.lCategory.Size = new System.Drawing.Size(52, 13);
            this.lCategory.TabIndex = 2;
            this.lCategory.Text = "Category:";
            // 
            // lCalories
            // 
            this.lCalories.AutoSize = true;
            this.lCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCalories.Location = new System.Drawing.Point(43, 124);
            this.lCalories.Name = "lCalories";
            this.lCalories.Size = new System.Drawing.Size(47, 13);
            this.lCalories.TabIndex = 3;
            this.lCalories.Text = "Calories:";
            // 
            // lSugar
            // 
            this.lSugar.AutoSize = true;
            this.lSugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSugar.Location = new System.Drawing.Point(40, 150);
            this.lSugar.Name = "lSugar";
            this.lSugar.Size = new System.Drawing.Size(50, 13);
            this.lSugar.TabIndex = 4;
            this.lSugar.Text = "Sugar(g):";
            // 
            // lFat
            // 
            this.lFat.AutoSize = true;
            this.lFat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFat.Location = new System.Drawing.Point(53, 176);
            this.lFat.Name = "lFat";
            this.lFat.Size = new System.Drawing.Size(37, 13);
            this.lFat.TabIndex = 5;
            this.lFat.Text = "Fat(g):";
            // 
            // lSatFat
            // 
            this.lSatFat.AutoSize = true;
            this.lSatFat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSatFat.Location = new System.Drawing.Point(4, 202);
            this.lSatFat.Name = "lSatFat";
            this.lSatFat.Size = new System.Drawing.Size(86, 13);
            this.lSatFat.TabIndex = 6;
            this.lSatFat.Text = "Saturated Fat(g):";
            // 
            // lSalt
            // 
            this.lSalt.AutoSize = true;
            this.lSalt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSalt.Location = new System.Drawing.Point(50, 228);
            this.lSalt.Name = "lSalt";
            this.lSalt.Size = new System.Drawing.Size(40, 13);
            this.lSalt.TabIndex = 7;
            this.lSalt.Text = "Salt(g):";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(96, 41);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 0;
            // 
            // tbDesc
            // 
            this.tbDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbDesc.Location = new System.Drawing.Point(96, 67);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(150, 20);
            this.tbDesc.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.DisplayMember = "Name";
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(96, 93);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(150, 21);
            this.cbCategory.TabIndex = 2;
            // 
            // tbCalories
            // 
            this.tbCalories.Location = new System.Drawing.Point(96, 120);
            this.tbCalories.Name = "tbCalories";
            this.tbCalories.Size = new System.Drawing.Size(150, 20);
            this.tbCalories.TabIndex = 3;
            // 
            // tbSugar
            // 
            this.tbSugar.Location = new System.Drawing.Point(96, 146);
            this.tbSugar.Name = "tbSugar";
            this.tbSugar.Size = new System.Drawing.Size(150, 20);
            this.tbSugar.TabIndex = 4;
            // 
            // tbFat
            // 
            this.tbFat.Location = new System.Drawing.Point(96, 172);
            this.tbFat.Name = "tbFat";
            this.tbFat.Size = new System.Drawing.Size(150, 20);
            this.tbFat.TabIndex = 5;
            // 
            // tbSatFat
            // 
            this.tbSatFat.Location = new System.Drawing.Point(96, 198);
            this.tbSatFat.Name = "tbSatFat";
            this.tbSatFat.Size = new System.Drawing.Size(150, 20);
            this.tbSatFat.TabIndex = 6;
            // 
            // tbSalt
            // 
            this.tbSalt.Location = new System.Drawing.Point(96, 224);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(150, 20);
            this.tbSalt.TabIndex = 7;
            // 
            // lFoodItem
            // 
            this.lFoodItem.AutoSize = true;
            this.lFoodItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFoodItem.Location = new System.Drawing.Point(80, 9);
            this.lFoodItem.Name = "lFoodItem";
            this.lFoodItem.Size = new System.Drawing.Size(95, 24);
            this.lFoodItem.TabIndex = 10;
            this.lFoodItem.Text = "Food Item";
            // 
            // FoodItemView
            // 
            this.Controls.Add(this.lFoodItem);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lDesc);
            this.Controls.Add(this.lCategory);
            this.Controls.Add(this.lCalories);
            this.Controls.Add(this.lSugar);
            this.Controls.Add(this.lFat);
            this.Controls.Add(this.lSatFat);
            this.Controls.Add(this.lSalt);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbCalories);
            this.Controls.Add(this.tbSugar);
            this.Controls.Add(this.tbFat);
            this.Controls.Add(this.tbSatFat);
            this.Controls.Add(this.tbSalt);
            this.Name = "FoodItemView";
            this.Size = new System.Drawing.Size(255, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lName;
        private Label lDesc;
        private Label lCategory;
        private Label lCalories;
        private Label lSugar;
        private Label lFat;
        private Label lSatFat;
        private Label lSalt;
        private Label lFoodItem;
    }
}
