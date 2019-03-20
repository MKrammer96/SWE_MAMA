using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

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
        
        /// <summary> 
        /// Exports the datagridview values to Excel. 
        /// </summary> 
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
        
    }
}
