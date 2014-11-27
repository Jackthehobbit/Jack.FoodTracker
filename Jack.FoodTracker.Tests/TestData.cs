using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.FoodTracker.EntityDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jack.FoodTracker.Tests
{
    [TestClass]
    public abstract class TestData
    {
        public FoodContext context;
        public MockFoodRepository foodRepository;
        public MockFoodCategoryRepository fCatRepository;
        public MockPresetMealRepository presetMealRepository;
        public UnitOfWork unitOfWork;
        public FoodTracker ftracker;

        [TestInitialize]
        public void DataSetup()
        {
            context = new FoodContext();
            foodRepository = new MockFoodRepository();
            fCatRepository = new MockFoodCategoryRepository();
            presetMealRepository = new MockPresetMealRepository();
            unitOfWork = new UnitOfWork(context, foodRepository, fCatRepository, presetMealRepository);
            ftracker = new FoodTracker(unitOfWork);
        }
    }
}
