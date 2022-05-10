
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

        public int? ReportTextId { get; set; }
        /// <summary>
        /// Ответ на текстовый запрос
        /// </summary>
        public ReportText? ReportText { get; set; }


        /// <summary>
        /// Сдан ли отчет по этому назначению
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        public ReportRequestBase? GetReportRequest()
        {
            if (ReportRequestText is null && ReportRequestSurvey is null) throw new NullReferenceException();

            if (ReportRequestText is not null) return ReportRequestText;
            if (ReportRequestSurvey is not null) return ReportRequestSurvey;

            return null;
            
        }


    }
}
