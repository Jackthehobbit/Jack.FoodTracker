﻿using Jack.FoodTracker.Entities;
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
        private readonly IFoodCategoryRepository foodCatRepository;

        public FoodTracker(IFoodRepository foodRepository, IFoodCategoryRepository foodCatRepository)
        {
            this.foodRepository = foodRepository;
            this.foodCatRepository = foodCatRepository;

            //Check Uncategorised Category exists, else initiate it
            List<FoodCategory> cats = foodCatRepository.GetAll();

            if(!cats.Where(x => x.Name.Equals("Uncategorised")).Any())
            {
                foodCatRepository.Add(new FoodCategory() { Name = "Uncategorised" });
            }
        }

        public void AddFood(FoodDTO dto)
        {
            //Parse input strings into a food object
            FoodDTOParser parser = new FoodDTOParser();

            Food newFood = parser.Parse(dto);

            //Check the food doesn't already exist in the database
            if (foodRepository.GetAll().Where(x => x.Name.ToLower().Equals(newFood.Name.ToLower())).Any())
            {
                throw new ArgumentException("This food already exists.");
            }

            //Add the food to the database
            foodRepository.Add(newFood);
        }

        public void EditFood(FoodDTO dto, Food food)
        {
            //Parse input strings into a food object
            FoodDTOParser parser = new FoodDTOParser();
            
            //if the name has changed check that there isn't an existing food with the new name
            if(dto.Name != food.Name)
            {
                if (foodRepository.GetAll().Where(x => x.Name.ToLower().Equals(dto.Name.ToLower())).Any())
                {
                    throw new ArgumentException("A food with this name already exists.");
                }
            }

            Food newFood = parser.ParseIntoExisting(dto, food);
            
            //Add the food to the database
            foodRepository.Edit(newFood);
        }

        public void DeleteFood(Food food)
        {
            try
            {
                foodRepository.Delete(food);
            }
            catch(InvalidOperationException)
            {
                throw new ArgumentException("This food does not exist, hence can't be deleted.");
            }
        }

        public IList<FoodCategory> GetAllFoodCategories()
        {
            return foodCatRepository.GetAll();
        }

        public IList<Food> GetFoodByCategory(FoodCategory category)
        {
            return foodRepository.GetByCategory(category);
        }
    }
}
