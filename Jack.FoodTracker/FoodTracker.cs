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
        private readonly IFoodRepository foodRepository;

        public FoodTracker(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        public void AddFood(FoodDTO dto)
        {
            //Parse input strings into a food object
            FoodDTOParser parser = new FoodDTOParser();

            Food newFood = parser.Parse(dto);

            //Check the food doesn't already exist in the database
            if(foodRepository.GetAll().Where(x => x.Name.Equals(newFood.Name)).Any())
            {
                throw new ArgumentException("This food already exists.");
            }

            //Add the food to the database
            foodRepository.Add(newFood);
        }
    }
}
