﻿using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using RegionReports.Enums;


namespace RegionReports.Services
{
    public class AssignmentService
    {
        private readonly IDbAccessor _database;
        public AssignmentService(IDbAccessor database)
        {
            _database = database;
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
                newGroup.Assignments.Add(new()
                {
                    ReportUser = user
                });
            }

            if (request.AssignmentsGroups is null)
            {
                request.AssignmentsGroups = new List<ReportAssignmentGroup>() { newGroup };
            }
            else request.AssignmentsGroups.Add(newGroup);
        }


        public List<ReportAssignmentGroup> GetAssignmentGroups()
        {
            var query = _database.AssignmentGroups.GetQueryable()
                .Include(group => group.Assignments)
                .Include(group => group.ReportRequestSurvey).ThenInclude(req => req.ReportSchedule)
                .Include(group => group.ReportRequestSurvey.Options)
                .Include(group => group.ReportRequestText).ThenInclude(repText => repText.ReportSchedule)
                .Include(group => group.ReportRequestText.Files)
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
                .Include(ass => ass.ReportSurvey)
                .Include(ass => ass.ReportText)
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
                .Include(ass => ass.ReportSurvey)
                .Include(ass => ass.ReportText)
                .Where(ass => ass.ReportUser == user && ass.Id == id).FirstOrDefault();
        }

        public void SaveReportInAssignment(ReportAssignment assignment)
        {
            var report = assignment.GetReportBase();

            if (report is ReportText reportText) _database.ReportsText.Create(reportText);
            if (report is ReportSurvey reportSurvey) _database.ReportsSurvey.Create(reportSurvey);
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
                    while ((short)calculatedDeadline.DayOfWeek != schedule.DayOfWeek )
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

    }
}
