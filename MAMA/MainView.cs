using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAMA
{
    public partial class MainView : Form
    {
        private Controller Controller;
        private bool EnableButtonSaveNewBalance = false;
        private bool EnableButtonSaveEditItems = false;
        private bool EnableButtonAddNewCustomer = false;

        public MainView()
        {
            InitializeComponent();
            ButtonAddNewCustomer.Enabled = false;
            ButtonSaveEditItems.Enabled = false;
            ButtonSaveNewBalance.Enabled = false;
        }

        public void SetContoller(Controller controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// still to finish
        /// </summary>
        /// <param name="customers"></param>
        public void UpdateDataGridview(List<Customer> customers)
        {

            //Skalierung 
            //DataGridViewCustomers = customers;
            DataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewCustomers.Update();

            for (int i = 0; i < customers.Count; i++)
            {
                int number = DataGridViewCustomers.Rows.Add();
                DataGridViewCustomers.Rows[number].Cells[0].Value = customers[i]._customerNumber;
                DataGridViewCustomers.Rows[number].Cells[1].Value = customers[i]._firstName;
                DataGridViewCustomers.Rows[number].Cells[2].Value = customers[i]._lastName;
                DataGridViewCustomers.Rows[number].Cells[3].Value = customers[i]._eMail;
                DataGridViewCustomers.Rows[number].Cells[4].Value = customers[i]._DateOfChange;
                DataGridViewCustomers.Rows[number].Cells[5].Value = customers[i]._MoneyBalance;
            }

        }

        
        //Check the Name of the ButtonClicked and to reference to the functions
        private void ButtonClickedEditItemsofCustomer(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button)sender;

                if (btn == ButtonSaveNewBalance)
                {

                }
                if (btn == ButtonCancelNewBalance)
                {

                }
                if (btn == ButtonSaveEditItems)
                {

                }
                if (btn == ButtonCancelEditItems)
                {

                }
                if(btn == ButtonAddNewAmount)
                {

                }
                if (btn == ButtonSubNewAmount)
                {

                }
                
            }

        }
        
        //to do
        private void ButtonClickedAddCustomer(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button) sender;

                if (btn == ButtonAddNewCustomer)
                {

                }
                else if (btn == ButtonCancelNewCustomer)
                {
                    
                }
            }

        }
        
        //to finish
        private void TextBoxChangedMainTabControll(object sender, EventArgs e)
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
                    }
                    else
                    {
                        TextBoxAddFirstName.BackColor = Color.Red;
                    }

                }
                else if (txBox == TextBoxAddLastName)
                {
                    bool textOk = CheckforLettersonly(TextBoxAddLastName.Text);

                    if (textOk && TextBoxAddLastName.Text.Length > 2)
                    {
                        TextBoxAddLastName.BackColor = Color.Green;
                    }
                    else
                    {
                        TextBoxAddLastName.BackColor = Color.Red;
                    }

                }
                else if (txBox == TextBoxAddE_Mail)
                {
                    EMailAdress eMailAdress = new EMailAdress(TextBoxAddE_Mail.Text);
                    if (eMailAdress.Address != string.Empty && eMailAdress.Address != string.Empty)
                    {
                        TextBoxAddE_Mail.BackColor = Color.Green;
                    }
                    else
                    {
                        TextBoxAddE_Mail.BackColor = Color.Red;
                    }


                }
                else if (txBox == TextBoxAddNewAmount)
                {
                    decimal moneyBalance;
                    if (decimal.TryParse(TextBoxAddNewAmount.Text,out moneyBalance))
                    {
                        TextBoxAddNewAmount.BackColor = Color.Green;
                    }
                    else
                    {
                        TextBoxAddNewAmount.BackColor = Color.Red;
                    }
                    
                }

                
            }


        }

        // to finish
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
                    }
                    else
                    {
                        TextBoxNewAmount.BackColor = Color.Red;
                    }

                }

                //Check Input Edit Items 
                else if (txBox == TextBoxLastNameEditItems)
                {
                    if (CheckforLettersonly(TextBoxLastNameEditItems.Text) && TextBoxLastNameEditItems.Text.Length > 2)
                    {
                        TextBoxLastNameEditItems.BackColor = Color.Green;
                    }
                    else
                    {
                        TextBoxLastNameEditItems.BackColor = Color.Red;
                    }

                }
                else if (txBox == TextBoxEMailEditItems)
                {
                    EMailAdress eMailAdress = new EMailAdress(TextBoxEMailEditItems.Text);
                    if (eMailAdress.Address != string.Empty && eMailAdress.Address != string.Empty)
                    {
                        TextBoxEMailEditItems.BackColor = Color.Green;
                    }
                    else
                    {
                        TextBoxEMailEditItems.BackColor = Color.Red;
                    }

                }
            }
        }

        /// Clicked Item Handeling of the Menustrip
        /// OpenFiler Handler
        /// good
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

                Controller.GetCustomerList(filepath);


            }

        }

        /// SaveFile Handler for a new File
        /// to finish 
        private void SavefileHandler(object sender, EventArgs e)
        {
            Stream myStream;
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    // Attention new CSV Handler

                }
            }

        }

        /// Save File Handler for existing File
        /// to do
        private void SaveCurrentFile(object sender, EventArgs e)
        {

        }

        //to do
        private void DataGridviewSelectedRow(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(DataGridView))
            {
                if ((DataGridView) sender == DataGridViewCustomers)
                {
                    
                }

            }


        }


        //good
        private bool CheckforLettersonly(string textbox)
        {
            if (!Regex.IsMatch(textbox, @"^[\p{L}]+$"))
            {
                return false;
            }
            
            return true;
        }















































        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
