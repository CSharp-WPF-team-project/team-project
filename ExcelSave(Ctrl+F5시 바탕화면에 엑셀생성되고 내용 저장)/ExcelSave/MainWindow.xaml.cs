using ExcelSave.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace ExcelSave
{
    public partial class MainWindow : Window
    {
        //필드
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;

        public MainWindow()
        {
            InitializeComponent();
            //데이터 추가
            beverageData.GetInstance().Add(new beverageData() { kind = "탄산", name = "환타", price = 1100 });
            beverageData.GetInstance().Add(new beverageData() { kind = "탄산", name = "콜라", price = 1000 });
            beverageData.GetInstance().Add(new beverageData() { kind = "비탄산", name = "토레타", price = 1800 });
            //xaml부분에서 추가
            beverageView.ItemsSource = beverageData.GetInstance();

            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = System.IO.Path.Combine(desktopPath, "Excel.xlsx");

                excelApp = new Excel.Application();
                workBook = excelApp.Workbooks.Add();
                workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;

                workSheet.Cells[1, 1] = c1.Header.ToString();
                workSheet.Cells[1, 2] = c2.Header.ToString();
                workSheet.Cells[1, 3] = c3.Header.ToString();

                for(int i = 0; i<beverageView.Items.Count;i++)
                {
                    beverageData b_Data = beverageData.GetInstance().ElementAt(i);
                    workSheet.Cells[2 + i, 1] =b_Data.kind;
                    workSheet.Cells[2 + i, 2] = b_Data.name;
                    workSheet.Cells[2 + i, 3] = b_Data.price;
                }

                workSheet.Columns.AutoFit();
                workSheet.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                workBook.Close(true);
                excelApp.Quit();
            }
            finally
            {
                ReleaseObject(workSheet);
                ReleaseObject(workBook);
                ReleaseObject(excelApp);
            }
        }

        static void ReleaseObject(object obj)
        {
            try 
            { 
                if(obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch(Exception ex) 
            { 
                obj = null; 
                throw ex; 
            }
            finally { GC.Collect(); }
        }
    }
}
