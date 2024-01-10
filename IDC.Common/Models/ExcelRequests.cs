using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDC.Common.Models
{
    public class ExcelRequest
    {
        public string? Path { get; set; }
        public string? FileName { get; set; }
        public Encoding? Encoding { get; set; }
        public SheetData? Data { get; set; }
    }
    public class ExcelData
    {
        public SheetData? BaseData { get; set; }
        public SheetData? ProcessData { get; set; }
    }
    public class OpenExcelData
    {
        public SheetData SheetData { get; set; }
        public SharedStringTable SharedStringTable { get; set; }
    }
}
