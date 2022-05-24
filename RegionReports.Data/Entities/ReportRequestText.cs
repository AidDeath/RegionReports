using RegionReports.Data.Interfaces;
using System.Text.Json.Serialization;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Запрос текстового отчета
    /// </summary>
    public class ReportRequestText : ReportRequestBase, IReportRequest
    {
        public int Id { get; set; }

        /// <summary>
        /// Перечень файлов прикрепленных к запросу
        /// </summary>
        public List<ReportRequestFile>? Files { get; set; }

    }

    /// <summary>
    /// Файл к запросу текстового отчета
    /// </summary>
    public class ReportRequestFile : ReportFileBase
    {
        [JsonPropertyName("reportRequestTextId")]
        public int ReportRequestTextId { get; set; }
        public ReportRequestText RelatedReportText { get; set; }

    }
}
