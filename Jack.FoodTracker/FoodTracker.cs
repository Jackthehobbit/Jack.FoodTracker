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
        private readonly IFoodCategoryRepository foodCatRepository;

        public FoodTracker(IFoodRepository foodRepository, IFoodCategoryRepository foodCatRepository)
        {
            this.foodRepository = foodRepository;
            this.foodCatRepository = foodCatRepository;

            //Check Uncategorised Category exists, else initiate it
            List<FoodCategory> cats = foodCatRepository.GetAll();

            if(!cats.Where(x => x.Name.Equals("Uncategorised")).Any())
            {
                foodCatRepository.Add(new FoodCategory() { Name = "Uncategorised" , Order = int.MaxValue });
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

        public void AddCategory(string categoryName)
        {
            categoryName = categoryName.Trim();

            CategoryChecker checker = new CategoryChecker();

            checker.Check(categoryName);

            if (foodCatRepository.GetAll().Where(o => o.Name.ToLower().Equals(categoryName.ToLower())).Any())
            {
                throw new ArgumentException("A category with this name already exists.");
            }

            foodCatRepository.Add(new FoodCategory() { Name = categoryName });
        }

        public void EditFoodCategory(string newCategoryName, FoodCategory foodCategory)
        {
            newCategoryName = newCategoryName.Trim();

            CategoryChecker checker = new CategoryChecker();

            checker.Check(newCategoryName);

            if(newCategoryName != foodCategory.Name)
            {
                if (foodCatRepository.GetAll().Where(o => o.Name.ToLower().Equals(newCategoryName.ToLower())).Any())
                {
                    throw new ArgumentException("A category with this name already exists.");
                }

                foodCategory.Name = newCategoryName;
            }

            foodCatRepository.Edit(foodCategory);
        }

        public IList<FoodCategory> GetAllFoodCategories(bool showUncategorised)
        {
            IList<FoodCategory> foodCategories = foodCatRepository.GetAll();

            foodCategories = foodCategories.OrderBy(o => o.Order).ToList();

            if(!showUncategorised)
            {
                FoodCategory uncategorised = foodCategories.Where(o => o.Name == "Uncategorised").First();

                foodCategories.Remove(uncategorised);
            }

            return foodCategories;
            
        }

        public IList<Food> GetFoodByCategory(FoodCategory category)
        {
            return foodRepository.GetByCategory(category);
        }

        public IList<Food> GetFoodByCategory(FoodCategory category,IList<Food> searchResults)
        {
            return foodRepository.GetByCategory(category,searchResults);
        }

        public void DeleteCategory(FoodCategory foodCategory)
        {
            if (foodCategory.Name == "Uncategorised")
            {
                throw new ArgumentException("Cannot delete the Uncategorised Category.");
            }

            IList<Food> foodsInCat = GetFoodByCategory(foodCategory);

            FoodCategory uncategorised = foodCatRepository.GetAll().Where(o => o.Name == "Uncategorised").First();

            foreach (Food food in foodsInCat)
            {
                food.Category = uncategorised;
                foodRepository.Edit(food);
            }

            try
            {
                foodCatRepository.Delete(foodCategory);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("This food does not exist, hence can't be deleted.");
            }
        }

        public void SwapCategoryOrder(FoodCategory foodCategory1, FoodCategory foodCategory2)
        {
            int tempOrder = foodCategory1.Order;
            foodCategory1.Order = foodCategory2.Order;
            foodCategory2.Order = tempOrder;

            foodCatRepository.Edit(foodCategory1);
            foodCatRepository.Edit(foodCategory2);
        }

        public IList<Food> SearchFoodByName(String searchText)
        {
            return foodRepository.SearchByName(searchText);
        }
    }
}
