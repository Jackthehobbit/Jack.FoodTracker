using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public abstract class RightPanel : Panel
    {
        public RightPanel()
        {
            Size = new System.Drawing.Size(800, 500);
            Location = new System.Drawing.Point(200,0);
        }
    }
}
