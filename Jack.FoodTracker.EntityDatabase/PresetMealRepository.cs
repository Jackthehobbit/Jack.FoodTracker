using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{
    class PresetMealRepository
    {
        private readonly FoodContext context;

        public PresetMealRepository(FoodContext context)
        {
            this.context = context;
        }
       
        public List<PresetMeal> GetAll()
        {
            return context.PresetMeals.Include("Foods").ToList();
        }
        public void Add(PresetMeal presetMeal)
        {
            context.PresetMeals.Add(presetMeal);
        }
        public void Edit(PresetMeal presetMeal)
        {
            context.Entry(presetMeal).State = System.Data.Entity.EntityState.Modified;
        }
        public void Delete(PresetMeal presetMeal)
        {
            context.PresetMeals.Remove(presetMeal);
        }
    }
}
