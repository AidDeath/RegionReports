using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Район
    /// </summary>
    public class District
    {
        public int Id { get; set; }

        public string DistrictName { get; set; } = "";

        /// <summary>
        /// Область, к которой относится этот район
        /// </summary>
        [ForeignKey("Region")]
        public int RegionId { get; set; }

        public Region? Region { get; set; }

        /// <summary>
        /// Пользователь, ответственный за район
        /// </summary>
        [ForeignKey("ReportUser")]
        public int? ReportUserId { get; set; }

        public ReportUser? ReportUser { get; set; }
    }
}
