using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Запрос текстового отчета
    /// </summary>
    public class ReportRequestText
    {
        public int Id { get; set; }

        /// <summary>
        /// Заголовок запроса текстового отчета
        /// </summary>
        public string RequestTitle { get; set; } = "";

        public string RequestText { get; set; } = "";

        /// <summary>
        /// Перечень файлов прикрепленных к запросу
        /// </summary>
        public List<ReportRequestFile>? Files { get; set; }

        /// <summary>
        /// Назначено ли расписание для запроса
        /// </summary>
        public bool IsSchedulledRequest { get; set; } = false;


        /// <summary>
        /// Срок сдачи отчета. Заполняется в случае отсутствия расписания
        /// </summary>
        public DateTime? NonScheduledDeadline { get; set; }

        /// <summary>
        /// Идентификатор расписания, если задано
        /// </summary>
        public int? ReportScheduleId { get; set; }
        public ReportSchedule? ReportSchedule { get; set; }

    }

    /// <summary>
    /// Файл к запросу текстового отчета
    /// </summary>
    public class ReportRequestFile
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fileUniqueName")]
        public string FileUniqueName { get; set; } = "";

        [JsonPropertyName("fileOriginalName")]
        public string FileOriginalName { get; set; } = "";

        [JsonPropertyName("fileType")]
        public int FileType { get; set; }

        [JsonPropertyName("reportRequestTextId")]
        public int ReportRequestTextId { get; set; }

        public ReportRequestText RelatedReportText { get; set; }

    }
}
