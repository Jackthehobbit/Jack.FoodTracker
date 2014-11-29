using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public interface IMainView
    {
        RightView CurrentView { get; set; }

        FoodView FoodView { get; }

        CategoryView CategoryView { get; }
    }
}
