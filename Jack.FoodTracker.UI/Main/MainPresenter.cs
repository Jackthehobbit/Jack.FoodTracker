using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    class MainPresenter
    {
        private readonly IMainView MainView;

        private readonly FoodPresenter FoodPresenter;
        private readonly CategoryPresenter CategoryPresenter;

        private readonly FoodTracker FoodTracker;

        public MainPresenter(IMainView mainView, FoodTracker foodTracker)
        {
            MainView = mainView;
            FoodTracker = foodTracker;
            FoodPresenter = new FoodPresenter(MainView.FoodView, FoodTracker);
            CategoryPresenter = new CategoryPresenter(MainView.CategoryView, FoodTracker);

        }
    }
}
