using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.FoodTracker.EntityDatabase;
using Jack.FoodTracker.Entities;

namespace Jack.FoodTracker.Tests
{
    class MockFoodRepository : IFoodRepository
    {
        private List<Food> foods;

        public MockFoodRepository()
        {
            foods = new List<Food>();
        }

        public void Add(Food newFood)
        {
            foods.Add(newFood);
        }

        public IList<Food> GetAll()
        {
            return foods;
        }

        IList<Food> GetByCategory(FoodCategory fCat)
        {
            throw new NotImplementedException();
        }
    }
}
