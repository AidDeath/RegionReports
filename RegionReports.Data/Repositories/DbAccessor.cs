using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

namespace RegionReports.Data.Repositories
{
    public class DbAccessor : IDbAccessor
    {
        private readonly RegionReportsContext _context;
        public DbAccessor(RegionReportsContext context) => _context = context;

        private IRepository<District> _districts { get; set; }
        public IRepository<District> Districts => _districts ??= new Repository<District>(_context); 

        private IRepository<Region> _regions { get; set; }
        public IRepository<Region> Regions => _regions ??= new Repository<Region>(_context);

        private ReportUserRepository _reportUsers { get; set; }
        public ReportUserRepository ReportUsers => _reportUsers ??= new ReportUserRepository(_context);

        private IReportUserApprovalClaimRepository _reportUserApprovalClaims { get; set; }
        public IReportUserApprovalClaimRepository ReportUserApprovalClaims => _reportUserApprovalClaims ??= new ReportUserApprovalClaimRepository(_context);

        private IRepository<ReportRequestSurvey> _reportRequestsSurvey { get; set; }
        public IRepository<ReportRequestSurvey> ReportRequestsSurvey => _reportRequestsSurvey ??= new Repository<ReportRequestSurvey>(_context);

        private IRepository<ReportRequestText> _reportRequestsText { get; set; }
        public IRepository<ReportRequestText> ReportRequestsText => _reportRequestsText ??= new Repository<ReportRequestText>(_context);

        private IRepository<UploadableFileType> _uploadableFileTypes { get; set; }
        public IRepository<UploadableFileType> UploadableFileTypes => _uploadableFileTypes ??= new Repository<UploadableFileType>(_context);

        private IRepository<ReportAssignment> _reportAssignments { get; set; }
        public IRepository<ReportAssignment> ReportAssignments => _reportAssignments ??= new Repository<ReportAssignment>(_context); 

    }
}
