using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
namespace Jack.FoodTracker.EntityDatabase
{
    public interface IFoodCategoryRepository
    {
        List<FoodCategory> GetAll();
    }
}
