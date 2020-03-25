using GemBox.Spreadsheet;

namespace Common
{
    public class Excel
    {
        public ExcelFile xlsWorkBook { get; set; }
        public SaveOptions xlsOptions { get; set; }
        private ExcelWorksheet xlsWorkSheet { get; set; }

        public Excel()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            xlsWorkBook = new ExcelFile();
            xlsWorkSheet = xlsWorkBook.Worksheets.Add("Sheet1");
            xlsOptions = SaveOptions.XlsDefault;

            var style = xlsWorkSheet.Rows[0].Style;
            style.Font.Weight = ExcelFont.BoldWeight;
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            xlsWorkSheet.Columns[0].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
        }

        public void WriteCell(int i, int j, string value) => xlsWorkSheet.Cells[i, j].Value = value;
    }
}