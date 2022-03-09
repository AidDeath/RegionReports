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
    /// Изменения данных, которые пользователь о себе предоставляет
    /// для утверждения
    /// </summary>
    public class ReportUserSuggestedChanges
    {

        public int Id { get; set; }


        /// <summary> 
        /// Полное имя пользователя.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string? Email { get; set; } 

        /// <summary>
        /// Идентификатор обслуживаемого района
        /// </summary>
        public int? RelatedDistrictId { get; set; }

        public District? RelatedDistrict { get; set; }


        public int ReportUserApprovalClaimId { get; set; }
        /// <summary>
        /// Заявка на изменение данных
        /// </summary>
        public ReportUserApprovalClaim ReportUserApprovalClaim { get; set; } = new();


    }
}
