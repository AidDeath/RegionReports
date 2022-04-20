using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;


namespace RegionReports.Data.Repositories
{
    public class SpecialRepository
    {
        protected readonly RegionReportsContext _context;
        public SpecialRepository(RegionReportsContext context)
        {
            _context = context;
        }

        public void DoSmth()
        {

        }
    }
}
