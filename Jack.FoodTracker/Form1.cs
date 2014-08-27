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
        public Form1()
        {
            InitializeComponent();

            Context ctx = new Context();
            Food bacon = new Food();

            bacon.Name = "Bacon";
            bacon.Id = 0;
            bacon.Calories = 2000;
            bacon.Description = "Filthy Pig Fat";

            ctx.Foods.Add(bacon);
            ctx.SaveChanges();

            textBox1.Text = ctx.Foods.ToList()[0].Name;
        }
    }
}
