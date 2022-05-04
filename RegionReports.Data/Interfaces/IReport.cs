using RegionReports.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Interfaces
{
    internal interface IReport
    {
        public int Id { get; set; }

        public int ReportUserId { get; set; }

        /// <summary>
        /// Пользователь выполнивший отчет
        /// </summary>
        public ReportUser? ReportUser { get; set; }

        /// <summary>
        /// Дата ответа
        /// </summary>
        public DateTime DateFilled { get; set; }

        public int ReportAssignmentId { get; set; }

        /// <summary>
        /// Ссылка на назначение, по которому сделан этот отчет
        /// </summary>
        public ReportAssignment ReportAssignment { get; set; }
    }
}
