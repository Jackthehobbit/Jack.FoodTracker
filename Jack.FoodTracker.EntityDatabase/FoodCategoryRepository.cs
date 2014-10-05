﻿using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{
    public class FoodCategoryRepository : IFoodCategoryRepository
    {
        private readonly FoodContext context;

        public FoodCategoryRepository(FoodContext context)
        {
            this.context = context;
        }

        public List<FoodCategory> GetAll()
        {
            return context.Categories.ToList();
        }

        public void Add(FoodCategory foodCategory)
        {
            context.Categories.Add(foodCategory);
            context.SaveChanges();
        }

        public void Edit(FoodCategory foodCategory)
        {
            context.Entry(foodCategory).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(FoodCategory foodCategory)
        {
            context.Categories.Remove(foodCategory);
            context.SaveChanges();
        }
    }
}
