using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public class FoodTracker
    {
        private readonly UnitOfWork UnitOfWork;

        public FoodTracker(UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;

            //Check Uncategorised Category exists, else initiate it
            List<FoodCategory> cats = UnitOfWork.FoodCategoryRepository.GetAll();

            if(!cats.Where(x => x.Name.Equals("Uncategorised")).Any())
            {
                UnitOfWork.FoodCategoryRepository.Add(new FoodCategory() { Name = "Uncategorised", Order = int.MaxValue });
                UnitOfWork.Save();
            }
        }

        public void AddFood(FoodDTO dto)
        {
            //Parse input strings into a food object
            FoodDTOParser parser = new FoodDTOParser();

            Food newFood = parser.Parse(dto);

            //Check the food doesn't already exist in the database
            if (UnitOfWork.FoodRepository.GetAll().Where(x => x.Name.ToLower().Equals(newFood.Name.ToLower())).Any())
            {
                throw new ArgumentException("This food already exists.");
            }

            //Add the food to the database
            UnitOfWork.FoodRepository.Add(newFood);
            UnitOfWork.Save();
        }

        public void EditFood(FoodDTO dto, Food food)
        {
            //Parse input strings into a food object
            FoodDTOParser parser = new FoodDTOParser();
            
            //if the name has changed check that there isn't an existing food with the new name
            if(dto.Name != food.Name)
            {
                if (UnitOfWork.FoodRepository.GetAll().Where(x => x.Name.ToLower().Equals(dto.Name.ToLower())).Any())
                {
                    throw new ArgumentException("A food with this name already exists.");
                }
            }

            Food newFood = parser.ParseIntoExisting(dto, food);
            
            //Add the food to the database
            UnitOfWork.FoodRepository.Edit(newFood);
            UnitOfWork.Save();
        }

        public void DeleteFood(Food food)
        {
            try
            {
                UnitOfWork.FoodRepository.Delete(food);
                UnitOfWork.Save();
            }
            catch(InvalidOperationException)
            {
                throw new ArgumentException("This food does not exist, hence can't be deleted.");
            }
        }

        public void AddCategory(string categoryName)
        {
            categoryName = categoryName.Trim();

            CheckerService checker = new CheckerService();
            try
            {
                checker.notBlankCheck("Name",categoryName);
                checker.checkRecordExists<FoodCategory>(UnitOfWork.FoodCategoryRepository.GetAll(), "Name", categoryName);
            }
            catch(ArgumentException aex)
            {
                throw new ArgumentException(""+aex.Message);
                
            }       
            UnitOfWork.FoodCategoryRepository.Add(new FoodCategory() { Name = categoryName });
            UnitOfWork.Save();
        }

        public void EditFoodCategory(string newCategoryName, FoodCategory foodCategory)
        {
            newCategoryName = newCategoryName.Trim();

            CategoryChecker checker = new CategoryChecker();

            checker.Check(newCategoryName);

            if(newCategoryName != foodCategory.Name)
            {
                if (UnitOfWork.FoodCategoryRepository.GetAll().Where(o => o.Name.ToLower().Equals(newCategoryName.ToLower())).Any())
                {
                    throw new ArgumentException("A category with this name already exists.");
                }

                foodCategory.Name = newCategoryName;
            }

            UnitOfWork.FoodCategoryRepository.Edit(foodCategory);
        }

        public IList<FoodCategory> GetAllFoodCategories(bool showUncategorised)
        {
            IList<FoodCategory> foodCategories = UnitOfWork.FoodCategoryRepository.GetAll();

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
            return UnitOfWork.FoodRepository.GetByCategory(category);
        }

        public void DeleteCategory(FoodCategory foodCategory)
        {
            if (foodCategory.Name == "Uncategorised")
            {
                throw new ArgumentException("Cannot delete the Uncategorised Category.");
            }

            IList<Food> foodsInCat = GetFoodByCategory(foodCategory);

            FoodCategory uncategorised = UnitOfWork.FoodCategoryRepository.GetAll().Where(o => o.Name == "Uncategorised").First();

            foreach (Food food in foodsInCat)
            {
                food.Category = uncategorised;
                UnitOfWork.FoodRepository.Edit(food);
            }

            try
            {
                UnitOfWork.FoodCategoryRepository.Delete(foodCategory);
                UnitOfWork.Save();
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

            UnitOfWork.FoodCategoryRepository.Edit(foodCategory1);
            UnitOfWork.FoodCategoryRepository.Edit(foodCategory2);
            UnitOfWork.Save();
        }

        public IList<Food> SearchFoodByName(String searchText)
        {
            return UnitOfWork.FoodRepository.SearchByName(searchText);
        }

        public IList<Food> GetAllFood()
        {
            return UnitOfWork.FoodRepository.GetAll();
        }
        
        public IList<FoodCategory> GetNonEmptyFoodCategories(IList<Food> foods)
        {
            IList<FoodCategory> fCatList = GetAllFoodCategories(true);
            IList<FoodCategory> fCatListResult = new List<FoodCategory>(fCatList);

            foreach (FoodCategory item in fCatList)
            {
                Food findCat = foods.Where(x => x.Category.Id.Equals(item.Id)).FirstOrDefault();

                if (findCat == null)
                {
                    fCatListResult.Remove(item);
                }
            }

            return fCatListResult;
        }

        

    }
}
