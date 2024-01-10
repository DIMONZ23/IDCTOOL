using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Services.Interfaces
{
    public interface IExcelServices
    {
        void SaveExcelFile(SheetData data, string path);
        OpenExcelData OpenExcel(string path);
        SheetData MergeData(OpenExcelData baseData, OpenExcelData mergerData);
        SheetData AdditionRecord(OpenExcelData baseData, OpenExcelData AdditionData, int offset);
    }
}
