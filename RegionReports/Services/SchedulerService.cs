using Microsoft.EntityFrameworkCore;
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
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }

                await Task.Delay(5000);
            }

            // Если нужно дождаться завершения очистки, но контролировать время, то стоит предусмотреть в контракте использование CancellationToken
            //await someService.DoSomeCleanupAsync(cancellationToken);
        }


        private async Task CreateAssignmentsForSchedule()
        {
            
        }


    }
}
