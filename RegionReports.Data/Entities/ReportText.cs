using RegionReports.Data.Interfaces;

namespace RegionReports.Data.Entities
{
    public class ReportText : ReportBase, IReport
    {
        /// <summary>
        /// Текст ответа респондента в HTML
        /// </summary>
        public string RepsonseString { get; set; } = string.Empty;
    }
}