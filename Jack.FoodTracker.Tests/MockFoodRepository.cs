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
        public List<Food> foods { get; set; }

        public MockFoodRepository()
        {
            foods = new List<Food>();
        }

        public void Add(Food newFood)
        {
            foods.Add(newFood);
        }

        public void Delete(Food food)
        {
            bool deleted = foods.Remove(food);

            if(!deleted)
            {
                throw new InvalidOperationException();
            }
        }

        public IList<Food> GetAll()
        {
            return foods;
        }

        public IList<Food> GetByCategory(FoodCategory fCat)
        {
            throw new NotImplementedException();
        }
    }
}
