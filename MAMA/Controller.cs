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
        public bool LoginSuccessfully = false;
        private MainView _mainView;
        private CSV_Handler _csvHandler;
        private LoginView _loginView;

        private string _filePathOfOpenedList = string.Empty;
        private string _filePathofLogFile = string.Empty;

        private List<Customer> _deletedCustomerList;


        public List<Customer> CustomerList;


        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="mainView"></param>
        /// <param name="csv_Handler"></param>
        /// <param name="loginView"></param>
        public Controller(MainView mainView, CSV_Handler csv_Handler, LoginView loginView)
        {
            _mainView = mainView;
            _csvHandler = csv_Handler;
            _loginView = loginView;
        }

        /// <summary>
        /// Create New List of Customers
        /// </summary>
        public void NewListofCustomers()
        {
            //There should be asked current customer list to save?

            CustomerList = new List<Customer>();
            _filePathOfOpenedList = String.Empty;
            _mainView.UpdateDatagridViewFullList(CustomerList);
            _mainView.UpdateDataGridViewOverview(CustomerList);

        }

        /// <summary>
        /// Run or don't run the MainView depending on the login proce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleClosingLoginView(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(CloseLoginViewEventArgs))
            {
                if (((CloseLoginViewEventArgs) e).Loginsuccessful)
                {
                    _loginView.Close();
                    LoginSuccessfully = true;
                }
                else
                {
                    _loginView.Close();
                    LoginSuccessfully = false;
                }

            }

        }

        /// <summary>
        /// This methode gets the ListofCustomers and updates the view
        /// </summary>
        /// <param name="filepath"></param>
        public void GetCustomerList(string filepath)
        {
            _filePathOfOpenedList = filepath;
            List<Customer> myCustomers = _csvHandler.readCSV(filepath);
            

            CustomerList = myCustomers;
            _mainView.UpdateDataGridViewOverview(CustomerList);
            _mainView.UpdateDatagridViewFullList(CustomerList);
        }

        /// <summary>
        /// Saves the data to the file, which was opened last
        /// </summary>
        public void SaveCurrentCustomerList()
        {
            if (_filePathOfOpenedList != string.Empty)
            {
                _csvHandler.ExportToCSV(_filePathOfOpenedList, CustomerList);
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //Stream myStream;
                string filepath = string.Empty;
                saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    filepath = saveFileDialog1.FileName;
                    SaveNewCustomerList(filepath);

                }

            }
        }

        /// <summary>
        /// Saves the data to the file at savefilepath
        /// </summary>
        /// <param name="savefilepath">Put in the Path</param>
        public void SaveNewCustomerList(string savefilepath)
        {
            _filePathOfOpenedList = savefilepath;
            _csvHandler.ExportToCSV(savefilepath, CustomerList);
        }

        /// <summary>
        /// add a new customer to list
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(string firstName, string lastName, EMailAddress eMailAddress, float moneyBalance, Address address)
        {
            if (CustomerList == null)
            {
                CustomerList = new List<Customer>();
            }

            int customerNumber = CheckCustomerNumberorFindOne(CustomerList.Count+1);
            
            
            if (eMailAddress.getEmailAddress() == String.Empty || CheckEMailforUnique(eMailAddress) == false)
            {
                MessageBox.Show("Wrong input of the E-Mail address or the E-Mail address already exit");
                return;
            }
            else
            {
                Customer customer = new Customer(firstName,lastName, eMailAddress, customerNumber,moneyBalance,DateTime.Now,address);
                CustomerList.Add(customer);
                _mainView.UpdateDataGridViewOverview(CustomerList);
                _mainView.UpdateDatagridViewFullList(CustomerList);
            }

        }
        
        /// <summary>
        /// Delete the selected customer from the list
        /// </summary>
        /// <param name="customertoDelete"></param>
        public void DeleteCustomer(Customer customertoDelete)
        {
            //CreateNewLogFile
            if (_filePathofLogFile == string.Empty || _deletedCustomerList == null)
            {
                string message = "Is there an existing File of the deleted Customers?";
                //string caption = message;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, message, buttons);
                if (result == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    string filepath = string.Empty;
                    openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
                    openFileDialog1.FilterIndex = 2;
                    openFileDialog1.RestoreDirectory = true;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        _filePathofLogFile = openFileDialog1.FileName;
                        _deletedCustomerList = _csvHandler.readCSV(_filePathofLogFile);
                    }

                    //openFileDialog1.Dispose();
                }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //Stream myStream;
                    string filepath = string.Empty;
                    saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        _filePathofLogFile = saveFileDialog1.FileName;
                        _deletedCustomerList = new List<Customer>();
                    }

                    //saveFileDialog1.Dispose();
                }
            }

            customertoDelete._DateOfChange = DateTime.Now;
            _deletedCustomerList.Add(customertoDelete);
            if (_filePathofLogFile != string.Empty)
            {
                _csvHandler.ExportToCSV(_filePathofLogFile, _deletedCustomerList);
            }
            
            //updateCustomerList
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (CustomerList[i]._customerNumber == customertoDelete._customerNumber)
                {
                    CustomerList.RemoveAt(i);
                    _mainView.UpdateDatagridViewFullList(CustomerList);
                    _mainView.UpdateDataGridViewOverview(CustomerList);
                    _mainView.ClearCurrentCustomer();
                    return;
                }
            }
        }

        /// <summary>
        /// Change the Name and/or E-Mail of the customer
        /// </summary>
        /// <param name="customertoChange"></param>
        /// <param name="newlastName"></param>
        /// <param name="newEMailAddress"></param>
        public Customer EditCustomeritems(Customer customer, string newlastName, EMailAddress newEMailAddress, Address newAddress)
        {
            if (CustomerList == null || customer == null)
            {
                return customer;
            }

            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (customer._customerNumber == CustomerList[i]._customerNumber)
                {
                    CustomerList[i].UpdateNameAddressEmail(newlastName,newEMailAddress,newAddress);
                    customer = CustomerList[i];
                    _mainView.UpdateDataGridViewOverview(CustomerList);
                    _mainView.UpdateDatagridViewFullList(CustomerList);
                    return customer;
                }
            }

            return customer;
        }

        /// <summary>
        /// Change the Balance of the selected customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="moneybalance"></param>
        /// <returns></returns>
        public Customer ChangeBalanceofCustomer(Customer customer, float moneybalance)
        {
            if (CustomerList == null|| customer == null)
            {
                return customer;
            }
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (customer._customerNumber == CustomerList[i]._customerNumber)
                {
                    CustomerList[i].UpdateBalance(moneybalance);
                    customer = CustomerList[i];
                    _mainView.UpdateDataGridViewOverview(CustomerList);
                    _mainView.UpdateDatagridViewFullList(CustomerList);
                    return customer;
                }
            }

            return customer;
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
                _mainView.UpdateDataGridViewOverview(CustomerList);
                return;
            }


            List<Customer> foundcCustomers = new List<Customer>();
            for (int i = 0; i < toSearcheCustomers.Count; i++)
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

            _mainView.UpdateDataGridViewOverview(foundcCustomers);
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
        
        //These are all support Methodes
        private int CheckCustomerNumberorFindOne(int customerNumber)
        {

            bool matchNumbers = false;
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (customerNumber == CustomerList[i]._customerNumber)
                {
                    matchNumbers = true;
                    break;
                }
            }

            if (matchNumbers)
            {
                customerNumber += 1; 
                CheckCustomerNumberorFindOne(customerNumber);
            }

            return customerNumber;

        }

        private bool CheckEMailforUnique(EMailAddress eMailAddress)
        {
            
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (eMailAddress.getEmailAddress() == CustomerList[i]._eMail.getEmailAddress())
                {
                    return false;
                }
            }

            return true;
        }

    }

}
