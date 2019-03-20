using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

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
        /// <summary>
        /// This methode gets the ListofCustomers and updates the view
        /// </summary>
        /// <param name="filepath"></param>
        public void GetCustomerList(string filepath)
        {

            CSVHandler.readCSV(filepath);


            //Test List
            List<Customer> testCustomers = new List<Customer>();
            testCustomers.Add(new Customer("Manuel", "Krammer", "manuel.krammer@gmail.com", 1, 120));
            testCustomers.Add(new Customer("Matthias", "Farveleder", "farveleder@gmail.com", 5, 160));
            testCustomers.Add(new Customer("Markus", "Farveleder", "m.farv@gmail.com", 7, -167));
            
            MainView.UpdateDataGridview(testCustomers);



        }


    }
}
