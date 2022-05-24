
namespace RegionReports.Data.Entities
{
#nullable disable
    public class ReportAssignment
    {
        public int Id { get; set; }

        public int ReportUserId { get; set; }
        public ReportUser ReportUser { get; set; }


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

        public int? ReportWithFileId { get; set; }
        public ReportWithFile? ReportWithFile { get; set; }

        /// <summary>
        /// Сдан ли отчет по этому назначению
        /// </summary>
        public bool IsCompleted { get; set; } = false;


        /// <summary>
        /// Группа назначений отчета
        /// </summary>
        public ReportAssignmentGroup ReportAssignmentGroup { get; set; }

        public ReportBase GetReportBase()
        {
            if (ReportText is null && ReportSurvey is null && ReportWithFile is null) throw new NullReferenceException();

            if (ReportText is not null) return ReportText;
            if (ReportSurvey is not null) return ReportSurvey;
            if (ReportWithFile is not null) return ReportWithFile;

            return null;
        }


    }
}
