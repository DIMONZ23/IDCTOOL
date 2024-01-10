using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models
{
    public class AdditionalRecordRule : BaseRule
    {
        public string FileFormat { get; set; }
        public string Encoding { get; set; }
        public string AddFilePath { get; set; }
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int ColumnNumbers { get; set; }
        public int RowNumbers { get; set; }
        public AdditionalRecordRule()
        {
            ProcessType = "AdditionalRecord";
            ActionName = "Additional Record";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            var baseFile = excelSvc.OpenExcel(projectInfo.BaseFilePath);
            var addFile = excelSvc.OpenExcel(this.AddFilePath);
            var data = excelSvc.AdditionRecord(baseFile, addFile, projectInfo.StartRow);
            return data;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"{FileFormat}\n");
            sb.Append($"{Encoding}\n");
            sb.Append($"{AddFilePath}\n");
            sb.Append($"{StartRow}\n");
            sb.Append($"{StartColumn}\n");
            sb.Append($"{ColumnNumbers}\n");
            sb.Append($"{RowNumbers}\n");
            return sb.ToString();
        }
    }
}
