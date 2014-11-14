using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.FoodTracker.Entities;

namespace Jack.FoodTracker.EntityDatabase
{
    public interface IPresetMealRepository
    {
        void Add(PresetMeal newMeal);

        void Edit(PresetMeal changedMeal);

        void Delete(PresetMeal presetMeal);

        IList<PresetMeal> GetAll();
    }
}
