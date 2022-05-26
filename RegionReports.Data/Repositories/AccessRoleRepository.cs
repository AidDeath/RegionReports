using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Repositories
{
    public class AccessRoleRepository : Repository<AccessRole>, IRepository<AccessRole>
    {
        public AccessRoleRepository(RegionReportsContext context) : base(context)
        {
        }

        public override void CreateRange(IEnumerable<AccessRole> entities)
        {
            foreach (var ent in entities)
                ent.Id = 0;
            base.CreateRange(entities);
        }
        public void Clear()
        {
            Context.RemoveRange(Context.AccessRoles);
            Context.SaveChanges();
        }
    }
}
