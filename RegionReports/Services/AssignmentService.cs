using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

namespace RegionReports.Services
{
    public class AssignmentService
    {
        private readonly IDbAccessor _database;
        public AssignmentService(IDbAccessor database)
        {
            _database = database;
        }

        public void AddAssignment(ReportRequestBase request, int userId)
        {

        }

        /// <summary>
        /// Вписать новые назначения в запрос отчета
        /// </summary>
        /// <param name="request"></param>
        /// <param name="usersToAssign"></param>
        public void AddAssignmentsRange(ReportRequestBase request, IEnumerable<ReportUser>? usersToAssign)
        {
                foreach(var user in usersToAssign)
                {
                    request.ReportAssignments.Add(new()
                    {
                        ReportUser = user,
                        ReportRequestText = (request is ReportRequestText) ? (ReportRequestText)request : null,
                        ReportRequestSurvey = (request is ReportRequestSurvey) ? (ReportRequestSurvey)request : null,
                    });
                }
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
                .Include(ass => ass.ReportRequestSurvey).ThenInclude(repSurvey => repSurvey.ReportSchedule)
                .Include(ass => ass.ReportRequestSurvey.Options)
                .Include(ass => ass.ReportRequestText).ThenInclude(repText => repText.ReportSchedule)
                .Include(ass => ass.ReportRequestText.Files)
                .Include(ass => ass.ReportSurvey)
                .Include(ass => ass.ReportText)
                .OrderByDescending(rep => rep.DateAssigned);


            return (uncompetedOnly)
                ? query.Where(ass => ass.ReportUser == user && !ass.IsCompleted).ToList()
                : query.Where(ass => ass.ReportUser == user).ToList();
        }

        public ReportAssignment? GetById(ReportUser user, int id)
        {
            return _database.ReportAssignments.GetQueryable()
                .Include(ass => ass.ReportUser)
                .Include(ass => ass.ReportRequestSurvey).ThenInclude(repSurvey => repSurvey.ReportSchedule)
                .Include(ass => ass.ReportRequestSurvey.Options)
                .Include(ass => ass.ReportRequestText).ThenInclude(repText => repText.ReportSchedule)
                .Include(ass => ass.ReportRequestText.Files)
                .Include(ass => ass.ReportSurvey)
                .Include(ass => ass.ReportText)
                .Where(ass => ass.ReportUser == user && ass.Id == id).FirstOrDefault();
        }

        //TODO: Не прописывает сданный отчет в назначении
        public void UpdateAssignment(ReportAssignment assignment)
        {
            var report = assignment.GetReportBase();

            if (report is ReportText) _database.ReportsText.Create((ReportText)report);
            if (report is ReportSurvey) _database.ReportsSurvey.Create((ReportSurvey)report);
        }

    }
}
