using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;

namespace Jack.FoodTracker.EntityDatabase
{
    public interface IFoodRepository
    {
        void Add(Food newFood);

        void Edit(Food changedFood);

        void Delete(Food food);

        IList<Food> GetAll();

        IList<Food> GetByCategory(FoodCategory fCat);

        IList<Food> SearchByName(String searchText);
    }
}
