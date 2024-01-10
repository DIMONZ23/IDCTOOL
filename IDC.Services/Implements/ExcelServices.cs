using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using IDC.Common.Models;
using IDC.Services.Interfaces;

namespace IDC.Services.Implements
{
    public class ExcelServices : IExcelServices
    {
        public OpenExcelData OpenExcel(string path)
        {
            using (var spreadsheetDocument = SpreadsheetDocument.Open(path, true))
            {
                var workbookPart = spreadsheetDocument.WorkbookPart;
                string sheetId = workbookPart.Workbook.Sheets.Elements<Sheet>().FirstOrDefault(x => x.Name == "Sheet1")?.Id;
                if (sheetId == null)
                    return null;
                WorksheetPart workSheetPart = (WorksheetPart)workbookPart.GetPartById(sheetId);
                var sheetData = workSheetPart.Worksheet.Elements<SheetData>().FirstOrDefault();
                var sharedStringTable = workbookPart.SharedStringTablePart.SharedStringTable;
                return new()
                {

                    SheetData = sheetData,
                    SharedStringTable = sharedStringTable
                };
            }
        }

        public void SaveExcelFile(SheetData excelData, string path)
        {

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(excelData);

                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();
            }
        }
        public string GetCellData(Cell cell, SharedStringTable sharedStringTable)
        {
            string cellValue = null;
            if (cell.DataType != null && cell.DataType == CellValues.SharedString)
            {
                int sharedStringIndex = int.Parse(cell.InnerText);
                if (sharedStringTable != null)
                {
                    SharedStringItem sharedStringItem = sharedStringTable.Elements<SharedStringItem>().ElementAt(sharedStringIndex);
                    cellValue = sharedStringItem.Text.Text;
                }
            }
            else
            {
                cellValue = cell.InnerText;
            }
            return cellValue;
        }
        static string GetColumnName(string cellReference)
        {
            // Assuming cellReference is in the form "A1"
            string columnName = "";

            foreach (char c in cellReference)
            {
                if (Char.IsLetter(c))
                {
                    columnName += c;
                }
                else
                {
                    // Once we encounter a non-letter character, stop appending to the column name
                    break;
                }
            }

            return columnName;
        }
        #region Merge
        private void AddData(Row row, SharedStringTable baseData, Row newRow)
        {
            foreach (var cell in row.Elements<Cell>())
            {
                var newCell = new Cell()
                {
                    CellValue = new CellValue(GetCellData(cell, baseData)),
                    DataType = CellValues.String,
                };
                newRow.Append(newCell);
            }
        }
        public SheetData MergeData(OpenExcelData baseData, OpenExcelData mergerData)
        {
            SheetData newData = new SheetData();

            bool nextbase = true;
            bool nextmerger = true;
            var baseRow = (baseData == null ? new List<Row>().GetEnumerator() : baseData.SheetData.Elements<Row>().GetEnumerator());
            var mergerRow = (mergerData == null ? new List<Row>().GetEnumerator() : mergerData.SheetData.Elements<Row>().GetEnumerator());
            while (nextbase || nextmerger)
            {
                {
                    var newRow = new Row();
                    nextbase = baseRow.MoveNext();
                    if (nextbase)
                        AddData(baseRow.Current, baseData.SharedStringTable, newRow);
                    nextmerger = mergerRow.MoveNext();
                    if (nextmerger)
                        AddData(mergerRow.Current, mergerData.SharedStringTable, newRow);
                    newData.Append(newRow);
                }
            }
            return newData;
        }
        #endregion
        
        #region Addition
        public SheetData AdditionRecord(OpenExcelData baseData, OpenExcelData AdditionData, int offset)
        {
            SheetData newData = null;
            if (baseData != null)
            {
                newData = new SheetData();
                var baseRows = baseData.SheetData.Elements<Row>();
                AppendData(baseRows, baseData.SharedStringTable, newData, -1);
            }
            if (AdditionData != null)
            {
                var additionRows = AdditionData.SheetData.Elements<Row>();
                if (newData == null)
                {
                    newData = new SheetData();
                    offset = -1;
                }
                AppendData(additionRows, AdditionData.SharedStringTable, newData, offset);
            }
            return newData;
        }
        private void AppendData(IEnumerable<Row> rows, SharedStringTable sharedStringTable, SheetData sheetData, int offset)
        {
            var headerRow = rows.FirstOrDefault();
            if (headerRow == null)
            {
                return;
            }
            if (offset != -1)
                rows = rows.Skip(offset);
            foreach (var row in rows)
            {
                var newRow = new Row();
                AddData(row, sharedStringTable, newRow);
                sheetData.Append(newRow);
            }
        }
        #endregion

    }
}
