using RegionReports.Data.Entities;
using RegionReports.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Interfaces
{
    public interface IDbAccessor
    {
        public IRepository<Region> Regions { get; }

        public ReportUserRepository ReportUsers { get; }

        public IRepository<District> Districts { get; }
        
        public IReportUserApprovalClaimRepository ReportUserApprovalClaims { get; }

        public IRepository<ReportRequestSurvey> ReportRequestsSurvey { get; }
    }
}
