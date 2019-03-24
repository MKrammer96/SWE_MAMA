using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

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
        /// Search by Name
        /// </summary>
        /// <param name="searchbyName"></param>
        /// <returns></returns>
        public void SearchforCustomer(string searchbyName, List<Customer> toSearcheCustomers)
        {
            if (toSearcheCustomers == null)
            {
                return;
            }

            if (searchbyName == string.Empty)
            {
                MainView.UpdateDataGridview(CustomerList);
                return;
            }


            List<Customer> foundcCustomers = new List<Customer>();
            for(int i = 0; i < toSearcheCustomers.Count; i++)
            {
                string currentCustomer = toSearcheCustomers[i]._lastName;
                bool equalletters = false;
                for (int j = 0; j < searchbyName.Length; j++)
                {
                    if (searchbyName[j] == char.ToLower(currentCustomer[j]) || searchbyName[j] == currentCustomer[j])
                    {
                        equalletters = true;
                    }
                    else
                    {
                        equalletters = false;
                        break;
                    }

                }

                if (equalletters == true)
                {
                    foundcCustomers.Add(toSearcheCustomers[i]);
                }
                
            }

            MainView.UpdateDataGridview(foundcCustomers);
        }

        /// <summary>
        /// Get the Customer by CustomerNumber
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <param name="showedCustomers"></param>
        /// <returns></returns>
        public Customer GetSelectedCustomer(int customerNumber, List<Customer> showedCustomers)
        {
            if (showedCustomers == null)
            {
                return null;
            }

            for (int i = 0; i < showedCustomers.Count; i++)
            {
                if (customerNumber == showedCustomers[i]._customerNumber)
                {
                    return showedCustomers[i];
                }
            }

            return null;

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
