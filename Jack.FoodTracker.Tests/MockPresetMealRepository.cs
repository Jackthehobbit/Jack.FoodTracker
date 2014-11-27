using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;

namespace Jack.FoodTracker.Tests
{
    public class MockPresetMealRepository : IPresetMealRepository
    {
        IList<PresetMeal> meals;
        public MockPresetMealRepository()
        {
            meals = new List<PresetMeal>();
        }
        public IList<PresetMeal> GetAll()
        {
            return meals;
        }
        public void Add(PresetMeal presetMeal)
        {
            meals.Add(presetMeal);
        }
        public void Edit(PresetMeal presetMeal)
        {
            throw new NotImplementedException();
        }
        public void Delete(PresetMeal meal)
        {
            bool deleted = meals.Remove(meal);

            if (!deleted)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
