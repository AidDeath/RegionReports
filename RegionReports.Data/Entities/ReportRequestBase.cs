using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    public abstract class ReportRequestBase
    {
        public string RequestTitle { get; set; } = "";

        public string RequestText { get; set; } = "";

        public bool IsSchedulledRequest { get; set; } = false;

        public int? ReportScheduleId { get; set; }
        public ReportSchedule? ReportSchedule { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// Назначения этого отчета для пользователей
        /// </summary>
        public ReportAssignmentGroup AssignmentsGroup { get; set; } = new ();
    }
}
