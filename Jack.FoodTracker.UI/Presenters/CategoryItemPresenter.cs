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

        public CategoryDTO GetInputs()
        {
            return new CategoryDTO()
            {
                Name = CategoryItemView.CategoryName
            };
        }

        public bool Enabled
        {
            get { return CategoryItemView.Enabled; }
            set { CategoryItemView.Enabled = value; }
        }
    }
}
