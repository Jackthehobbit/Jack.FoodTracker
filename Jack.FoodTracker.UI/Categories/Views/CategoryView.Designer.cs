namespace Jack.FoodTracker
{
    partial class CategoryView
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
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnCategoryMoveUp = new System.Windows.Forms.Button();
            this.btnCategoryMoveDown = new System.Windows.Forms.Button();
            this.addCategoryView = new Jack.FoodTracker.AddCategoryView();
            this.categoryItemView = new Jack.FoodTracker.CategoryItemView();
            this.categoryLookupView = new Jack.FoodTracker.CategoryLookupView();
            this.SuspendLayout();
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(227, 80);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(75, 23);
            this.btnEditCategory.TabIndex = 5;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(308, 80);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategory.TabIndex = 6;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // btnCategoryMoveUp
            // 
            this.btnCategoryMoveUp.Location = new System.Drawing.Point(227, 109);
            this.btnCategoryMoveUp.Name = "btnCategoryMoveUp";
            this.btnCategoryMoveUp.Size = new System.Drawing.Size(30, 30);
            this.btnCategoryMoveUp.TabIndex = 7;
            this.btnCategoryMoveUp.Text = "^";
            this.btnCategoryMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnCategoryMoveDown
            // 
            this.btnCategoryMoveDown.Location = new System.Drawing.Point(263, 109);
            this.btnCategoryMoveDown.Name = "btnCategoryMoveDown";
            this.btnCategoryMoveDown.Size = new System.Drawing.Size(30, 30);
            this.btnCategoryMoveDown.TabIndex = 8;
            this.btnCategoryMoveDown.Text = "V";
            this.btnCategoryMoveDown.UseVisualStyleBackColor = true;
            // 
            // addCategoryView
            // 
            this.addCategoryView.Location = new System.Drawing.Point(3, 302);
            this.addCategoryView.Size = new System.Drawing.Size(254, 28);
            this.addCategoryView.TabIndex = 9;
            // 
            // categoryItemView
            // 
            this.categoryItemView.Location = new System.Drawing.Point(227, 46);
            this.categoryItemView.Size = new System.Drawing.Size(224, 28);
            this.categoryItemView.TabIndex = 10;
            // 
            // categoryLookupView
            // 
            this.categoryLookupView.Categories = null;
            this.categoryLookupView.Location = new System.Drawing.Point(3, 3);
            this.categoryLookupView.Name = "categoryLookupView";
            this.categoryLookupView.SelectedCategory = null;
            this.categoryLookupView.SelectedCategoryIndex = -1;
            this.categoryLookupView.Size = new System.Drawing.Size(218, 304);
            this.categoryLookupView.TabIndex = 11;
            // 
            // CategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addCategoryView);
            this.Controls.Add(this.categoryLookupView);
            this.Controls.Add(this.categoryItemView);
            this.Controls.Add(this.btnCategoryMoveDown);
            this.Controls.Add(this.btnCategoryMoveUp);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnEditCategory);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CategoryView";
            this.Size = new System.Drawing.Size(829, 420);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnCategoryMoveUp;
        private System.Windows.Forms.Button btnCategoryMoveDown;
        private AddCategoryView addCategoryView;
        private CategoryItemView categoryItemView;
        private CategoryLookupView categoryLookupView;
    }
}
