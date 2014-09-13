using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public class FoodDTOParser
    {
        public Food Parse(FoodDTO dto)
        {
            int calories;
            float sugar;
            float fat;
            float saturates;
            float salt;

            if(dto.Name == "")
            {
                throw new ArgumentException("Name is empty.");
            }

            if(dto.Calories == "")
            {
                calories = 0;
            }
            else if(!Int32.TryParse(dto.Calories, out calories))
            {
                throw new ArgumentException("Calories is not a whole number.");
            }

            if(dto.Sugar == "")
            {
                sugar = 0;
            }
            else if(!float.TryParse(dto.Sugar, out sugar))
            {
                throw new ArgumentException("Sugar is not a number.");
            }

            if(dto.Fat == "")
            {
                fat = 0;
            }
            else if(!float.TryParse(dto.Fat, out fat))
            {
                throw new ArgumentException("Fat is not a number.");
            }

            if(dto.Saturates == "")
            {
                saturates = 0;
            }
            else if(!float.TryParse(dto.Saturates, out saturates))
            {
                throw new ArgumentException("Saturated Fats is not a number.");
            }

            if(dto.Salt == "")
            {
                salt = 0;
            }
            else if(!float.TryParse(dto.Salt, out salt))
            {
                throw new ArgumentException("Salt is not a number.");
            }

            return new Food(dto.Name, dto.Description, calories, sugar, fat, saturates, salt);
        }
    }
}
