﻿using System;
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
        private MainView _mainView;
        private CSV_Handler _csvHandler;
        private LoginView _loginView;

        private string _filePathOfOpenedList = string.Empty;


        public List<Customer> CustomerList;


        public Controller(MainView mainView, CSV_Handler csv_Handler, LoginView loginView)
        {
            _mainView = mainView;
            _csvHandler = csv_Handler;
            _loginView = loginView;
        }

        public Controller()
        {

        }


        public void HandleClosingLoginView(object sender, EventArgs e)
        {
            
            // check if the argument of the eventargs is true or false 

            Application.Run(_mainView);

        }



        /// <summary>
        /// This methode gets the ListofCustomers and updates the view
        /// </summary>
        /// <param name="filepath"></param>
        public void GetCustomerList(string filepath)
        {
            _filePathOfOpenedList = filepath;
            List<Customer> myCustomers = _csvHandler.readCSV(filepath);


            ////Test List
            //List<Customer> testCustomers = new List<Customer>();
            //testCustomers.Add(new Customer("Manuel", "Krammer", "manuel.krammer@gmail.com", 1, 120));
            //testCustomers.Add(new Customer("Matthias", "Farveleder", "farveleder@gmail.com", 5, 160));
            //testCustomers.Add(new Customer("Markus", "Farveleder", "m.farv@gmail.com", 7, -167));


            CustomerList = myCustomers;
            _mainView.UpdateDataGridview(CustomerList);
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
        }

        /// <summary>
        /// Saves the data to the file at savefilepath
        /// </summary>
        /// <param name="savefilepath">Put in the Path</param>
        public void SaveNewCustomerList(string savefilepath)
        {
            _csvHandler.ExportToCSV(savefilepath, CustomerList);
        }

        /// <summary>
        /// add a new customer to list
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(string firstName, string lastName, string strE_MailAddress, float moneyBalance)
        {
            int customerNumber = CheckCustomerNumberorFindOne(CustomerList.Count);
            EMailAdress eMailAddress = new EMailAdress(strE_MailAddress);


            if (eMailAddress.getEmailAdress() == String.Empty || CheckEMailforUnique(eMailAddress) == false)
            {
                MessageBox.Show("Wrong input of the E-Mail address or the E-Mail address already exit");
                return;
            }
            else
            {
                Customer customer = new Customer(firstName,lastName,strE_MailAddress,customerNumber,moneyBalance,DateTime.Now);
                CustomerList.Add(customer);
                _mainView.UpdateDataGridview(CustomerList);
            }

        }

        /// <summary>
        /// Change the Name and/or E-Mail of the customer
        /// </summary>
        /// <param name="customertoChange"></param>
        /// <param name="newlastName"></param>
        /// <param name="newEMailAddress"></param>
        public Customer EditCustomeritems(Customer customer, string newlastName, EMailAdress newEMailAddress)
        {
            if (CustomerList == null || customer == null)
            {
                return customer;
            }

            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (customer._customerNumber == CustomerList[i]._customerNumber)
                {
                    CustomerList[i].UpdateNameEmail(newlastName,newEMailAddress);
                    customer = CustomerList[i];
                    _mainView.UpdateDataGridview(CustomerList);
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
                    _mainView.UpdateDataGridview(CustomerList);
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
                _mainView.UpdateDataGridview(CustomerList);
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

            _mainView.UpdateDataGridview(foundcCustomers);
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
                CheckCustomerNumberorFindOne(customerNumber++);
            }

            return customerNumber;

        }

        private bool CheckEMailforUnique(EMailAdress eMailAdress)
        {
            
            for (int i = 0; i < CustomerList.Count; i++)
            {
                if (eMailAdress.getEmailAdress() == CustomerList[i]._eMail.getEmailAdress())
                {
                    return false;
                }
            }

            return true;
        }

    }

}
