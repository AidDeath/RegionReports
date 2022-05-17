
namespace RegionReports.Data.Entities
{
#nullable disable
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
        /// Крайний срок предоставления по этому назначению
        /// </summary>
        public DateTime ActualDeadline { get; set; }

        /// <summary>
        /// Сдан ли отчет по этому назначению
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Назначение просрочено, в связи с выдачей следующего по расписанию, или из-за невыполнения.
        /// </summary>
        public bool IsCancelledByOverDue { get; set; }

        /// <summary>
        /// Группа назначений отчета
        /// </summary>
        public ReportAssignmentGroup ReportAssignmentGroup { get; set; }

        public ReportRequestBase? GetReportRequest()
        {
            if (ReportRequestText is null && ReportRequestSurvey is null) throw new NullReferenceException();

            if (ReportRequestText is not null) return ReportRequestText;
            if (ReportRequestSurvey is not null) return ReportRequestSurvey;

            return null;
            
        }

        public ReportBase GetReportBase()
        {
            if (ReportText is null && ReportSurvey is null) throw new NullReferenceException();

            if (ReportText is not null) return ReportText;
            if (ReportSurvey is not null) return ReportSurvey;

            return null;
        }


    }
}
