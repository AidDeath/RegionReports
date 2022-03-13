using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

namespace RegionReports.Services
{
    public class ApprovalClaimService
    {
        private readonly IDbAccessor _database;
        public ApprovalClaimService(IDbAccessor database)
        {
            _database = database;
        }

        public IEnumerable<ReportUserApprovalClaim> GetAllClaims(bool unprocessedOnly = false)
        {
            if (unprocessedOnly) return _database.ReportUserApprovalClaims.GetQueryable()
                    .Where(c => !c.IsClaimProcessed).Include(c => c.ReportUser)
                    .Include(c => c.ReportUserSuggestedChanges).ThenInclude(c => c.RelatedDistrict)
                    .OrderByDescending(c => c.ReportUser.WindowsUserName)
                    .AsEnumerable();

            return _database.ReportUserApprovalClaims.GetQueryable()
                    .Include(c => c.ReportUser)
                    .Include(c => c.ReportUserSuggestedChanges).ThenInclude(c => c.RelatedDistrict)
                    .OrderBy(c => c.IsClaimProcessed)
                    .ThenBy(c => c.ReportUser.WindowsUserName)
                    .AsEnumerable();
        }

        public ReportUserApprovalClaim AcceptApprovalClaim(ReportUserApprovalClaim claim)
        {
            
            claim.ReportUser.TakeSuggestedChanges(claim);
            claim.ReportUser.IsApproved = true;
            claim.IsClaimProcessed = true;

            _database.ReportUserApprovalClaims.Update(claim);

            

            return claim;

        }


    }
}
