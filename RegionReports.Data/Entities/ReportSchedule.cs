namespace RegionReports.Data.Entities
{
    public class ReportSchedule
    {
        public int Id { get; set; }

        /// <summary>
        /// Тип расписания, Ежемесячный, Еженедельный, Ежедневный (1,2,3 , должен соотвестствовать Enum)
        /// </summary>
        public int ScheduleType { get; set; }

        public TimeSpan Time { get; set; } = new TimeSpan();
        public short? DayOfWeek { get; set; }

        public short? DayOfMonth { get; set; }

        public bool? IsScheduleActive { get; set; } = true;

        public int DaysBeforeAutoAssignment { get; set; } = 1;

        public ReportRequestText? ReportRequestText { get; set; }

        public ReportRequestSurvey? ReportRequestSurvey { get; set; }

        public List<District> Districts { get; set; }
    }
}