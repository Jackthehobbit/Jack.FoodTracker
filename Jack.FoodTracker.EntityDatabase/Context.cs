using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker.EntityDatabase
{   
    public class Context : DbContext
    {
        public Context() : base("FoodContext")
        {
        }

        public DbSet<Food> Foods { get; set; }
    }
}
