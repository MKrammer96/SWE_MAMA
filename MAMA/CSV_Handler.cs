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
        private Excel.Workbook _myBook = null;
        private Excel.Application _myApp = null;
        private Excel.Worksheet _mySheet = null;

        public CSV_Handler()
        {
            
        }

        public void exportToExcel(DataGridView data)
        {
            _myApp = new Excel.Application();
            _myApp.Visible = true;

            _myBook = _myApp.Workbooks.Add();

            _mySheet = _myBook.Worksheets[1];

            _mySheet.Cells[1, 1] = "ID";
            _mySheet.Cells[2, 1] = "Last Name";
            _mySheet.Cells[3, 1] = "First Name";
            _mySheet.Cells[4, 1] = "Date of Change";
            _mySheet.Cells[5, 1] = "Current Balance";
            _mySheet.Cells[6, 1] = "Password";

            string filename = "C:/Users/Mani/Desktop";
            _myBook.SaveAs(filename);
        }

    }
}
