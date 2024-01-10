using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using IDC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public class CharacterLimitRule : BaseRule {
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int NumberOfColumn { get; set; }
        public int NumberOfRow { get; set; }
        public int CharacterLimit { get; set; }
        public CharacterLimitRule()
        {
            ProcessType = "CharacterLimit";
            ActionName = "Character limit";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            return null;
        }
    }
}
