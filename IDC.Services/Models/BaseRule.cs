using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;

namespace IDC.Services.Models
{
    public abstract class BaseRule : IRule
    {
        public string? ProcessType { get; set; }
        public string? Action { get; set; }
        public string? ActionName { get; set; }
        public int ProjectInfoId { get; set; }
        public int Priority { get; set; }
        public virtual SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            return null;
        }
    }
}
