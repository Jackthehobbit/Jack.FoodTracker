using Jack.FoodTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class FoodItemView : UserControl, IFoodItemView
    {
        private TextBox tbName;
        private TextBox tbDesc;
        private ComboBox cbCategory;
        private TextBox tbCalories;
        private TextBox tbSugar;
        private TextBox tbFat;
        private TextBox tbSatFat;
        private TextBox tbSalt;

        public FoodItemView()
        {
            InitializeComponent();
        }

        public string FoodName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public string Description
        {
            get { return tbDesc.Text; }
            set { tbDesc.Text = value; }
        }

        public IList<FoodCategory> Categories
        {
            set { cbCategory.DataSource = value; }
        }

        public FoodCategory Category
        {
            get { return (FoodCategory)cbCategory.SelectedItem; }
            set { cbCategory.SelectedItem = value; }
        }

        public int CategoryIndex
        {
            get { return cbCategory.SelectedIndex; }
            set { cbCategory.SelectedIndex = value; }
        }

        public string Calories
        {
            get { return tbCalories.Text; }
            set { tbCalories.Text = value; }
        }

        public string Sugar
        {
            get { return tbSugar.Text; }
            set { tbSugar.Text = value; }
        }

        public string Fat
        {
            get { return tbFat.Text; }
            set { tbFat.Text = value; }
        }

        public string SatFat
        {
            get { return tbSatFat.Text; }
            set { tbSatFat.Text = value; }
        }

        public string Salt
        {
            get { return tbSalt.Text; }
            set { tbSalt.Text = value; }
        }
    }
}
