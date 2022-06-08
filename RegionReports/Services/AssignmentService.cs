using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using RegionReports.Enums;

namespace RegionReports.Services
{
    public class AssignmentService
    {
        private readonly IDbAccessor _database;
        private readonly MailerService _mailer;

        public AssignmentService(IDbAccessor database, MailerService mailer)
        {
            _database = database;
            _mailer = mailer;
        }

        /// <summary>
        /// Вписать новые назначения в запрос отчета и проставить дедлайн
        /// </summary>
        /// <param name="request"></param>
        /// <param name="usersToAssign"></param>
        public void AddAssignmentsRange(ReportRequestBase request, IEnumerable<ReportUser>? usersToAssign, DateTime nonScheduledDeadline = default(DateTime))
        {
            DateTime calculatedDeadline = (request.IsSchedulledRequest)
                ? GetDeadlineDate(request.ReportSchedule)
                : nonScheduledDeadline;

            var newGroup = new ReportAssignmentGroup()
            {
                ReportRequestText = (request is ReportRequestText) ? (ReportRequestText)request : null,
                ReportRequestSurvey = (request is ReportRequestSurvey) ? (ReportRequestSurvey)request : null,
                ActualDeadline = calculatedDeadline,
                Assignments = new()
            };

            foreach (var user in usersToAssign)
            {
                var asn = new ReportAssignment()
                {
                    ReportUser = user
                };
                newGroup.Assignments.Add(asn);
                _mailer.SendAssignmentMessage(asn);
            }

            if (request.AssignmentsGroups is null)
            {
                request.AssignmentsGroups = new List<ReportAssignmentGroup>() { newGroup };
            }
            else request.AssignmentsGroups.Add(newGroup);
        }

        /// <summary>
        /// Получить все группы назначения отчетов, актуальные на данный момент
        /// </summary>
        public List<ReportAssignmentGroup> GetActualAssignmentGroups()
        {
            var query = _database.AssignmentGroups.GetQueryable()
                .Include(group => group.Assignments)
                .Include(group => group.ReportRequestSurvey).ThenInclude(req => req.ReportSchedule).ThenInclude(sch => sch.Districts).ThenInclude(dst => dst.ReportUser)
                .Include(group => group.ReportRequestSurvey.Options)
                .Include(group => group.ReportRequestWithFile).ThenInclude(req => req.ReportSchedule).ThenInclude(sch => sch.Districts).ThenInclude(dst => dst.ReportUser)
                .Include(group => group.ReportRequestWithFile.TemplateFile)
                .Include(group => group.ReportRequestText).ThenInclude(repText => repText.ReportSchedule).ThenInclude(sch => sch.Districts).ThenInclude(dst => dst.ReportUser)
                .Include(group => group.ReportRequestText.Files)
                .Where(group => !group.IsOverdued)
                .OrderByDescending(rep => rep.DateAssigned);

            return query.ToList();
        }

        /// <summary>
        /// Получить все группы назначений, срок сбора по которым истек
        /// </summary>
        /// <returns></returns>
        public List<ReportAssignmentGroup> GetOverduedAssignmentGroups()
        {
            var query = _database.AssignmentGroups.GetQueryable()
                .Include(group => group.Assignments).ThenInclude(asn => asn.ReportText)
                .Include(group => group.Assignments).ThenInclude(asn => asn.ReportSurvey.ProcessedOptions)
                .Include(group => group.Assignments).ThenInclude(asn => asn.ReportWithFile.ResponseFile)
                .Include(group => group.Assignments).ThenInclude(asn => asn.ReportUser)
                .Include(group => group.ReportRequestSurvey)
                .Include(group => group.ReportRequestSurvey.Options)
                .Include(group => group.ReportRequestText)
                .Include(group => group.ReportRequestText.Files)
                .Include(group => group.ReportRequestWithFile.TemplateFile)
                .Where(group => group.IsOverdued)
                .OrderByDescending(rep => rep.DateAssigned);

            return query.ToList();
        }

        /// <summary>
        /// Получить назначения для пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="uncompetedOnly">Только невыполненные отчеты</param>
        /// <returns></returns>
        public List<ReportAssignment> GetForUser(ReportUser user, bool uncompetedOnly = false)
        {
            var query = _database.ReportAssignments.GetQueryable()
                .Include(ass => ass.ReportUser)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestSurvey).ThenInclude(req => req.ReportSchedule)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestSurvey.Options)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestText).ThenInclude(repText => repText.ReportSchedule)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestText.Files)
                .Include(asn => asn.ReportAssignmentGroup.ReportRequestWithFile).ThenInclude(repFile => repFile.ReportSchedule)
                .Include(asn => asn.ReportAssignmentGroup.ReportRequestWithFile.TemplateFile)
                .Include(ass => ass.ReportSurvey)
                .Include(ass => ass.ReportText)
                .Include(asn => asn.ReportWithFile)
                .OrderByDescending(rep => rep.ReportAssignmentGroup.DateAssigned);

            return (uncompetedOnly)
                ? query.Where(ass => ass.ReportUser == user && !ass.IsCompleted).ToList()
                : query.Where(ass => ass.ReportUser == user).ToList();
        }

        public ReportAssignment? GetById(ReportUser user, int id)
        {
            return _database.ReportAssignments.GetQueryable()
                .Include(ass => ass.ReportUser)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestSurvey).ThenInclude(req => req.ReportSchedule)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestSurvey.Options)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestText).ThenInclude(repText => repText.ReportSchedule)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestText.Files)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestWithFile).ThenInclude(req => req.ReportSchedule)
                .Include(ass => ass.ReportAssignmentGroup.ReportRequestWithFile.TemplateFile)
                .Include(ass => ass.ReportSurvey)
                .Include(ass => ass.ReportText)
                .Include(asn => asn.ReportWithFile)
                .Where(ass => ass.ReportUser == user && ass.Id == id).FirstOrDefault();
        }

        public void SaveReportInAssignment(ReportAssignment assignment)
        {
            var report = assignment.GetReportBase();

            if (report is ReportText reportText) _database.ReportsText.Create(reportText);
            if (report is ReportSurvey reportSurvey) _database.ReportsSurvey.Create(reportSurvey);
            if (report is ReportWithFile reportWithFile) _database.ReportsWithFile.Create(reportWithFile);
        }

        private DateTime GetDeadlineDate(ReportSchedule schedule)
        {
            DateTime calculatedDeadline;
            switch ((ReportScheduleType)schedule.ScheduleType)
            {
                case ReportScheduleType.Ежемесячный:
                    var dayForCurrentMonth = (DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) < schedule.DayOfMonth)
                        ? DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)
                        : (int)schedule.DayOfMonth;

                    var nextMonth = DateTime.Now.AddMonths(1);
                    var dayForNextMonth = (DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month) < schedule.DayOfMonth)
                        ? DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month)
                        : (int)schedule.DayOfMonth;

                    calculatedDeadline = (DateTime.Now < new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayForCurrentMonth, schedule.Time.Hours, schedule.Time.Minutes, 0))
                        ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayForCurrentMonth)
                        : new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, dayForNextMonth);
                    break;

                case ReportScheduleType.Еженедельный:
                    calculatedDeadline = DateTime.Today;
                    while ((short)calculatedDeadline.DayOfWeek != schedule.DayOfWeek)
                    {
                        calculatedDeadline = calculatedDeadline.AddDays(1);
                    }

                    if (calculatedDeadline.Date == DateTime.Today && DateTime.Now.TimeOfDay > schedule.Time)
                    {
                        calculatedDeadline = calculatedDeadline.AddDays(7);
                    }
                    break;

                case ReportScheduleType.Ежедневный:
                    calculatedDeadline = (DateTime.Now.TimeOfDay < schedule.Time)
                        ? DateTime.Now.Date
                        : DateTime.Now.Date.AddDays(1);
                    break;

                default: throw new Exception("В расписании не указан тип расписания");
            }

            calculatedDeadline = calculatedDeadline.AddHours(schedule.Time.Hours).AddMinutes(schedule.Time.Minutes);

            return calculatedDeadline;
        }

        public void UpdateSchedule(ReportSchedule schedule)
        {
            _database.ReportSchedules.Update(schedule);
        }

        public void UpdateAssignmentGroup(ReportAssignmentGroup asnGroup)
        {
            _database.AssignmentGroups.Update(asnGroup);
        }
    }
}