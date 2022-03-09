using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Repositories
{
    /// <summary>
    /// Расширенный репозиторий, который всегда отдаёт заявку вместе с предложенными изменениями
    /// </summary>
    public class ReportUserApprovalClaimRepository : Repositories.Repository<ReportUserApprovalClaim>, IReportUserApprovalClaimRepository
    {
        
        public ReportUserApprovalClaimRepository(RegionReportsContext context) : base(context)
        { }

        public override IQueryable<ReportUserApprovalClaim> GetQueryable()
        {
            return base.GetQueryable().Include(a => a.ReportUserSuggestedChanges);
        }

        public override ReportUserApprovalClaim? Get(int Id)
        {
            return _dbSet.Include(claim => claim.ReportUserSuggestedChanges).FirstOrDefault(a => a.Id == Id);
        }

        
        public  ReportUserApprovalClaim? GetLastClaimForUser(int userId)
        {
            return _dbSet.Include(claim => claim.ReportUserSuggestedChanges)
                         .FirstOrDefault(c => !c.IsClaimProcessed && c.ReportUserId == userId);
        }

        public IEnumerable<ReportUserApprovalClaim> GetAllClaimsForUser(int userId)
        {
            return _dbSet.Where(c => c.ReportUserId == userId && c.IsClaimProcessed)
                         .Include(claim => claim.ReportUserSuggestedChanges);
        }

    }
}
