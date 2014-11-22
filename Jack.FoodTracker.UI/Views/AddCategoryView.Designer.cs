namespace Jack.FoodTracker
{
    partial class AddCategoryView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.tbAddCatName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(150, 1);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(101, 23);
            this.btnAddCategory.TabIndex = 6;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // tbAddCatName
            // 
            this.tbAddCatName.Location = new System.Drawing.Point(3, 3);
            this.tbAddCatName.Name = "tbAddCatName";
            this.tbAddCatName.Size = new System.Drawing.Size(139, 20);
            this.tbAddCatName.TabIndex = 5;
            // 
            // AddCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.tbAddCatName);
            this.Name = "AddCategoryView";
            this.Size = new System.Drawing.Size(254, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.TextBox tbAddCatName;
    }
}
