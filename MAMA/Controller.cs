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

        private string filePathOfOpenedList = string.Empty;


        public List<Customer> CustomerList;
        

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
            filePathOfOpenedList = filepath;
            List<Customer> myCustomers = CSVHandler.readCSV(filepath);


            ////Test List
            //List<Customer> testCustomers = new List<Customer>();
            //testCustomers.Add(new Customer("Manuel", "Krammer", "manuel.krammer@gmail.com", 1, 120));
            //testCustomers.Add(new Customer("Matthias", "Farveleder", "farveleder@gmail.com", 5, 160));
            //testCustomers.Add(new Customer("Markus", "Farveleder", "m.farv@gmail.com", 7, -167));


            CustomerList = myCustomers;
            MainView.UpdateDataGridview(CustomerList);
        }

        /// <summary>
        /// Saves the data to the file, which was opened last
        /// </summary>
        public void SaveCurrentCustomerList()
        {
            if (filePathOfOpenedList != string.Empty)
            {
                CSVHandler.ExportToCSV(filePathOfOpenedList, CustomerList);
            }
        }

        /// <summary>
        /// Saves the data to the file at savefilepath
        /// </summary>
        /// <param name="savefilepath">Put in the Path</param>
        public void SaveNewCustomerList(string savefilepath)
        {
            CSVHandler.ExportToCSV(savefilepath, CustomerList);
        }

        /// <summary>
        /// add a new customer to list
        /// </summary>
        /// <param name="newCustomer"></param>
        public void AddCustomer(Customer newCustomer)
        {


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customertoChange"></param>
        /// <param name="newlastName"></param>
        /// <param name="newEMailAddress"></param>
        public void EditCustomeritems(Customer customertoChange, string newlastName, EMailAdress newEMailAddress)
        {


        }


        /// <summary>
        /// When there doesn't exist a list
        /// </summary>
        /// <param name="customer"></param>
        private void NewCustomerList(Customer customer)
        {

        }



    }
}
