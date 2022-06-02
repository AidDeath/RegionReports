using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

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

        public void CreateReportRequestwithFile(ReportRequestWithFile reportRequest)
        {
            _database.ReportRequestsWithFile.Create(reportRequest);
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
    }
}