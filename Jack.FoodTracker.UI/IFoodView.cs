using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public interface IFoodView
    {
        IFoodItemView FoodItemView { get; }
        IFoodLookupView FoodLookupView { get; }
        IFoodSearchView FoodSearchView { get; }
        
        bool AddFoodButtonEnabled { set; }
        string EditFoodButtonText { set; }
        bool EditFoodButtonEnabled { set; }
        string DeleteFoodButtonText { set; }
        bool DeleteFoodButtonEnabled { set; }

        event EventHandler AddFoodClick;
        event EventHandler EditFoodClick;
        event EventHandler DeleteFoodClick;
    }
}
