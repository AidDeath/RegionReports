using RegionReports.Data.Entities;
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

        public IRepository<ReportUser> ReportUsers { get; }

        public IRepository<District> Districts { get; }
    }
}
