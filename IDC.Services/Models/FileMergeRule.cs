using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;

namespace IDC.Services.Models
{
    public class FileMergeRule : BaseRule
    {
        public string FileFormat { get; set; }
        public string Encoding { get; set; }
        public string AddFilePath { get; set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int ColumnNumbers { get; set; }
        public int RowNumbers { get; set; }
        public FileMergeRule()
        {
            ProcessType = "Merge";
            ActionName = "Merge files";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            var baseFile = excelSvc.OpenExcel(projectInfo.BaseFilePath);
            var mergerFile = excelSvc.OpenExcel(this.AddFilePath);
            var data = excelSvc.MergeData(baseFile, mergerFile);
            return data;
        }
    }
}
