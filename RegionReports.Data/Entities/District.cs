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
        public int RegionId { get; set; }

        public Region? Region { get; set; }

        public int? ReportUserId { get; set; }

        /// <summary>
        /// Пользователь, закрепленный за районом
        /// </summary>
        public ReportUser? ReportUser { get; set; }

        public List<ReportSchedule> Schedules { get; set; }
    }
}