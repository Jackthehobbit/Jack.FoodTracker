﻿using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext context;

        public FoodRepository(FoodContext context)
        {
            this.context = context;
        }

        public void Add(Food newFood)
        {
            context.Foods.Add(newFood);
            context.SaveChanges();
        }

        public IList<Food> GetAll()
        {
            return context.Foods.ToList();
        }
    }
}
