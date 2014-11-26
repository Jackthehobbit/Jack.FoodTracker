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
        public List<FoodCategory> cats { get; set; }

        public MockFoodCategoryRepository()
        {
            cats = new List<FoodCategory>();
        }

        public List<FoodCategory> GetAll()
        {
            return cats;
        }

        public void Add(FoodCategory fCategory)
        {
            cats.Add(fCategory);
        }

        public void Edit(FoodCategory fCategory)
        {

        }

        public void Delete(FoodCategory fCategory)
        {

        }
        public FoodCategory GetByName(String Name)
        {

        }
    }
}
