
namespace RegionReports.Data.Entities
{
    public class ReportAssignment
    {
        public int Id { get; set; }

        public int ReportUserId { get; set; }
        public ReportUser ReportUser { get; set; }

        public DateTime DateAssigned { get; set; } = DateTime.Now;

        public int? ReportRequestTextId { get; set; }
        public ReportRequestText? ReportRequestText { get; set; }
        public int? ReportRequestSurveyId { get; set; }
        public ReportRequestSurvey? ReportRequestSurvey { get; set; }

        public int? ReportSurveyId { get; set; }
        /// <summary>
        /// Ответы на опрос
        /// </summary>
        public ReportSurvey? ReportSurvey { get; set; }


        //TODO: Добавить ответы на текстовый запрос

        /// <summary>
        /// Сдан ли отчет по этому назначению
        /// </summary>
        public bool IsCompleted { get; set; } = false;

    }
}
