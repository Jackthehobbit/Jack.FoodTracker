using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jack.FoodTracker.Tests
{
    [TestClass]
    public class AddFoodTest
    {
        [TestMethod]
        public void SuccessfulAdd()
        {
            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "99", "12", "6");

            ftracker.AddFood(dto);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EmptyName()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("", "Filthy Pig", "200", "100", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch(ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "Name is empty.");
        }

        [TestMethod]
        public void CaloriesNotANumber()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "hello", "100", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "Calories is not a whole number.");
        }

        [TestMethod]
        public void SugarNotANumber()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "hello", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "Sugar is not a number.");
        }

        [TestMethod]
        public void FatNotANumber()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "hello", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "Fat is not a number.");
        }

        [TestMethod]
        public void SatFatNotANumber()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "99", "hello", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "Saturated Fats is not a number.");
        }

        [TestMethod]
        public void SaltNotANumber()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "99", "12", "food");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "Salt is not a number.");
        }

        [TestMethod]
        public void FoodAlreadyExists()
        {
            Exception ex = null;

            FoodTracker ftracker = new FoodTracker();

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.Equals(ex.Message, "This food already exists.");
        }

        private FoodDTO helper(string name, string description, string calories, string sugar, string fat, string sats, string salt)
        {
            FoodDTO dto = new FoodDTO();

            dto.Name = name;
            dto.Description = description;
            dto.Calories = calories;
            dto.Sugar = sugar;
            dto.Fat = fat;
            dto.Saturates = sats;
            dto.Salt = salt;

            return dto;
        }
    }
}
