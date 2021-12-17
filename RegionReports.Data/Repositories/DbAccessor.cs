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

        private IRepository<ReportUser> _reportUsers { get; set; }
        public IRepository<ReportUser> ReportUsers => _reportUsers ??= new Repository<ReportUser>(_context);

    }
}
