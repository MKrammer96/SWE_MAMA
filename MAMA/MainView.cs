using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAMA
{
    public partial class MainView : Form
    {
        private Controller _controller;
        private List<Customer> _currentCustomersList;
        private Customer _currentEditCustomer = null;


        /// <summary>
        /// constructor
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            ButtonAddNewCustomertoList.Enabled = false;
            ButtonSaveEditItems.Enabled = false;
            ButtonSaveNewBalance.Enabled = false;

            DataGridViewCustomersOverview.ReadOnly = true;
        }
        /// <summary>
        /// Set the Controller of the application in the view
        /// </summary>
        /// <param name="controller"></param>
        public void SetContoller(Controller controller)
        {
            this._controller = controller;
        }

        /// <summary>
        /// shows the list of customers in overview
        /// </summary>
        /// <param name="customers"></param>
        public void UpdateDataGridViewOverview(List<Customer> customers)
        {

            _currentCustomersList = customers;
            //Skalierung 
            //DataGridViewCustomers = customers;
            DataGridViewCustomersOverview.Rows.Clear();
            DataGridViewCustomersOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewCustomersOverview.Update();

            for (int i = 0; i < customers.Count; i++)
            {
                int number = DataGridViewCustomersOverview.Rows.Add();
                DataGridViewCustomersOverview.Rows[number].Cells[0].Value = customers[i]._customerNumber;
                DataGridViewCustomersOverview.Rows[number].Cells[1].Value = customers[i]._firstName;
                DataGridViewCustomersOverview.Rows[number].Cells[2].Value = customers[i]._lastName;
                DataGridViewCustomersOverview.Rows[number].Cells[3].Value = customers[i]._eMail.getEmailAdress();
                DataGridViewCustomersOverview.Rows[number].Cells[4].Value = customers[i]._DateOfChange;
                DataGridViewCustomersOverview.Rows[number].Cells[5].Value = customers[i]._MoneyBalance;
            }

        }

        /// <summary>
        /// Updates the DataGrid with de Data in customers
        /// </summary>
        /// <param name="customers">Customer-data</param>
        public void UpdateDatagridViewFullList(List<Customer> customers)
        {
            DataGridViewAllCustomers.Rows.Clear();
            DataGridViewAllCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewAllCustomers.Update();

            for (int i = 0; i < customers.Count; i++)
            {
                int number = DataGridViewAllCustomers.Rows.Add();
                DataGridViewAllCustomers.Rows[number].Cells[0].Value = customers[i]._customerNumber;
                DataGridViewAllCustomers.Rows[number].Cells[1].Value = customers[i]._firstName;
                DataGridViewAllCustomers.Rows[number].Cells[2].Value = customers[i]._lastName;
                DataGridViewAllCustomers.Rows[number].Cells[3].Value = customers[i]._eMail.getEmailAdress();
                DataGridViewAllCustomers.Rows[number].Cells[4].Value = customers[i]._DateOfChange;
                DataGridViewAllCustomers.Rows[number].Cells[5].Value = customers[i]._MoneyBalance;
            }
        }

        //finished
        private void ButtonClickedMainTab(object sender, EventArgs e) 
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button) sender;

                if (btn == ButtonCancelSearch)
                {
                    TextBoxSearchbyLastName.Clear();
                }
                else if (btn == ButtonAddNewCustomertoList)
                {
                    _controller.AddCustomer(TextBoxAddFirstName.Text,TextBoxAddLastName.Text,TextBoxAddE_Mail.Text,float.Parse(TextBoxAddNewAmount.Text));
                    ClearTextBoxesAddNewCustomer();

                }
                else if (btn == ButtonCancelNewCustomer)
                {
                    ClearTextBoxesAddNewCustomer();
                }
            }
        }

        // finished
        private void ButtonClickedEditItemsTab(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button)sender;

                if (btn == ButtonSaveNewBalance)
                {
                    if (_currentEditCustomer != null)
                    {
                        float newBalance;
                        if (float.TryParse(LabelNewBalanceShow.Text, out newBalance))
                        {
                            _currentEditCustomer = _controller.ChangeBalanceofCustomer(_currentEditCustomer, newBalance);
                            UpdateBalanceTab(_currentEditCustomer);
                            UpdateEditItemsTab(_currentEditCustomer);
                        }
                        
                    }
                }
                else if (btn == ButtonCancelNewBalance)
                {

                    _currentEditCustomer = null;
                    ClearTextBoxesEditBalanceItems();


                }
                else if (btn == ButtonAddNewAmount)
                {
                    if (_currentEditCustomer != null && ButtonSaveNewBalance.Enabled == true)
                    {
                        float newAmount = _currentEditCustomer._MoneyBalance + float.Parse(TextBoxNewAmount.Text);
                        LabelNewBalanceShow.Text = newAmount.ToString();
                    }
                }
                else if (btn == ButtonSubNewAmount)
                {
                    if (_currentEditCustomer != null)
                    {
                        if (_currentEditCustomer != null && ButtonSaveNewBalance.Enabled == true)
                        {
                            float newAmount = _currentEditCustomer._MoneyBalance - float.Parse(TextBoxNewAmount.Text); ;
                            LabelNewBalanceShow.Text = newAmount.ToString();
                        }
                    }
                }
                else if (btn == ButtonSaveEditItems)
                {
                    if (_currentEditCustomer != null)
                    {
                        EMailAdress eMailAddress = new EMailAdress(TextBoxEMailEditItems.Text);
                        if (eMailAddress.Address != string.Empty && CheckforLettersonly(TextBoxLastNameEditItems.Text))
                        {
                            _currentEditCustomer = _controller.EditCustomeritems(_currentEditCustomer,
                                TextBoxLastNameEditItems.Text, eMailAddress);
                            UpdateBalanceTab(_currentEditCustomer);
                            UpdateEditItemsTab(_currentEditCustomer);
                        }

                    }

                }
                else if (btn == ButtonCancelEditItems)
                {
                    _currentEditCustomer = null;
                    ClearTextBoxesEditBalanceItems();
                }


            }

        }

        //finished
        private void TextBoxChangedMainTabControl(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txBox = (TextBox)sender;

                if (txBox == TextBoxAddFirstName)
                {
                    bool textOk = CheckforLettersonly(TextBoxAddFirstName.Text);

                    if (textOk && TextBoxAddFirstName.Text.Length > 2)
                    {
                        TextBoxAddFirstName.BackColor = Color.Green;
                        CheckAddBoxes();
                    }
                    else
                    {
                        TextBoxAddFirstName.BackColor = Color.Red;
                        ButtonAddNewCustomertoList.Enabled = false;
                    }
                }

                else if (txBox == TextBoxAddLastName)
                {
                    bool textOk = CheckforLettersonly(TextBoxAddLastName.Text);

                    if (textOk && TextBoxAddLastName.Text.Length > 2)
                    {
                        TextBoxAddLastName.BackColor = Color.Green;
                        CheckAddBoxes();
                    }
                    else
                    {
                        TextBoxAddLastName.BackColor = Color.Red;
                        ButtonAddNewCustomertoList.Enabled = false;
                    }

                }
                else if (txBox == TextBoxAddE_Mail)
                {
                    EMailAdress eMailAdress = new EMailAdress(TextBoxAddE_Mail.Text);
                    if (eMailAdress.Address != string.Empty && eMailAdress.Address != string.Empty)
                    {
                        TextBoxAddE_Mail.BackColor = Color.Green;
                        CheckAddBoxes();
                    }
                    else
                    {
                        TextBoxAddE_Mail.BackColor = Color.Red;
                        ButtonAddNewCustomertoList.Enabled = false;
                    }


                }
                else if (txBox == TextBoxAddNewAmount)
                {
                    decimal moneyBalance;
                    if (decimal.TryParse(TextBoxAddNewAmount.Text, out moneyBalance))
                    {
                        TextBoxAddNewAmount.BackColor = Color.Green;
                        CheckAddBoxes();
                    }
                    else
                    {
                        TextBoxAddNewAmount.BackColor = Color.Red;
                        ButtonAddNewCustomertoList.Enabled = false;
                    }

                }

                else if (txBox == TextBoxSearchbyLastName)
                {
                    _controller.SearchforCustomer(TextBoxSearchbyLastName.Text,_currentCustomersList);
                }

                
            }


        }

        // finished
        private void TextBoxChangedTabControllEditItems(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txBox = (TextBox) sender;

                //Check Input Balance
                if (txBox== TextBoxNewAmount)
                {
                    decimal moneyBalance;
                    if (decimal.TryParse(TextBoxNewAmount.Text, out moneyBalance))
                    {
                        TextBoxNewAmount.BackColor = Color.Green;
                        if (_currentEditCustomer != null)
                        {
                            ButtonSaveNewBalance.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        TextBoxNewAmount.BackColor = Color.Red;
                        ButtonSaveNewBalance.Enabled = false;
                    }

                }

                //Check Input Edit Items 
                else if (txBox == TextBoxLastNameEditItems)
                {
                    if (CheckforLettersonly(TextBoxLastNameEditItems.Text) && TextBoxLastNameEditItems.Text.Length > 2)
                    {
                        TextBoxLastNameEditItems.BackColor = Color.Green;

                        if (TextBoxEMailEditItems.BackColor == Color.Green)
                        {
                            ButtonSaveEditItems.Enabled = true;
                        }
                    }
                    else
                    {
                        TextBoxLastNameEditItems.BackColor = Color.Red;
                        ButtonSaveEditItems.Enabled = false;
                    }

                }
                else if (txBox == TextBoxEMailEditItems)
                {
                    EMailAdress eMailAdress = new EMailAdress(TextBoxEMailEditItems.Text);
                    if (eMailAdress.Address != string.Empty && eMailAdress.Address != string.Empty)
                    {
                        TextBoxEMailEditItems.BackColor = Color.Green;

                        if (TextBoxLastNameEditItems.BackColor == Color.Green)
                        {
                            ButtonSaveEditItems.Enabled = true;
                        }
                    }
                    else
                    {
                        TextBoxEMailEditItems.BackColor = Color.Red;
                        ButtonSaveEditItems.Enabled = false;
                    }

                }
            }
        }

        //finished
        private void NewToolStripMenuItem(object sender, EventArgs e)
        {
            _controller.NewListofCustomers();
            ClearTextBoxesAddNewCustomer();
            ClearTextBoxesEditBalanceItems();
        }

        // finished
        private void OpenfileHandler(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // only for csv 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;

                _controller.GetCustomerList(filepath);
            }

        }

        // finished
        private void SavefileHandler(object sender, EventArgs e)
        {
            //Stream myStream;
            string filepath = string.Empty;
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filepath = saveFileDialog1.FileName;
                _controller.SaveNewCustomerList(filepath);

                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                //    // Code to write the stream goes here.
                //    // Attention new CSV Handler
                //    filepath = saveFileDialog1.FileName;
                //    Controller.SaveNewCustomerList(filepath);
                //}
            }

        }

        // finished
        private void SaveCurrentFile(object sender, EventArgs e)
        {
            _controller.SaveCurrentCustomerList();
        }

        //finished
        private void DataGridviewSelectedRow(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(DataGridView))
            {
                if ((DataGridView) sender == DataGridViewCustomersOverview)
                {


                    if (DataGridViewCustomersOverview.CurrentRow.Cells[0].Value == null)
                    {
                        return;
                    }

                    if (DataGridViewCustomersOverview.CurrentRow.Cells[0].Value.GetType() == typeof(int))
                    {
                        int selectedCustomerNumber = Convert.ToInt16(DataGridViewCustomersOverview.CurrentRow.Cells[0].Value);
                        Customer selectedCustomer = _controller.GetSelectedCustomer(selectedCustomerNumber, _currentCustomersList);
                        _currentEditCustomer = selectedCustomer;
                        UpdateBalanceTab(selectedCustomer);
                        UpdateEditItemsTab(selectedCustomer);
                        
                    }
                    
                }

            }


        }



        //These are all support Methodes
        //finished
        private void CheckAddBoxes()
        {
            if (TextBoxAddFirstName.BackColor == Color.Green && TextBoxAddLastName.BackColor == Color.Green &&
                TextBoxAddE_Mail.BackColor == Color.Green && TextBoxAddNewAmount.BackColor == Color.Green)
            {
                ButtonAddNewCustomertoList.Enabled = true;
            }
            else
            {
                ButtonAddNewCustomertoList.Enabled = false;
            }
        }
        //finished
        private void UpdateBalanceTab(Customer customer)
        {
            LabelFirstNameEditBalance.Text = customer._firstName;
            LabelLastNameEditBalance.Text = customer._lastName;
            LabelE_MailAddressEditBalance.Text = customer._eMail.getEmailAdress();
            LabelDateofChangeEditBalance.Text = customer._DateOfChange.ToString();
            LabelCurrentBalanceShow.Text = customer._MoneyBalance.ToString();
            TextBoxNewAmount.Clear();
            TextBoxNewAmount.BackColor = Color.Empty;
            LabelNewBalanceShow.Text = "";

        }
        //finished
        private void UpdateEditItemsTab(Customer customer)
        {
            LabelFirstNameEditItems.Text = customer._firstName;
            LabelDateofChangeEditItems.Text = customer._DateOfChange.ToString();
            LabelCurrentBalanceEditItem.Text = customer._MoneyBalance.ToString();
            TextBoxEMailEditItems.Text = customer._eMail.getEmailAdress();
            TextBoxLastNameEditItems.Text = customer._lastName;

        }
        //finished
        private bool CheckforLettersonly(string textbox)
        {
            if (!Regex.IsMatch(textbox, @"^[\p{L}]+$"))
            {
                return false;
            }
            
            return true;
        }
        //finsihed
        private void ClearTextBoxesEditBalanceItems()
        {
            LabelFirstNameEditBalance.Text = "";
            LabelLastNameEditBalance.Text = "";
            LabelE_MailAddressEditBalance.Text = "";
            LabelDateofChangeEditBalance.Text = "";
            LabelCurrentBalanceShow.Text = "";
            LabelNewBalanceShow.Text = "";
            TextBoxNewAmount.Clear();
            TextBoxNewAmount.BackColor = Color.Empty;

            LabelFirstNameEditItems.Text = "";
            LabelCurrentBalanceEditItem.Text = "";
            LabelDateofChangeEditItems.Text = "";
            TextBoxEMailEditItems.Clear();
            TextBoxEMailEditItems.BackColor = Color.Empty;
            TextBoxLastNameEditItems.Clear();
            TextBoxLastNameEditItems.BackColor = Color.Empty;
        }
        //finished
        private void ClearTextBoxesAddNewCustomer()
        {
            TextBoxAddFirstName.Clear();
            TextBoxAddFirstName.BackColor = Color.Empty;
            TextBoxAddLastName.Clear();
            TextBoxAddLastName.BackColor = Color.Empty;
            TextBoxAddE_Mail.Clear();
            TextBoxAddE_Mail.BackColor = Color.Empty;
            TextBoxAddNewAmount.Clear();
            TextBoxAddNewAmount.BackColor = Color.Empty;
        }
        //finished
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }







































        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void l(object sender, EventArgs e)
        {

        }
    }
}
