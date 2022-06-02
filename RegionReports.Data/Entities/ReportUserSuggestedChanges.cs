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