using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    interface IFoodLookupView
    {
        IList<Food> Foods { set; }
        Food SelectedFood { get; set; }
        int SelectedFoodIndex { get; set; }

        IList<FoodCategory> Categories { set; }
        FoodCategory SelectedCategory { get; set; }
        
        event EventHandler CategorySelectedChanged;
        event EventHandler FoodSelectedChanged;
    }
}
