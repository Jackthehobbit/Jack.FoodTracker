using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    public partial class Form1 : Form
    {
        private FoodTracker ftracker;

        public Form1()
        {
            ftracker = new FoodTracker(new FoodRepository(new FoodContext()));

            InitializeComponent();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = new FoodDTO();

                dto.Name = tbName.Text;
                dto.Description = tbDesc.Text;
                dto.Calories = tbCalories.Text;
                dto.Sugar = tbSugar.Text;
                dto.Fat = tbFat.Text;
                dto.Saturates = tbSatFat.Text;
                dto.Salt = tbSalt.Text;

                ftracker.AddFood(dto);

                tbName.Text = "";
                tbDesc.Text = "";
                tbCalories.Text = "";
                tbSugar.Text = "";
                tbFat.Text = "";
                tbSatFat.Text = "";
                tbSalt.Text = "";
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
