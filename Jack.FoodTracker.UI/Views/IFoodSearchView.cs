using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public interface IFoodSearchView
    {
        string SearchText { get; }

        bool Enabled { set; get; }

        event EventHandler SearchBarTextChanged;
        event KeyPressEventHandler SearchEntered;
    }
}
