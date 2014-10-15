using Jack.FoodTracker.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jack.FoodTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Create Data Access Layer
            FoodContext context = new FoodContext();
            FoodRepository fRepository = new FoodRepository(context);
            FoodCategoryRepository fCatRepository = new FoodCategoryRepository(context);
            UnitOfWork UnitOfWork = new UnitOfWork(context, fRepository, fCatRepository);

            //Create Business Layer
            FoodTracker FoodTracker = new FoodTracker(UnitOfWork);

            //Create UI Layer
            MainForm MainForm = new MainForm(FoodTracker);
            MainPresenter MainPresenter = new MainPresenter(MainForm, FoodTracker);

            Application.Run(MainForm);
        }
    }
}
