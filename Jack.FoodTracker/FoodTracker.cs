using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public class FoodTracker
    {
        public FoodTracker()
        {

        }

        public void AddFood(FoodDTO dto)
        {
            //Parse input strings into a food object
            FoodDTOParser parser = new FoodDTOParser();

            Food newFood = parser.Parse(dto);

            //Check the food doesn't already exist in the database
            FoodContext fContext = new FoodContext();
            
            if(fContext.Foods.Where(x => x.Name.Equals(newFood.Name)).Any())
            {
                throw new ArgumentException("This food already exists.");
            }

            //Add the food to the database
            fContext.Foods.Add(newFood);
            fContext.SaveChanges();
            fContext.Dispose();
        }
    }
}
