using Microsoft.EntityFrameworkCore;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using RegionReports.Enums;

namespace RegionReports.Services
{
    public class SchedulerService : BackgroundService
    {

        private readonly IDbAccessor _database;
        private readonly ILogger<SchedulerService> _logger;

        public SchedulerService(IDbAccessor database, ILogger<SchedulerService> logger)
        {
            _database = database;
            _logger = logger;
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
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, ex.GetBaseException().Message);
                }

                await Task.Delay(15000);
            }

            // Если нужно дождаться завершения очистки, но контролировать время, то стоит предусмотреть в контракте использование CancellationToken
            //await someService.DoSomeCleanupAsync(cancellationToken);
        }


        private List<ReportSchedule> CreateAssignmentsForSchedule()
        {
            //Беру расписание, смотрю, не нужно ли создать назначение. Попутно могу посмотреть назначения, если предыдущее неисполнено - могу поставить ему
            //какой то признак о том, что оно не выполнено, просрочено.
            //Так же надо ставить признаки просроченности в том случае, если отчет не сдан вовремя.

            //Походу нужно изменять логику для назначения дедлайна и переносить его из запроса в назначение

            return _database.ReportSchedules.GetQueryable()
                .Include(sch => sch.ReportRequestSurvey)
                .Include(sch => sch.ReportRequestText)
                .Where(sch => sch.ReportRequestText.IsSchedulledRequest || sch.ReportRequestSurvey.IsSchedulledRequest )
                .ToList();
        }

        /// <summary>
        /// Устанавливаем признак "просрочено" для отчетов, которые не сданы вовремя
        /// </summary>
        private void SetOverdueOnAssignments()
        {
            var assignments = _database.ReportAssignments.GetQueryable()
                .Include(assignment => assignment.ReportRequestSurvey.ReportSchedule)
                .Include(assignment => assignment.ReportRequestText.ReportSchedule)
                .Where(assignment => !assignment.IsCompleted);

            foreach (var assignment in assignments)
            {
                var request = assignment.GetReportRequest();
                //запрос без расписания
                if (request.IsSchedulledRequest && DateTime.Now >= request.NonScheduledDeadline)
                {
                    assignment.IsCancelledByOverDue = true;
                }
                //Запрос с раписанием
                else
                {
                    switch ((ReportScheduleType)request.ReportSchedule.ScheduleType)
                    {
                        //case ReportScheduleType.Ежемесячный:
                        //    break;
                        //case ReportScheduleType.Еженедельный:
                        //    break;
                        //case ReportScheduleType.Ежедневный:
                        //    if (request.ReportSchedule.Time)
                        //    break;
                    }
                }
            }
        }


    }
}
