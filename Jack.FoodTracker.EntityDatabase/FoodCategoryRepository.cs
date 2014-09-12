using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{
    public class FoodCategoryRepository
    {
        private readonly FoodContext context;

        public FoodCategoryRepository(FoodContext context)
        {
            this.context = context;
        }

        public List<FoodCategory> GetAll()
        {
            return context.Categories.ToList();
        }
    }
}
