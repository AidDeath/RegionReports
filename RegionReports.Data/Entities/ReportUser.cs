using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Информация о пользователе из БД
    /// </summary>
    public class ReportUser 
    {
        public int Id { get; set; }

        public string WindowsUserName { get; set; } = "";

        [ForeignKey("District")]
        public int DistrictId { get; set; }

        public District? District { get; set; }

    }
}
