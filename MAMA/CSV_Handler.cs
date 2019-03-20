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
        private Excel.Workbook _MyBook = null;
        private Excel.Application _MyApp = null;
        private Excel.Worksheet _MySheet = null;

        public CSV_Handler()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"MAMA.xlsx");
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
        }

        public void exportToExcel(DataGridView data)
        {
            
        }

    }
}
