using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{
    public class FoodCategoryRepository : IFoodCategoryRepository
    {
        private readonly FoodContext context;

        public FoodCategoryRepository(FoodContext context)
        {
            this.context = context;
        }

        public List<FoodCategory> GetAll()
        {

            // Either change the properety on the entity to virtual and use:
            // return context.Categories.ToList();
            // or dont and use :
            return context.Categories.Include("Foods").ToList();
        }

        public void Add(FoodCategory foodCategory)
        {
            context.Categories.Add(foodCategory);

            context.SaveChanges();

            if(foodCategory.Order == 0)
            {
                foodCategory.Order = foodCategory.Id;

                Edit(foodCategory);
            }
        }

        public void Edit(FoodCategory foodCategory)
        {
            context.Entry(foodCategory).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(FoodCategory foodCategory)
        {
            context.Categories.Remove(foodCategory);
        }
    }
}
