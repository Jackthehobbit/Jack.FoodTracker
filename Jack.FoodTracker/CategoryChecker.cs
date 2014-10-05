using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jack.FoodTracker
{
    class CategoryChecker
    {
        public void Check(string categoryName)
        {
            if(categoryName == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
    }
}
