using IDC.Services.Interfaces;
using Microsoft.Win32;
using System.Windows;

namespace IDC.App.Views
{
    /// <summary>
    /// Interaction logic for ExcelTest.xaml
    /// </summary>
    public partial class ExcelTest : Window
    {
        private readonly IExcelServices _excelSvc;
        public ExcelTest(IExcelServices excel_svc)
        {
            InitializeComponent();
            _excelSvc = excel_svc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "Chọn file base";
            ofd.Filter = "*.xlsx|*xlsx";
            if(ofd.ShowDialog() == true)
                lbl1.Content = ofd.FileName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "Chọn file base";
            ofd.Filter = "*.xlsx|*xlsx";
            if (ofd.ShowDialog() == true)
                lbl2.Content = ofd.FileName;
        }

        private void mergeBtn_Click(object sender, RoutedEventArgs e)
        {
            var baseFile = _excelSvc.OpenExcel(lbl1.Content.ToString());
            var mergerFile = _excelSvc.OpenExcel(lbl2.Content.ToString());
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "xlsx|*.xlsx",
                Title = "Lưu file excel"
            };
            if(saveFileDialog.ShowDialog() == true)
            {
                var data = _excelSvc.MergeData(baseFile, mergerFile);
                _excelSvc.SaveExcelFile(data,saveFileDialog.FileName);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var baseFile = _excelSvc.OpenExcel(lbl1.Content.ToString());
            var additionFile = _excelSvc.OpenExcel(lbl2.Content.ToString());
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "xlsx|*.xlsx",
                Title = "Lưu file excel"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                var data = _excelSvc.AdditionRecord(baseFile, additionFile,1);
                _excelSvc.SaveExcelFile(data, saveFileDialog.FileName);
            }
        }
    }
}
