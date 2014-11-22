namespace Jack.FoodTracker
{
    partial class FoodSearchView
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
            this.lSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lSearch
            // 
            this.lSearch.AutoSize = true;
            this.lSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSearch.Location = new System.Drawing.Point(0, 3);
            this.lSearch.Name = "lSearch";
            this.lSearch.Size = new System.Drawing.Size(57, 17);
            this.lSearch.TabIndex = 13;
            this.lSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(63, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(393, 20);
            this.tbSearch.TabIndex = 12;
            // 
            // FoodSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lSearch);
            this.Controls.Add(this.tbSearch);
            this.Name = "FoodSearchView";
            this.Size = new System.Drawing.Size(460, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSearch;
        private System.Windows.Forms.TextBox tbSearch;
    }
}
