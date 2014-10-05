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
        private FoodView fPanel;

        public MainForm()
        {
            InitializeComponent();

            //Create Repositories
            FoodContext context = new FoodContext();
            FoodRepository fRepository = new FoodRepository(context);
            FoodCategoryRepository fCatRepository = new FoodCategoryRepository(context);

            FoodTracker fTracker = new FoodTracker(fRepository, fCatRepository);

            fPanel = new FoodView(fTracker);
            CategoriesView cPanel = new CategoriesView(fTracker);
            Controls.Add(cPanel);

        }
    }
}
