using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{
    public class UnitOfWork
    {
        private readonly FoodContext Context;
        public IFoodRepository FoodRepository { get; set; }
        public IFoodCategoryRepository FoodCategoryRepository { get; set; }
        public IPresetMealRepository PresetMealRepository { get; set; }

        public UnitOfWork(FoodContext context, IFoodRepository foodRepository, IFoodCategoryRepository foodCategoryRepository,IPresetMealRepository presetMealRepository)
        {
            Context = context;
            FoodRepository = foodRepository;
            FoodCategoryRepository = foodCategoryRepository;
            PresetMealRepository = presetMealRepository;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
