using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<ReportAssignmentGroup> AssignmentsGroups { get; set; } = new ();

        public string WhenToCollect()
        {
            if (!IsSchedulledRequest) return "Расписание не задано";

            if (IsSchedulledRequest && ReportSchedule is null) throw new NullReferenceException();

            switch (ReportSchedule.ScheduleType)
            {
                case 1:
                    return $"Ежемесячно, не позднее {ReportSchedule.DayOfMonth} числа, до {ReportSchedule.Time.Hours}:{ReportSchedule.Time.Minutes}";
                case 2:
                    return $"Еженедельно, {daysDictionary[ReportSchedule.DayOfWeek ?? 0]}, до {ReportSchedule.Time.Hours}:{ReportSchedule.Time.Minutes}";
                case 3:
                    return $"Ежедневно до {ReportSchedule.Time.Hours}:{ReportSchedule.Time.Minutes}";
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
