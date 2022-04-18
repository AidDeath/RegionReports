﻿using System;
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

    }

    /// <summary>
    /// Файл к запросу текстового отчета
    /// </summary>
    public class ReportRequestFile
    {
        public int Id { get; set; }

        [JsonPropertyName("fileUniqueName")]
        public string FileUniqueName { get; set; } = "";

        [JsonPropertyName("FileOriginalName")]
        public string FileOriginalName { get; set; } = "";

        public int ReportRequestTextId { get; set; }

        public ReportRequestText RelatedReportText { get; set; }

    }
}
