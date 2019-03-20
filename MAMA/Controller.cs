using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{

    public class Controller
    {
        private MainView MainView;
        private CSV_Handler CSVHandler;
        private LoginView LoginView;


        public Controller(MainView mainView, CSV_Handler csv_Handler, LoginView loginView)
        {
            MainView = mainView;
            CSVHandler = csv_Handler;
            LoginView = loginView;
        }

        public Controller()
        {

        }
    }
}
