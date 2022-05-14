using RegionReports.Data.Entities;

namespace RegionReports.Data.Interfaces
{
    public interface IReportRequest
    {
        /// <summary>
        /// Заголовок запроса
        /// </summary>
        public string RequestTitle { get; set; }
        /// <summary>
        /// Текст запроса
        /// </summary>
        public string RequestText { get; set; }

        /// <summary>
        /// Назначено ли расписание для запроса
        /// </summary>
        public bool IsSchedulledRequest { get; set; }

        /// <summary>
        /// Идентификатор расписания, если задано
        /// </summary>
        public int? ReportScheduleId { get; set; }
        public ReportSchedule? ReportSchedule { get; set; }

        /// <summary>
        /// Дата и время создания запроса
        /// </summary>
        public DateTime DateCreated { get; set; }

    }
}
