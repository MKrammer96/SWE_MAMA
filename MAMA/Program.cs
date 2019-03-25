using System;
using System.Collections.Generic;
using System.Linq;
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

            //Start Login View with PasswordBox
            loginView.CloseLoginView += new EventHandler(controller.HandleClosingLoginView);

            
            //Start MainView after positiiv Login
            Application.Run(mainView);
        }
    }
}
