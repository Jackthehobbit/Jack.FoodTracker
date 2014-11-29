namespace Jack.FoodTracker
{
    partial class CategoryLookupView
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
            this.lAddFood = new System.Windows.Forms.Label();
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lAddFood
            // 
            this.lAddFood.Dock = System.Windows.Forms.DockStyle.Top;
            this.lAddFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAddFood.Location = new System.Drawing.Point(0, 0);
            this.lAddFood.Name = "lAddFood";
            this.lAddFood.Size = new System.Drawing.Size(218, 24);
            this.lAddFood.TabIndex = 3;
            this.lAddFood.Text = "Categories";
            this.lAddFood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCategories
            // 
            this.lbCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategories.DisplayMember = "Name";
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.Location = new System.Drawing.Point(3, 36);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(210, 251);
            this.lbCategories.TabIndex = 2;
            // 
            // CategoryLookupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lAddFood);
            this.Controls.Add(this.lbCategories);
            this.Name = "CategoryLookupView";
            this.Size = new System.Drawing.Size(218, 291);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lAddFood;
        private System.Windows.Forms.ListBox lbCategories;
    }
}
