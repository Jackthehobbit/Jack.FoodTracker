using Jack.FoodTracker.Entities;
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

        public FoodItemPanel(IList<FoodCategory> cats)
        {
            InitializeComponent(cats);
        }
        
        public FoodDTO GetInputs()
        {
            return new FoodDTO()
            {
                Name = tbName.Text,
                Category = (FoodCategory)cbCategory.SelectedItem,
                Description = tbDesc.Text,
                Calories = tbCalories.Text,
                Sugar = tbSugar.Text,
                Fat = tbFat.Text,
                Saturates = tbSatFat.Text,
                Salt = tbSalt.Text
            };
        }

        public void SetInputs(Food food)
        {
            tbName.Text = food.Name;
            tbDesc.Text = food.Description;
            cbCategory.SelectedItem = food.Category;
            tbCalories.Text = "" + food.Calories;
            tbSugar.Text = "" + food.Sugars;
            tbFat.Text = "" + food.Fat;
            tbSatFat.Text = "" + food.Saturates;
            tbSalt.Text = "" + food.Salt;
        }

        public void ClearInputs()
        {
            tbName.Text = "";
            cbCategory.SelectedIndex = -1;
            tbDesc.Text = "";
            tbCalories.Text = "";
            tbSugar.Text = "";
            tbFat.Text = "";
            tbSatFat.Text = "";
            tbSalt.Text = "";
        }

        public string GetName()
        {
            return tbName.Text;
        }

        public FoodCategory GetSelectedCategory()
        {
            return (FoodCategory)cbCategory.SelectedItem;
        }
    }
}
