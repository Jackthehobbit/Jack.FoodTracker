using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.Tests
{
    class MockFoodCategoryRepository : IFoodCategoryRepository
    {
        public List<FoodCategory> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(FoodCategory fCategory)
        {
            throw new NotImplementedException();
        }
    }
}
