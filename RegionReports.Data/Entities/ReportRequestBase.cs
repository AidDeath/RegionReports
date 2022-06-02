namespace RegionReports.Data.Entities
{
    public abstract class ReportRequestBase
    {
        public string RequestTitle { get; set; } = "";

        public string RequestText { get; set; } = "";

        public bool IsSchedulledRequest { get; set; } = false;

        public int? ReportScheduleId { get; set; }
        public ReportSchedule? ReportSchedule { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// Назначения этого отчета для пользователей
        /// </summary>
        public List<ReportAssignmentGroup> AssignmentsGroups { get; set; } = new();

        public string WhenToCollect()
        {
            if (!IsSchedulledRequest) return "Расписание не задано";

            if (IsSchedulledRequest && ReportSchedule is null) throw new NullReferenceException();

            if (!ReportSchedule.IsScheduleActive ?? false) return "Расписание выключено";

            switch (ReportSchedule.ScheduleType)
            {
                case 1:
                    return $"Ежемесячно, до {ReportSchedule.DayOfMonth} числа, до {ReportSchedule.Time.Hours:00}:{ReportSchedule.Time.Minutes:00}";

                case 2:
                    return $"Еженедельно, {daysDictionary[ReportSchedule.DayOfWeek ?? 0]}, до {ReportSchedule.Time.Hours:00}:{ReportSchedule.Time.Minutes:00}";

                case 3:
                    return $"Ежедневно до {ReportSchedule.Time.Hours:00}:{ReportSchedule.Time.Minutes:00}";
            }
            return string.Empty;
        }

        private Dictionary<short, string> daysDictionary = new()
        {
            { 1, "Понедельник" },
            { 2, "Вторник" },
            { 3, "Среда" },
            { 4, "Четверг" },
            { 5, "Пятница" },
            { 6, "Суббота" },
            { 7, "Воскресенье" },
        };
    }
}