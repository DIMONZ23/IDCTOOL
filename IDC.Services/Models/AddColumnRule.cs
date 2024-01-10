using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;

namespace IDC.Services.Models
{
    public class AddColumnRule : BaseRule
    {
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public AddColumnRule()
        {
            ProcessType = "AddColumn";
            ActionName = "Add a column";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            return null;
        }
    }
}
