using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Запрос на предоставление информации в виде опроса
    /// </summary>
    public class ReportRequestSurvey
    {
        public int Id { get; set; }

        /// <summary>
        /// Возможность выбора нескольких пунктов
        /// </summary>
        public bool MultipleChoises { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        /// <summary>
        /// Список вариантов ответа в опросе
        /// </summary>
        public List<ReportRequestSurveyOption> Options { get; set; } = new List<ReportRequestSurveyOption>();
    }

    /// <summary>
    /// Опция для выбора в отчете
    /// </summary>
    public class ReportRequestSurveyOption
    {
        public int Id { get; set; }

        /// <summary>
        /// Пункт для выбора в опросе
        /// </summary>
        public string OptionName { get; set; } = string.Empty;

        public int ReportRequestSurveyId { get; set; }
        
        /// <summary>
        /// Ссылка на запрос, к которому относится этот пункт 
        /// </summary>
        public ReportRequestSurvey? ReportRequestSurvey { get; set; }
    }
}
