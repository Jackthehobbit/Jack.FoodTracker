namespace Jack.FoodTracker
{
    partial class AddFoodForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.tbSatFat = new System.Windows.Forms.TextBox();
            this.tbFat = new System.Windows.Forms.TextBox();
            this.tbSugar = new System.Windows.Forms.TextBox();
            this.tbCalories = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbCategoryEdit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(254, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Add Food";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(250, 403);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(75, 23);
            this.btnAddFood.TabIndex = 40;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Salt(g):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Saturated Fat(g):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Fat(g):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Sugar(g):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Calories:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Name:";
            // 
            // tbSalt
            // 
            this.tbSalt.Location = new System.Drawing.Point(221, 364);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(150, 20);
            this.tbSalt.TabIndex = 38;
            // 
            // tbSatFat
            // 
            this.tbSatFat.Location = new System.Drawing.Point(221, 338);
            this.tbSatFat.Name = "tbSatFat";
            this.tbSatFat.Size = new System.Drawing.Size(150, 20);
            this.tbSatFat.TabIndex = 36;
            // 
            // tbFat
            // 
            this.tbFat.Location = new System.Drawing.Point(221, 312);
            this.tbFat.Name = "tbFat";
            this.tbFat.Size = new System.Drawing.Size(150, 20);
            this.tbFat.TabIndex = 34;
            // 
            // tbSugar
            // 
            this.tbSugar.Location = new System.Drawing.Point(221, 286);
            this.tbSugar.Name = "tbSugar";
            this.tbSugar.Size = new System.Drawing.Size(150, 20);
            this.tbSugar.TabIndex = 32;
            // 
            // tbCalories
            // 
            this.tbCalories.Location = new System.Drawing.Point(221, 260);
            this.tbCalories.Name = "tbCalories";
            this.tbCalories.Size = new System.Drawing.Size(150, 20);
            this.tbCalories.TabIndex = 30;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(221, 234);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(150, 20);
            this.tbDesc.TabIndex = 28;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(221, 182);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 20);
            this.tbName.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(166, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Category:";
            // 
            // cbCategoryEdit
            // 
            this.cbCategoryEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoryEdit.FormattingEnabled = true;
            this.cbCategoryEdit.Location = new System.Drawing.Point(221, 207);
            this.cbCategoryEdit.Name = "cbCategoryEdit";
            this.cbCategoryEdit.Size = new System.Drawing.Size(150, 21);
            this.cbCategoryEdit.TabIndex = 42;
            // 
            // AddFoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 544);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbCategoryEdit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSalt);
            this.Controls.Add(this.tbSatFat);
            this.Controls.Add(this.tbFat);
            this.Controls.Add(this.tbSugar);
            this.Controls.Add(this.tbCalories);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbName);
            this.Name = "AddFoodForm";
            this.Text = "AddFoodForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSalt;
        private System.Windows.Forms.TextBox tbSatFat;
        private System.Windows.Forms.TextBox tbFat;
        private System.Windows.Forms.TextBox tbSugar;
        private System.Windows.Forms.TextBox tbCalories;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbCategoryEdit;

    }
}