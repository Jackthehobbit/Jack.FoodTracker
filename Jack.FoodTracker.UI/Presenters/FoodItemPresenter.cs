using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    class FoodItemPresenter
    {
        private readonly IFoodItemView FoodItemView;

        public FoodItemPresenter(IFoodItemView foodItemView, IList<FoodCategory> foodCategories)
        {
            FoodItemView = foodItemView;
            FoodItemView.Categories = foodCategories;
        }

        public FoodDTO GetInputs()
        {
            return new FoodDTO()
            {
                Name = FoodItemView.FoodName,
                Category = FoodItemView.Category,
                Description = FoodItemView.Description,
                Calories = FoodItemView.Calories,
                Sugar = FoodItemView.Sugar,
                Fat = FoodItemView.Fat,
                Saturates = FoodItemView.SatFat,
                Salt = FoodItemView.Salt
            };
        }

        public void SetInputs(Food food)
        {
            FoodItemView.FoodName = food.Name;
            FoodItemView.Description = food.Description;
            FoodItemView.Category = food.Category;
            FoodItemView.Calories = "" + food.Calories;
            FoodItemView.Sugar = "" + food.Sugars;
            FoodItemView.Fat = "" + food.Fat;
            FoodItemView.SatFat = "" + food.Saturates;
            FoodItemView.Salt = "" + food.Salt;
        }

        public void ClearInputs()
        {
            FoodItemView.FoodName = "";
            FoodItemView.CategoryIndex = -1;
            FoodItemView.Description = "";
            FoodItemView.Calories = "";
            FoodItemView.Sugar = "";
            FoodItemView.Fat = "";
            FoodItemView.SatFat = "";
            FoodItemView.Salt = "";
        }

        public string GetName()
        {
            return FoodItemView.FoodName;
        }

        public FoodCategory GetSelectedCategory()
        {
            return FoodItemView.Category;
        }

        public bool ViewEnabled
        {
            get { return FoodItemView.Enabled; }
            set { FoodItemView.Enabled = value; }
        }
    }
}
