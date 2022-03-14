using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Exceptions;
using RegionReports.Data.Interfaces;

namespace RegionReports.Data.Repositories
{
    public class ReportUserRepository : Repository<ReportUser>, IRepository<ReportUser>
    {
        public ReportUserRepository(RegionReportsContext context) : base(context)
        {
        }

        public ReportUser Get(string windowsName)
        {
            var user = _dbSet.Where(u => u.WindowsUserName == windowsName).Include(u => u.RelatedDistrict).FirstOrDefault();
            if (user == null) throw new UserNotFoundException(windowsName);
            return user;
        }

        public override void Update(ReportUser entity)
        {
            entity.LastChangesDate = DateTime.Now;
            base.Update(entity);
        }

    }
}
