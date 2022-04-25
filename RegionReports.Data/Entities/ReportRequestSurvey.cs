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
        /// Заголовок опроса
        /// </summary>
        public string RequestTitle { get; set; } = "";

        public string Question { get; set; } = "";

        /// <summary>
        /// Возможность выбора нескольких пунктов
        /// </summary>
        public bool MultipleChoises { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        /// <summary>
        /// Список вариантов ответа в опросе
        /// </summary>
        public List<ReportRequestSurveyOption> Options { get; set; } = new List<ReportRequestSurveyOption>();

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
