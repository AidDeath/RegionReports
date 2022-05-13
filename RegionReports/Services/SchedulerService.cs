using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;

namespace RegionReports.Services
{
    public class SchedulerService : BackgroundService
    {

        private readonly IDbAccessor _database;

        public SchedulerService(IDbAccessor database)
        {
            _database = database;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine("Hello! I'm from hosted service");
                    //var a = CreateAssignmentsForSchedule();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }

                await Task.Delay(15000);
            }

            // Если нужно дождаться завершения очистки, но контролировать время, то стоит предусмотреть в контракте использование CancellationToken
            //await someService.DoSomeCleanupAsync(cancellationToken);
        }


        private List<ReportSchedule> CreateAssignmentsForSchedule()
        {
            return _database.ReportSchedules.GetQueryable()
                .Include(sch => sch.ReportRequestSurvey)
                .Include(sch => sch.ReportRequestText)
                .ToList();
        }


    }
}
