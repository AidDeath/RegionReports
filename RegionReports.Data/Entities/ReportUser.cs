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
    /// Информация о пользователе из БД
    /// </summary>
    public class ReportUser 
    {
        public int Id { get; set; }

        /// <summary> 
        /// Полное имя пользователя.
        /// </summary>
        public string FullName { get; set; } = "";

        public string Email { get; set; } = "";

        /// <summary>
        /// Имя, под которым пользователь вошёл в систему
        /// </summary>
        public string WindowsUserName { get; set; } = "";


        /// <summary>
        /// Обслуживаемые районы
        /// </summary>
        public List<District>? Districts { get; set; }

        /// <summary>
        /// Информация о пользователе подтверждена администратором
        /// </summary>
        public bool IsApproved { get; set; } = false;

        /// <summary>
        /// Дата последней заявки на утверждение данных пользователя
        /// </summary>
        public DateTime? ApproveClaimDate { get;set; }

        /// <summary>
        /// Пользователь активен. Не заблокирован
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
