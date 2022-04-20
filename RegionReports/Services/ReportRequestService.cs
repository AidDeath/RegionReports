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

        public void CreateReportRequest(ReportRequestType reportRequestType)
        {

            switch (reportRequestType)
            {
                case ReportRequestType.TextOnlyReport:
                    break;
                case ReportRequestType.SurveyReport:
                    break;
            }
        }

        public void CreateReportRequestSurvey(ReportRequestSurvey reportRequest)
        {
            _database.ReportRequestsSurvey.Create(reportRequest);
        }
    }
}
