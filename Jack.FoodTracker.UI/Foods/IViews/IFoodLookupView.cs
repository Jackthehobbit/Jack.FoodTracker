using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public interface IFoodLookupView
    {
        ICategoryLookupView CategoryLookupView { get; }

        IList<Food> Foods { set; }
        Food SelectedFood { get; set; }
        int SelectedFoodIndex { get; set; }

        bool Enabled { get; set; }
        
        event EventHandler FoodSelectedChanged;
    }
}
