using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class FoodItemPanel : Panel
    {
        private TextBox tbName;
        private TextBox tbDesc;
        private ComboBox cbCategory;
        private TextBox tbCalories;
        private TextBox tbSugar;
        private TextBox tbFat;
        private TextBox tbSatFat;
        private TextBox tbSalt;

        public FoodItemPanel()
        {
            InitializeComponent();
        }
        
    }
}
