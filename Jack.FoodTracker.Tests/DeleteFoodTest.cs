﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jack.FoodTracker.EntityDatabase;
using Jack.FoodTracker.Entities;
using Jack.FoodTracker;

namespace Jack.FoodTracker.Tests
{
    [TestClass]
    public class DeleteFoodTest : TestData
    {
        [TestMethod]
        public void SuccessfulRemove()
        {
            Exception ex = null;

            

            Food food = new Food("Bacon", null, "Meat", 1, 2, 3, 4, 5);

            foodRepository.foods.Add(food);

            try
            {
                ftracker.DeleteFood(food);

            }
            catch (Exception aex)
            {
                ex = aex;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void RemoveOnEmpty()
        {
            Exception ex = null;

            Food food = null;

            try
            {
                ftracker.DeleteFood(food);

            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.AreEqual(ex.Message,"This food does not exist, hence can't be deleted.");
        }

        [TestMethod]
        public void RemoveNonExistantFood()
        {
            Exception ex = null;

            Food food = new Food("Bacon", null, "Meat", 1, 2, 3, 4, 5);
            Food food2 = new Food("Beef", null, "Meat", 2, 6, 3, 6, 1);

            foodRepository.foods.Add(food);

            try
            {
                ftracker.DeleteFood(food2);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.AreEqual(ex.Message, "This food does not exist, hence can't be deleted.");
        }
    }
}
