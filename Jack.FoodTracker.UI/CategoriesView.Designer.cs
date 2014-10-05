namespace Jack.FoodTracker
{
    partial class CategoriesView
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
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.lAddFood = new System.Windows.Forms.Label();
            this.tbEditCatName = new System.Windows.Forms.TextBox();
            this.tbAddCatName = new System.Windows.Forms.TextBox();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnCategoryMoveUp = new System.Windows.Forms.Button();
            this.btnCategoryMoveDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCategories
            // 
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.Location = new System.Drawing.Point(34, 97);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(210, 368);
            this.lbCategories.TabIndex = 0;
            this.lbCategories.SelectedIndexChanged += new System.EventHandler(this.OnCategorySelectedIndexChanged);
            // 
            // lAddFood
            // 
            this.lAddFood.AutoSize = true;
            this.lAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAddFood.Location = new System.Drawing.Point(88, 57);
            this.lAddFood.Name = "lAddFood";
            this.lAddFood.Size = new System.Drawing.Size(100, 24);
            this.lAddFood.TabIndex = 1;
            this.lAddFood.Text = "Categories";
            // 
            // tbEditCatName
            // 
            this.tbEditCatName.Location = new System.Drawing.Point(323, 97);
            this.tbEditCatName.Name = "tbEditCatName";
            this.tbEditCatName.Size = new System.Drawing.Size(171, 20);
            this.tbEditCatName.TabIndex = 2;
            // 
            // tbAddCatName
            // 
            this.tbAddCatName.Location = new System.Drawing.Point(334, 422);
            this.tbAddCatName.Name = "tbAddCatName";
            this.tbAddCatName.Size = new System.Drawing.Size(139, 20);
            this.tbAddCatName.TabIndex = 3;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(481, 420);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(101, 23);
            this.btnAddCategory.TabIndex = 4;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.OnAddCategoriesButtonClick);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Location = new System.Drawing.Point(507, 97);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(75, 23);
            this.btnEditCategory.TabIndex = 5;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.OnEditCategoryButtonClick);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Location = new System.Drawing.Point(598, 97);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCategory.TabIndex = 6;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.OnDeleteCategoryButtonClick);
            // 
            // btnCategoryMoveUp
            // 
            this.btnCategoryMoveUp.Location = new System.Drawing.Point(323, 243);
            this.btnCategoryMoveUp.Name = "btnCategoryMoveUp";
            this.btnCategoryMoveUp.Size = new System.Drawing.Size(30, 30);
            this.btnCategoryMoveUp.TabIndex = 7;
            this.btnCategoryMoveUp.Text = "^";
            this.btnCategoryMoveUp.UseVisualStyleBackColor = true;
            this.btnCategoryMoveUp.Click += new System.EventHandler(this.OnCategoryMoveUpButtonClick);
            // 
            // btnCategoryMoveDown
            // 
            this.btnCategoryMoveDown.Location = new System.Drawing.Point(403, 218);
            this.btnCategoryMoveDown.Name = "btnCategoryMoveDown";
            this.btnCategoryMoveDown.Size = new System.Drawing.Size(30, 30);
            this.btnCategoryMoveDown.TabIndex = 8;
            this.btnCategoryMoveDown.Text = "V";
            this.btnCategoryMoveDown.UseVisualStyleBackColor = true;
            this.btnCategoryMoveDown.Click += new System.EventHandler(this.OnCategoryMoveDownButtonClick);
            // 
            // CategoriesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCategoryMoveDown);
            this.Controls.Add(this.btnCategoryMoveUp);
            this.Controls.Add(this.btnDeleteCategory);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.tbAddCatName);
            this.Controls.Add(this.tbEditCatName);
            this.Controls.Add(this.lAddFood);
            this.Controls.Add(this.lbCategories);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "CategoriesView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCategories;
        private System.Windows.Forms.Label lAddFood;
        private System.Windows.Forms.TextBox tbEditCatName;
        private System.Windows.Forms.TextBox tbAddCatName;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnCategoryMoveUp;
        private System.Windows.Forms.Button btnCategoryMoveDown;
    }
}
