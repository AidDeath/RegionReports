using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Заявка на изменение данных пользователя
    /// </summary>
    public class ReportUserApprovalClaim
    {
        public int Id { get; set; }
    
        /// <summary>
        /// изменения, предложенные пользователем 
        /// </summary>
        public ReportUserSuggestedChanges ReportUserSuggestedChanges { get; set; }

        public int ReportUserId { get; set; }
        public ReportUser ReportUser { get; set; }

        /// <summary>
        /// Дата подачи заявки
        /// </summary>
        public DateTime ClaimDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Признак обработки заявки
        /// </summary>
        public bool IsClaimProcessed { get; set; } = false;

    }
}
