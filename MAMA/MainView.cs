using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAMA
{
    public partial class MainView : Form
    {
        private Controller Controller;

        public MainView()
        {
            InitializeComponent();
        }

        public void SetContoller(Controller controller)
        {
            Controller = controller;
        }


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
                DataGridViewCustomers.Rows[number].Cells[4].Value = customers[i].DateOfChange;
                DataGridViewCustomers.Rows[number].Cells[5].Value = customers[i].MoneyBalance;
            }

        }

        
        //Check the Name of the ButtonClicked and to reference to the functions
        private void ButtonClicked(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button btn = (Button) sender;

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

        /// Clicked Item Handeling of the Menustrip
        /// OpenFiler Handler
        private void OpenfileHandler(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            // only for csv 
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                
                Controller.GetCustomerList(filepath);

            }
            
        }

        /// SaveFile Handler for a new File 
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
        private void SaveCurrentFile(object sender, EventArgs e)
        {

        }

        
        private void TextBoxChangedMainTabControll(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txBox = (TextBox)sender;

                if (txBox == TextBoxAddFirstName)
                {

                }
                if (txBox == TextBoxAddLastName)
                {

                }
                if (txBox == TextBoxAddE_Mail)
                {

                }
                if (txBox == TextBoxAddCreationDate)
                {

                }
                if (txBox == TextBoxAddNewAmount)
                {

                }
            }


        }
        ///Is responsible for a listed user to change the items
        private void TextBoxChangedTabControllEditItems(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox txBox = (TextBox) sender;

                //Check Input Balance
                if (txBox.Name == TextBoxNewAmount.Name)
                {

                }
                if (txBox.Name == TextBoxNewBalance.Name)
                {

                }
                if (txBox.Name == TextBoxCurrentBalance.Name)
                {

                }
                //Check Input Edit Items 
                if (txBox.Name == TextBoxLastNameEditItems.Name)
                {

                }
                if (txBox.Name == TextBoxEMailEditItems.Name)
                {

                }
            }
        }

















































        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
