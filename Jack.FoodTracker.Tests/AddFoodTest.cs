using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jack.FoodTracker.EntityDatabase;

namespace Jack.FoodTracker.Tests
{
    [TestClass]
    public class AddFoodTest : TestData
    {
       
        [TestMethod]
        public void SuccessfulAdd()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch(Exception aex)
            {
                ex = aex;
            }
            Console.WriteLine("TESTING!");

            
            Assert.IsNull(ex);
        }
        
        [TestMethod]
        public void EmptyName()
        {
            Exception ex = null;

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
            Assert.AreEqual("Name is empty.", ex.Message);
        }

        [TestMethod]
        public void CaloriesNotANumber()
        {
            Exception ex = null;

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
            Assert.AreEqual("Calories is not a whole number.", ex.Message);
        }

        [TestMethod]
        public void EmptyCalories()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "", "100", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (Exception aex)
            {
                ex = aex;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void SugarNotANumber()
        {
            Exception ex = null;

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
            Assert.AreEqual("Sugar is not a number.", ex.Message);
        }

        [TestMethod]
        public void EmptySugar()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "100", "", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (Exception aex)
            {
                ex = aex;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void FatNotANumber()
        {
            Exception ex = null;

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
            Assert.AreEqual("Fat is not a number.", ex.Message);
        }

        [TestMethod]
        public void EmptyFat()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "100", "100", "", "12", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (Exception aex)
            {
                ex = aex;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void SatFatNotANumber()
        {
            Exception ex = null;

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
            Assert.AreEqual("Saturated Fats is not a number.", ex.Message);
        }

        [TestMethod]
        public void EmptySatFat()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "12", "100", "99", "", "6");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (Exception aex)
            {
                ex = aex;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void SaltNotANumber()
        {
            Exception ex = null;


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
            Assert.AreEqual("Salt is not a number.", ex.Message);
        }

        [TestMethod]
        public void EmptySalt()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "12", "100", "99", "12", "");

            try
            {
                ftracker.AddFood(dto);
            }
            catch (Exception aex)
            {
                ex = aex;
            }

            Assert.IsNull(ex);
        }

        [TestMethod]
        public void FoodAlreadyExists()
        {
            Exception ex = null;

            FoodDTO dto = helper("Bacon", "Filthy Pig", "200", "100", "99", "12", "6");

            try
            {
                ftracker.AddFood(dto);
                ftracker.AddFood(dto);
            }
            catch (ArgumentException aex)
            {
                ex = aex;
            }

            Assert.IsNotNull(ex);
            Assert.AreEqual("This food already exists.", ex.Message);
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
