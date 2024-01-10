using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public class ItemBondingRule : BaseRule {
        public int ColumnIndex { get; set; }
        public string ColumnName { get; set; }
        public string BondingText { get; set; }
        public bool IsFront { get; set; }
        public ItemBondingRule()
        {
            ProcessType = "ItemBounding";
            ActionName = "Add text before or after";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo) {
            return null;
        }
    }
}
