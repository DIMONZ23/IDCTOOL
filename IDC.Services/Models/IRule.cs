using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Models {
    public interface IRule {
        SheetData Execute(IExcelServices excelSvc, ProjectInfo projectInfo);
    }
}
