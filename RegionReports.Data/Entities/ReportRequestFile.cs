using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Файл к запросу текстового отчета
    /// </summary>
    public class ReportRequestFile
    {
        public int Id { get; set; }

        public string FileUniqueName { get; set; } = "";

        public int ReportRequestTextId { get; set; }

        public ReportRequestText RelatedReportText { get; set; }

    }
}
