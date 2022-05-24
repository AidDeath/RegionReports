using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace RegionReports.Services
{
    public class PdfService
    {
        public MemoryStream GetMergedPdfStream(IEnumerable<string> pathList)
        {
            var mergedPdf = new PdfDocument();

            foreach(string path in pathList)
            {
                if(File.Exists(path)) 
                using (PdfDocument importingDoc = PdfReader.Open(path, PdfDocumentOpenMode.Import))
                    for (int i = 0; i < importingDoc.PageCount; i++)
                        mergedPdf.AddPage(importingDoc.Pages[i]);
            }

            var memStream = new MemoryStream();
            
            mergedPdf.Save(memStream, false);
            return memStream;
            

        }
    }
}
