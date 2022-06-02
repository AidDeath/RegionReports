using System.ComponentModel.DataAnnotations;

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
        /// Имя домена пользователя
        /// </summary>
        public string UserDomain { get; set; } = "";

        /// <summary>
        /// Имя, под которым пользователь вошёл в систему
        /// </summary>
        public string WindowsUserName { get; set; } = "";

        /// <summary>
        /// Обслуживаемый район
        /// </summary>
        public District? RelatedDistrict { get; set; }

        /// <summary>
        /// Информация о пользователе подтверждена администратором
        /// </summary>
        [Required]
        public bool IsApproved { get; set; } = false;

        /// <summary>
        /// Предыдущее состояние подтверждения пользователя
        /// </summary>
        public bool? PreviousApprovalState { get; set; }

        /// <summary>
        /// Дата последнего входа пользователя в систему
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastChangesDate { get; set; }

        public List<ReportUserApprovalClaim>? UserApprovalClaims { get; set; }

        /// <summary>
        /// Принять изменения данных из предлагаемых
        /// </summary>
        /// <param name="suggested"></param>
        public void TakeSuggestedChanges(ReportUserApprovalClaim claim)
        {
            this.FullName = claim.ReportUserSuggestedChanges.FullName ?? String.Empty;
            this.Email = claim.ReportUserSuggestedChanges.Email ?? String.Empty;
            this.RelatedDistrict = claim.ReportUserSuggestedChanges.RelatedDistrict;
            this.LastChangesDate = DateTime.Now;
        }
    }
}