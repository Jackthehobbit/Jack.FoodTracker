using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public interface IFoodItemView
    {
        bool Enabled { get; set; }
        string FoodName { get; set; }
        string Description { get; set; }
        IList<FoodCategory> Categories { set; }
        FoodCategory Category { get; set; }
        string NewCategoryName { get; }
        int CategoryIndex { get; set; }
        string Calories { get; set; }
        string Sugar { get; set; }
        string Fat { get; set; }
        string SatFat { get; set; }
        string Salt { get; set; }
    }
}
