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

        public List<ReportAssignment> GetForUser(ReportUser user, bool uncompetedOnly = false)
        {
            var query = _database.ReportAssignments.GetQueryable()
                .Include(ass => ass.ReportUser)
                .Include(ass => ass.ReportRequestSurvey)
                .Include(ass => ass.ReportRequestText)
                .Include(ass => ass.ReportSurvey);


            return (uncompetedOnly)
                ? query.Where(ass => ass.ReportUser == user && !ass.IsCompleted).ToList()
                : query.Where(ass => ass.ReportUser == user).ToList();
        }
    }
}
