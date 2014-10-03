using Jack.FoodTracker.Entities;
using Jack.FoodTracker.EntityDatabase;
using Jack.FoodTracker;
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
    public partial class MainForm : Form
    {
        private FoodPanel fPanel;

        public MainForm()
        {
            InitializeComponent();

            fPanel = new FoodPanel();
            Controls.Add(fPanel);

        }
    }
}
