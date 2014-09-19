using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    partial class FoodItemPanel
    {
        private void InitializeComponent()
        {

            this.tbSalt = new System.Windows.Forms.TextBox();
            this.tbSatFat = new System.Windows.Forms.TextBox();
            this.tbFat = new System.Windows.Forms.TextBox();
            this.tbSugar = new System.Windows.Forms.TextBox();
            this.tbCalories = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            Label lSalt = new System.Windows.Forms.Label();
            Label lSatFat = new System.Windows.Forms.Label();
            Label lFat = new System.Windows.Forms.Label();
            Label lSugar = new System.Windows.Forms.Label();
            Label lCalories = new System.Windows.Forms.Label();
            Label lDesc = new System.Windows.Forms.Label();
            Label lName = new System.Windows.Forms.Label();
            Label lCategory = new System.Windows.Forms.Label();

            this.Controls.Add(lSalt);
            this.Controls.Add(lSatFat);
            this.Controls.Add(lFat);
            this.Controls.Add(lSugar);
            this.Controls.Add(lCalories);
            this.Controls.Add(lDesc);
            this.Controls.Add(lName);
            this.Controls.Add(this.tbSalt);
            this.Controls.Add(this.tbSatFat);
            this.Controls.Add(this.tbFat);
            this.Controls.Add(this.tbSugar);
            this.Controls.Add(this.tbCalories);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbName);
            this.Controls.Add(lCategory);
            this.Controls.Add(cbCategory);

            this.SuspendLayout();

            int topLeftX = 0;
            int topLeftY = 0;

            // 
            // tbSalt
            // 
            this.tbSalt.Enabled = false;
            this.tbSalt.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 182);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(150, 20);
            this.tbSalt.TabIndex = 6;
            // 
            // tbSatFat
            // 
            this.tbSatFat.Enabled = false;
            this.tbSatFat.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 157);
            this.tbSatFat.Name = "tbSatFat";
            this.tbSatFat.Size = new System.Drawing.Size(150, 20);
            this.tbSatFat.TabIndex = 5;
            // 
            // tbFat
            // 
            this.tbFat.Enabled = false;
            this.tbFat.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 130);
            this.tbFat.Name = "tbFat";
            this.tbFat.Size = new System.Drawing.Size(150, 20);
            this.tbFat.TabIndex = 4;
            // 
            // tbSugar
            // 
            this.tbSugar.Enabled = false;
            this.tbSugar.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 103);
            this.tbSugar.Name = "tbSugar";
            this.tbSugar.Size = new System.Drawing.Size(150, 20);
            this.tbSugar.TabIndex = 3;
            // 
            // tbCalories
            // 
            this.tbCalories.Enabled = false;
            this.tbCalories.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 77);
            this.tbCalories.Name = "tbCalories";
            this.tbCalories.Size = new System.Drawing.Size(150, 20);
            this.tbCalories.TabIndex = 2;
            // 
            // tbDesc
            // 
            this.tbDesc.Enabled = false;
            this.tbDesc.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 51);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(150, 20);
            this.tbDesc.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(topLeftX + 102, topLeftY);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 0;

            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Enabled = false;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(topLeftX + 102, topLeftY + 25);
            this.cbCategory.Name = "cbCategoryEdit";
            this.cbCategory.Size = new System.Drawing.Size(150, 21);
            this.cbCategory.TabIndex = 18;

            //label8
            lCategory.AutoSize = true;
            lCategory.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCategory.Location = new System.Drawing.Point(topLeftX + 39, topLeftY + 27);
            lCategory.Name = "label13";
            lCategory.Size = new System.Drawing.Size(57, 15);
            lCategory.TabIndex = 19;
            lCategory.Text = "Category:";

            // 
            // label7
            // 
            lSalt.AutoSize = true;
            lSalt.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lSalt.Location = new System.Drawing.Point(topLeftX + 51, topLeftY + 184);
            lSalt.Name = "label7";
            lSalt.Size = new System.Drawing.Size(44, 15);
            lSalt.TabIndex = 7;
            lSalt.Text = "Salt(g):";
            // 
            // label6
            // 
            lSatFat.AutoSize = true;
            lSatFat.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lSatFat.Location = new System.Drawing.Point(topLeftX, topLeftY + 159);
            lSatFat.Name = "label6";
            lSatFat.Size = new System.Drawing.Size(95, 15);
            lSatFat.TabIndex = 6;
            lSatFat.Text = "Saturated Fat(g):";
            // 
            // label5
            // 
            lFat.AutoSize = true;
            lFat.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lFat.Location = new System.Drawing.Point(topLeftX + 54, topLeftY + 132);
            lFat.Name = "label5";
            lFat.Size = new System.Drawing.Size(41, 15);
            lFat.TabIndex = 5;
            lFat.Text = "Fat(g):";
            // 
            // label4
            // 
            lSugar.AutoSize = true;
            lSugar.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lSugar.Location = new System.Drawing.Point(topLeftX + 41, topLeftY + 105);
            lSugar.Name = "label4";
            lSugar.Size = new System.Drawing.Size(55, 15);
            lSugar.TabIndex = 4;
            lSugar.Text = "Sugar(g):";
            // 
            // label3
            // 
            lCalories.AutoSize = true;
            lCalories.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCalories.Location = new System.Drawing.Point(topLeftX + 44, topLeftY + 79);
            lCalories.Name = "label3";
            lCalories.Size = new System.Drawing.Size(52, 15);
            lCalories.TabIndex = 3;
            lCalories.Text = "Calories:";
            // 
            // label2
            // 
            lDesc.AutoSize = true;
            lDesc.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lDesc.Location = new System.Drawing.Point(topLeftX + 28, topLeftY + 53);
            lDesc.Name = "label2";
            lDesc.Size = new System.Drawing.Size(68, 15);
            lDesc.TabIndex = 2;
            lDesc.Text = "Description:";
            // 
            // label1
            // 
            lName.AutoSize = true;
            lName.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lName.Location = new System.Drawing.Point(topLeftX + 53, topLeftY + 2);
            lName.Name = "label1";
            lName.Size = new System.Drawing.Size(41, 15);
            lName.TabIndex = 1;
            lName.Text = "Name:";

            this.Name = "MainForm";

            this.ResumeLayout(false);
        }
    }
}
