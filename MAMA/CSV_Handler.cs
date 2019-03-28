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
        public CSV_Handler()
        {
            
        }
        
        /// <summary>
        /// Exports the Data in customerData to a CSV File
        /// </summary>
        /// <param name="path">File-Path</param>
        /// <param name="customerData">Customer Data</param>
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
                    string eMailAddress = myCustomer._eMail.getEmailAddress();
                    string dateOfChange = myCustomer._DateOfChange.ToString();
                    string moneyBalance = Convert.ToString(myCustomer._MoneyBalance);

                    string text = Convert.ToString(customerNumber) + ";" + firstName + ";" + lastName + ";" + eMailAddress + ";" + dateOfChange + ";" + moneyBalance;
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

        /// <summary>
        /// Reads the Customer-Data at path
        /// </summary>
        /// <param name="path">File-path</param>
        /// <returns></returns>
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
                    string eMailAddress = data[3].ToString();                    
                    DateTime DateOfChange = Convert.ToDateTime(data[4]);
                    string moneyBalanceAsString = data[5];

                    float moneyBalance;
                    float.TryParse(moneyBalanceAsString, out moneyBalance);
                    Customer myCustomer = new Customer(firstName, lastName, eMailAddress, customerNumber, moneyBalance, DateOfChange);

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
