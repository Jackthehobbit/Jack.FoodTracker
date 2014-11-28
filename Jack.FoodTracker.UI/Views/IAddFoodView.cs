using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public interface IAddFoodView
    {
        IFoodItemView FoodItemView { get; }
        DialogResult DialogResult { get; set; }

        event EventHandler AddFoodClick;
        event EventHandler CancelClick;
    }
}
