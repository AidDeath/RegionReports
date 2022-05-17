using RegionReports.Data.Entities;
using RegionReports.Data.Repositories;

namespace RegionReports.Data.Interfaces
{
    public interface IDbAccessor
    {
        public IRepository<Region> Regions { get; }

        public ReportUserRepository ReportUsers { get; }

        public IRepository<District> Districts { get; }
        
        public IReportUserApprovalClaimRepository ReportUserApprovalClaims { get; }

        public IRepository<ReportRequestSurvey> ReportRequestsSurvey { get; }

        public IRepository<ReportRequestText> ReportRequestsText { get; }

        public IRepository<UploadableFileType> UploadableFileTypes { get; }

        /// <summary>
        /// Назначения отчетов
        /// </summary>
        public IRepository<ReportAssignment> ReportAssignments { get; }

        /// <summary>
        /// Результаты отчета - текст
        /// </summary>
        public IRepository<ReportText> ReportsText { get; }
        /// <summary>
        /// Результаты отчета - опроса
        /// </summary>
        public IRepository<ReportSurvey> ReportsSurvey { get; }
        
        /// <summary>
        /// Расписания отчетов
        /// </summary>
        public IRepository<ReportSchedule> ReportSchedules { get; }

        /// <summary>
        /// Группы назначений отчетов
        /// </summary>
        public IRepository<ReportAssignmentGroup> AssignmentGroups { get; }

    }
}
