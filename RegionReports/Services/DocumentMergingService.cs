using ClosedXML.Excel;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Data;

namespace RegionReports.Services
{
    public class DocumentMergingService
    {
        public MemoryStream GetMergedPdfStream(IEnumerable<string> pathList)
        {
            var mergedPdf = new PdfDocument();

            foreach (string path in pathList)
            {
                if (File.Exists(path))
                    using (PdfDocument importingDoc = PdfReader.Open(path, PdfDocumentOpenMode.Import))
                        for (int i = 0; i < importingDoc.PageCount; i++)
                            mergedPdf.AddPage(importingDoc.Pages[i]);
            }

            var memStream = new MemoryStream();

            mergedPdf.Save(memStream, false);
            return memStream;
        }

        public MemoryStream GetMergedExcelStream(IEnumerable<string> pathList)
        {
            DataSet ds = new DataSet();

            foreach (string filePath in pathList)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                using (XLWorkbook workBook = new XLWorkbook(fileStream))
                {
                    IXLWorksheet workSheet = workBook.Worksheet(1);
                    DataTable dt = new DataTable();
                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }
                    }

                    ds.Tables.Add(dt);
                }
            }

            DataTable dtMerge = ds.Tables[0].Clone();
            foreach (DataTable table in ds.Tables)
            {
                dtMerge.Merge(table);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtMerge);

                //using (FileStream fileStream = new FileStream(@"d:\joinedXL.xlsx", FileMode.Create))
                //    wb.SaveAs(fileStream);

                MemoryStream stream = new MemoryStream();
                wb.SaveAs(stream);

                return stream;

                //return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Merge.xlsx");
            }
        }
    }
}