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
            ftracker = new FoodTracker();

            InitializeComponent();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                FoodDTO dto = new FoodDTO();

                ftracker.AddFood(dto);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
