using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    interface ICategoryView
    {
        IAddCategoryView AddCategoryView { get; }
        ICategoryLookupView CategoryLookupView { get; }       
        ICategoryItemView CategoryItemView { get; }

        bool EditButtonEnabled { get; set; }
        bool DeleteButtonEnabled { get; set; }
        bool MoveUpButtonEnabled { get; set; }
        bool MoveDownButtonEnabled { get; set; }

        string EditButtonText { get; set; }
        string DeleteButtonText { get; set; }

        event EventHandler EditButtonClick;
        event EventHandler DeleteButtonClick;
        event EventHandler MoveUpButtonClick;
        event EventHandler MoveDownButtonClick;
    }
}
