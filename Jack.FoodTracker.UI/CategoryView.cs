using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jack.FoodTracker;
using Jack.FoodTracker.Entities;

namespace Jack.FoodTracker
{
    public partial class CategoryView : RightView, ICategoryView
    {
        public CategoryView()
        {
            InitializeComponent();
        }

        public IAddCategoryView AddCategoryView
        {
            get { return addCategoryView; }
        }

        public ICategoryLookupView CategoryLookupView
        {
            get { return categoryLookupView; }
        }

        public ICategoryItemView CategoryItemView
        {
            get { return categoryItemView; }
        }

        public bool EditButtonEnabled
        {
            get { return btnEditCategory.Enabled; }
            set { btnEditCategory.Enabled = value; }
        }

        public bool DeleteButtonEnabled
        {
            get { return btnDeleteCategory.Enabled; }
            set { btnDeleteCategory.Enabled = value; }
        }

        public bool MoveUpButtonEnabled
        {
            get { return btnCategoryMoveUp.Enabled; }
            set { btnCategoryMoveUp.Enabled = value; }
        }

        public bool MoveDownButtonEnabled
        {
            get { return btnCategoryMoveDown.Enabled; }
            set { btnCategoryMoveDown.Enabled = value; }
        }

        public string EditButtonText
        {
            get { return btnEditCategory.Text; }
            set { btnEditCategory.Text = value; }
        }
        public string DeleteButtonText
        {
            get { return btnDeleteCategory.Text; }
            set { btnDeleteCategory.Text = value; }
        }

        public event EventHandler EditButtonClick
        {
            add { btnEditCategory.Click += value; }
            remove { btnEditCategory.Click -= value; }
        }

        public event EventHandler DeleteButtonClick
        {
            add { btnDeleteCategory.Click += value; }
            remove { btnDeleteCategory.Click -= value; }
        }

        public event EventHandler MoveUpButtonClick
        {
            add { btnCategoryMoveUp.Click += value; }
            remove { btnCategoryMoveUp.Click -= value; }
        }

        public event EventHandler MoveDownButtonClick
        {
            add { btnCategoryMoveDown.Click += value; }
            remove { btnCategoryMoveDown.Click -= value; }
        }
    }
}
