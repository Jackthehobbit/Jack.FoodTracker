﻿using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
namespace Jack.FoodTracker.EntityDatabase
{
    public interface IFoodCategoryRepository
    {
        List<FoodCategory> GetAll();

        void Add(FoodCategory foodCategory);

        void Edit(FoodCategory foodCategory);

        void Delete(FoodCategory foodCategory);
    }
}
