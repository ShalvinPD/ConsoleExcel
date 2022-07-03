using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace ConsoleExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteSample();
        }
        public static void WriteSample()
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets.Add();

                excelWorksheet.Cells[1, 1] = "Value1";
                excelWorksheet.Cells[2, 1] = "Value2";
                excelWorksheet.Cells[3, 1] = "Value3";
                excelWorksheet.Cells[4, 1] = "Value4";

                excelApp.ActiveWorkbook.SaveAs(@"D:\abc.xls", Excel.XlFileFormat.xlWorkbookNormal);

                excelWorkbook.Close();
                excelApp.Quit();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelWorkbook);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

    }
}
