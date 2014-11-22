using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jack.FoodTracker.Entities;

namespace Jack.FoodTracker
{
    public interface ICategoryLookupView
    {
        FoodCategory SelectedCategory { get; set; }
        int SelectedCategoryIndex { get; set; }
        bool Enabled { get; set; }
        IList<FoodCategory> Categories { get; set; }

        event EventHandler SelectedCategoryChanged;
    }
}
