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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(335, 140);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(75, 23);
            this.btnEditCategory.TabIndex = 5;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(438, 140);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategory.TabIndex = 6;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            // 
            // btnCategoryMoveUp
            // 
            this.btnCategoryMoveUp.Image = global::Jack.FoodTracker.Properties.Resources.ArrowUp;
            this.btnCategoryMoveUp.Location = new System.Drawing.Point(331, 185);
            this.btnCategoryMoveUp.Name = "btnCategoryMoveUp";
            this.btnCategoryMoveUp.Size = new System.Drawing.Size(79, 71);
            this.btnCategoryMoveUp.TabIndex = 7;
            this.btnCategoryMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnCategoryMoveDown
            // 
            this.btnCategoryMoveDown.Image = global::Jack.FoodTracker.Properties.Resources.Downarrow;
            this.btnCategoryMoveDown.Location = new System.Drawing.Point(438, 185);
            this.btnCategoryMoveDown.Name = "btnCategoryMoveDown";
            this.btnCategoryMoveDown.Size = new System.Drawing.Size(79, 71);
            this.btnCategoryMoveDown.TabIndex = 8;
            this.btnCategoryMoveDown.UseVisualStyleBackColor = true;
            // 
            // addCategoryView
            // 
            this.addCategoryView.CategoryName = "";
            this.addCategoryView.Location = new System.Drawing.Point(331, 283);
            this.addCategoryView.Name = "addCategoryView";
            this.addCategoryView.Size = new System.Drawing.Size(254, 28);
            this.addCategoryView.TabIndex = 9;
            // 
            // categoryItemView
            // 
            this.categoryItemView.CategoryName = "";
            this.categoryItemView.Enabled = false;
            this.categoryItemView.Location = new System.Drawing.Point(289, 106);
            this.categoryItemView.Name = "categoryItemView";
            this.categoryItemView.Size = new System.Drawing.Size(224, 28);
            this.categoryItemView.TabIndex = 10;
            // 
            // categoryLookupView
            // 
            this.categoryLookupView.Categories = null;
            this.categoryLookupView.Location = new System.Drawing.Point(19, 71);
            this.categoryLookupView.Name = "categoryLookupView";
            this.categoryLookupView.SelectedCategory = null;
            this.categoryLookupView.SelectedCategoryIndex = -1;
            this.categoryLookupView.Size = new System.Drawing.Size(218, 405);
            this.categoryLookupView.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Categories";
            // 
            // CategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addCategoryView);
            this.Controls.Add(this.categoryLookupView);
            this.Controls.Add(this.categoryItemView);
            this.Controls.Add(this.btnCategoryMoveDown);
            this.Controls.Add(this.btnCategoryMoveUp);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnEditCategory);
            this.Name = "CategoryView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnCategoryMoveUp;
        private System.Windows.Forms.Button btnCategoryMoveDown;
        private AddCategoryView addCategoryView;
        private CategoryItemView categoryItemView;
        private CategoryLookupView categoryLookupView;
        private System.Windows.Forms.Label label1;
    }
}
