namespace RegionReports.Data.Entities
{
    public  class ReportAssignmentGroup
    {
        public int Id { get; set; }

        public List<ReportAssignment> Assignments { get; set; }

        public DateTime DateAssigned { get; set; } = DateTime.Now;

        public int? ReportRequestTextId { get; set; }
        public ReportRequestText? ReportRequestText { get; set; }
        public int? ReportRequestSurveyId { get; set; }
        public ReportRequestSurvey? ReportRequestSurvey { get; set; }

        public ReportRequestWithFile? ReportRequestWithFile { get; set; }

        /// <summary>
        /// Дата назначения истекла
        /// </summary>
        public bool IsOverdued { get; set; }

        /// <summary>
        /// Крайний срок предоставления по этому назначению
        /// </summary>
        public DateTime ActualDeadline { get; set; }

        public ReportRequestBase? GetReportRequest()
        {
            if (ReportRequestText is null && ReportRequestSurvey is null && ReportRequestWithFile is null) throw new NullReferenceException();

            if (ReportRequestText is not null) return ReportRequestText;
            if (ReportRequestSurvey is not null) return ReportRequestSurvey;
            if (ReportRequestWithFile is not null) return ReportRequestWithFile;

            return null;

        }

        public string GetRequestTypeName()
        {
            if (ReportRequestText is null && ReportRequestSurvey is null && ReportRequestWithFile is null) throw new NullReferenceException();

            if (ReportRequestText is not null) return "Текстовый запрос";
            if (ReportRequestSurvey is not null) return "Запрос отчета";
            if (ReportRequestWithFile is not null) return "Запрос с файлом";


            return string.Empty;
        }


    }
}
