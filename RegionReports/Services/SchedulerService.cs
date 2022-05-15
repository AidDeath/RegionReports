using Microsoft.EntityFrameworkCore;
using RegionReports.Data;

namespace RegionReports.Services
{
    public class SchedulerService : BackgroundService
    {

        private readonly ILogger<SchedulerService> _logger;
        private readonly RegionReportsContext _dbContext;

        public SchedulerService(ILogger<SchedulerService> logger, RegionReportsContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.Log(LogLevel.Information, "Hello! I'm from hosted service");
                    //Console.WriteLine("Hello! I'm from hosted service");
                    //var a = CreateAssignmentsForSchedule();

                    await SetOverdueOnAssignments();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex.GetBaseException().Message);
                }

                await Task.Delay(10000);
            }

            // Если нужно дождаться завершения очистки, но контролировать время, то стоит предусмотреть в контракте использование CancellationToken
            //await someService.DoSomeCleanupAsync(cancellationToken);
        }


        //private List<ReportSchedule> CreateAssignmentsForSchedule()
        //{
        //    //Беру расписание, смотрю, не нужно ли создать назначение. Попутно могу посмотреть назначения, если предыдущее неисполнено - могу поставить ему
        //    //какой то признак о том, что оно не выполнено, просрочено.
        //    //Так же надо ставить признаки просроченности в том случае, если отчет не сдан вовремя.

        //    //Походу нужно изменять логику для назначения дедлайна и переносить его из запроса в назначение

        //    return _database.ReportSchedules.GetQueryable()
        //        .Include(sch => sch.ReportRequestSurvey)
        //        .Include(sch => sch.ReportRequestText)
        //        .Where(sch => sch.ReportRequestText.IsSchedulledRequest || sch.ReportRequestSurvey.IsSchedulledRequest )
        //        .ToList();
        //}

        /// <summary>
        /// Устанавливаем признак "просрочено" для отчетов, которые не сданы вовремя
        /// </summary>
        private async Task SetOverdueOnAssignments()
        {
            //var assignments = await _dbContext.ReportAssignments
            //    .Where(assignment => !assignment.IsCompleted && assignment.ActualDeadline < DateTime.Now)
            //    .ToListAsync();
                
            //foreach (var assignment in assignments)
            //{
            //    assignment.IsCancelledByOverDue = true;
            //    _logger.Log(LogLevel.Information, $"Assignment {assignment.Id} cancelled by overdue");
            //}


            await _dbContext.ReportAssignments
                .Where(assignment => !assignment.IsCompleted && assignment.ActualDeadline < DateTime.Now)
                .ForEachAsync(ass =>ass.IsCancelledByOverDue = true);
            _dbContext.SaveChanges();

            _logger.Log(LogLevel.Information, $"Overdued assignmtnts was cancelled");

        }


    }
}
