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
            this.lAddFood = new System.Windows.Forms.Label();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.foodItemView = new Jack.FoodTracker.FoodItemView();
            this.SuspendLayout();
            // 
            // lAddFood
            // 
            this.lAddFood.AutoSize = true;
            this.lAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAddFood.Location = new System.Drawing.Point(119, 9);
            this.lAddFood.Name = "lAddFood";
            this.lAddFood.Size = new System.Drawing.Size(95, 24);
            this.lAddFood.TabIndex = 0;
            this.lAddFood.Text = "Add Food";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(73, 296);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(75, 23);
            this.btnAddFood.TabIndex = 1;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(183, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // foodItemView
            // 
            this.foodItemView.Calories = "";
            this.foodItemView.Category = null;
            this.foodItemView.CategoryIndex = -1;
            this.foodItemView.Description = "";
            this.foodItemView.Fat = "";
            this.foodItemView.FoodName = "";
            this.foodItemView.Location = new System.Drawing.Point(11, 36);
            this.foodItemView.Name = "foodItemView";
            this.foodItemView.Salt = "";
            this.foodItemView.SatFat = "";
            this.foodItemView.Size = new System.Drawing.Size(255, 256);
            this.foodItemView.Sugar = "";
            this.foodItemView.TabIndex = 3;
            // 
            // AddFoodForm
            // 
            this.AcceptButton = this.btnAddFood;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(332, 335);
            this.Controls.Add(this.foodItemView);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lAddFood);
            this.Controls.Add(this.btnAddFood);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFoodForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Food";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lAddFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Button btnCancel;
        private FoodItemView foodItemView;
    }
}