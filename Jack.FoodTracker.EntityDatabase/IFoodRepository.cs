using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;

namespace Jack.FoodTracker.EntityDatabase
{
    public interface IFoodRepository
    {
        void Add(Food newFood);

        IList<Food> GetAll();

        IList<Food> GetByCategory(FoodCategory fCat);
    }
}
