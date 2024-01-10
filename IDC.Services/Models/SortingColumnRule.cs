using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public class SortingColumnRule : BaseRule {
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public SortingColumnRule()
        {
            ProcessType = "SortingColumn";
            ActionName = "Sorting column";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            return null;
        }
    }
}
