﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jack.FoodTracker
{
    public interface IFoodSearchView
    {
        string SearchText { get; }

        event EventHandler SearchBarTextChanged;
    }
}
