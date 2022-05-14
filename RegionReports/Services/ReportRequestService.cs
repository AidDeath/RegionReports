using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using RegionReports.Enums;

namespace RegionReports.Services
{
    public class ReportRequestService
    {
        private readonly IDbAccessor _database;
        public ReportRequestService(IDbAccessor database)
        {
            _database = database;
        }

        /// <summary>
        /// Создать запрос в виде опроса
        /// </summary>
        /// <param name="reportRequest"></param>
        public void CreateReportRequestSurvey(ReportRequestSurvey reportRequest)
        {
            _database.ReportRequestsSurvey.Create(reportRequest);
        }

        /// <summary>
        /// Создать запрос текстового отчета
        /// </summary>
        /// <param name="reportRequest"></param>
        public void CreateReportRequestText(ReportRequestText reportRequest)
        {
            _database.ReportRequestsText.Create(reportRequest);
        }


        public IEnumerable<ReportRequestBase> GetAllRequests()
        {
            var textRequests = _database.ReportRequestsText.GetQueryable().Include(rep => rep.ReportSchedule).AsEnumerable();
            var surveyRequests = _database.ReportRequestsSurvey.GetQueryable().Include(rep => rep.ReportSchedule).AsEnumerable();

            List<ReportRequestBase> allRequests = new();

            allRequests.AddRange(textRequests);
            allRequests.AddRange(surveyRequests);

            var aa = allRequests;

            return allRequests.OrderByDescending(req => req.DateCreated);
        }

        public string WhenToCollect(ReportRequestBase request)
        {
            if (request.IsSchedulledRequest) return "Расписание не задано";

            if (request.IsSchedulledRequest && request.ReportSchedule is null) throw new NullReferenceException();

            //if (!request.IsSchedulledRequest && request.NonScheduledDeadline is not null)
            //{
            //    return $"Без расписания, срок до {  (DateTime)request.NonScheduledDeadline:D} в {  (DateTime)request.NonScheduledDeadline:t}";
            //}

            switch (request.ReportSchedule?.ScheduleType)
            {
                case 1:
                    return $"Ежемесячно, не позднее {request.ReportSchedule.DayOfMonth} числа, до {request.ReportSchedule.Time.Hours}:{request.ReportSchedule.Time.Minutes}";
                case 2:
                    return $"Еженедельно, {daysDictionary[request.ReportSchedule.DayOfWeek ?? 0]}, до {request.ReportSchedule.Time.Hours}:{request.ReportSchedule.Time.Minutes}";
                case 3:
                    return $"Ежедневно до {request.ReportSchedule.Time.Hours}:{request.ReportSchedule.Time.Minutes}";
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
