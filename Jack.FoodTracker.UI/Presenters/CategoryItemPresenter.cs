using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    class CategoryItemPresenter
    {
        ICategoryItemView CategoryItemView;

        public CategoryItemPresenter(ICategoryItemView categoryItemView)
        {
            CategoryItemView = categoryItemView;
        }

        public void Set(FoodCategory category)
        {
            CategoryItemView.CategoryName = category.Name;
        }

        public void Reset()
        {
            CategoryItemView.CategoryName = "";
        }

        public string Name
        {
            get { return CategoryItemView.CategoryName; }
        }

        public bool Enabled
        {
            get { return CategoryItemView.Enabled; }
            set { CategoryItemView.Enabled = value; }
        }
    }
}
