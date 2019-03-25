using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAMA
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
            
            MainView mainView= new MainView();
            CSV_Handler csvHandler= new CSV_Handler();
            LoginView loginView = new LoginView();
            
            Controller controller = new Controller(mainView, csvHandler,loginView);
            mainView.SetContoller(controller);
            loginView.SetContoller(controller);

            // Set Password to Login
            Password.SetPassword("MAMA");

            //Eventhandler to close loginform 
            loginView.CloseLoginView += new EventHandler(controller.HandleClosingLoginView);

            loginView.ShowDialog();
            ////Start Main Application
            if (controller.LoginSuccessfully)
            {
                Application.Run(mainView);
            }
            
        }

    }
}
