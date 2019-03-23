using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;

namespace MAMA
{
    public class CSV_Handler
    {
        private Excel.Workbook _myBook;
        private Excel.Application _myApp;
        private Excel.Worksheet _mySheet;

        public CSV_Handler()
        {
            // Creating a Excel object. 
            _myApp = new Excel.Application();
            _myBook = _myApp.Workbooks.Add(Type.Missing);
            _mySheet = null;
        }
        

        public void ExportToExcel(DataGridView gridData)
        {
            try
            {
                _mySheet = _myBook.ActiveSheet;

                _mySheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < gridData.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < gridData.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            _mySheet.Cells[cellRowIndex, cellColumnIndex] = gridData.Columns[j].HeaderText;
                        }
                        else
                        {
                            _mySheet.Cells[cellRowIndex, cellColumnIndex] = gridData.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    _myBook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _myApp.Quit();
                _myBook = null;
                _myApp = null;
            }

        }
        
        public void ExportToCSV(string path, List<Customer> customerData)
        {
            List<string> dataToWrite = new List<string>();
            StreamWriter csvFileWriter = StreamWriter.Null;
            
            try
            {
                csvFileWriter = new StreamWriter(path);
                string header = "CustomerID;FirstName;LastName;E-Mail;DateofChange;MoneyBalance";

                dataToWrite.Add(header);

                for (int i = 0; i < customerData.Count; i++)
                {
                    Customer myCustomer = customerData[i];

                    int customerNumber = myCustomer._customerNumber;
                    string firstName = myCustomer._firstName;
                    string lastName = myCustomer._lastName;
                    string eMailAdress = myCustomer._eMail.getEmailAdress();
                    string dateOfChange = myCustomer._DateOfChange.ToString();
                    string moneyBalance = Convert.ToString(myCustomer._MoneyBalance);

                    string text = Convert.ToString(customerNumber) + ";" + firstName + ";" + lastName + ";" + eMailAdress + ";" + dateOfChange + ";" + moneyBalance;
                    dataToWrite.Add(text);
                }

                
                foreach (string text in dataToWrite)
                {
                    csvFileWriter.WriteLine(text);
                }

                MessageBox.Show("Save successful");

            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
            }

            finally
            {
                csvFileWriter.Flush();
                csvFileWriter.Close();
            }
        }

        public List<Customer> readCSV(string path)
        {
            StreamReader myReader = StreamReader.Null;
            try
            {
                myReader = new StreamReader(path);
                string textLine = string.Empty;
                string[] splitLine;
                List<string[]> customerDataAsString = new List<string[]>();
                List<Customer> customerData = new List<Customer>();

                if (File.Exists(path))
                {
                    myReader = new StreamReader(path);

                    while (!myReader.EndOfStream)
                    {
                        textLine = myReader.ReadLine();
                        if (textLine != "")
                        {
                            splitLine = textLine.Split(';');
                            customerDataAsString.Add(splitLine);
                        }
                    }
                }

                // Start at 1 - Line1 = Header
                for (int i = 1; i < customerDataAsString.Count; i++)
                {
                    string[] data = customerDataAsString[i];

                    int customerNumber = Convert.ToInt16(data[0]);
                    string firstName = data[1];
                    string lastName = data[2];
                    string eMailAdress = data[3].ToString();                    
                    DateTime DateOfChange = Convert.ToDateTime(data[4]);
                    string moneyBalanceAsString = data[5];

                    float moneyBalance;
                    float.TryParse(moneyBalanceAsString, out moneyBalance);
                    Customer myCustomer = new Customer(firstName, lastName, eMailAdress, customerNumber, moneyBalance, DateOfChange);

                    customerData.Add(myCustomer);
                }

                return customerData;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The process cannot access the file"))
                {
                    MessageBox.Show("The file you are importing is open.", "Import Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

                return null;
            }
            finally
            {
                myReader.Close();
            }
        }
    }
}
