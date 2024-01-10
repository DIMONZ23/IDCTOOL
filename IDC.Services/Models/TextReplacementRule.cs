using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using IDC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public class TextReplacementRule : BaseRule {
        public string FilePath { get; set; }
        public string OldText { get; set; }
        public string NewText { get; set; }
        public TextReplacementRule()
        {
            ProcessType = "TextReplacement";
            ActionName = "Text Replacement Rule";
        }
        public override SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo)
        {
            return null;
        }
    }
}
