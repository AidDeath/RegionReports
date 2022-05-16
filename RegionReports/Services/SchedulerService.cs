using Microsoft.EntityFrameworkCore;
using RegionReports.Data;
using RegionReports.Data.Entities;
using RegionReports.Enums;

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
                    await SetOverdueOnAssignments();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, $"SetOverdueOnAssignments: {ex.GetBaseException().Message}");
                }


                try
                {
                    await CreateAssignmentsForSchedule();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, $"CreateAssignmentsForSchedule: {ex.GetBaseException().Message}");
                }

                await Task.Delay(TimeSpan.FromMinutes(10));
            }

            // Если нужно дождаться завершения очистки, но контролировать время, то стоит предусмотреть в контракте использование CancellationToken
            //await someService.DoSomeCleanupAsync(cancellationToken);
        }


        private async Task CreateAssignmentsForSchedule()
        {
            // Создание назначений.
            // Вытягиваю назначения по след. условиям:
            // Назначение выполнено либо отменено (Так не будет создаваться назначение, если ещё активно предыдущее)
            //  В назначении лежит отчет с признаком IsScheduledRequest.

            var assignments = await _dbContext.ReportAssignments
                .Include(asn => asn.ReportRequestSurvey).ThenInclude(rep => rep.ReportSchedule.Districts).ThenInclude(distr => distr.ReportUser)
                .Include(asn => asn.ReportRequestText).ThenInclude(rep => rep.ReportSchedule.Districts).ThenInclude(distr => distr.ReportUser)
                .Include(asn => asn.ReportUser)
                .Where(asn => asn.IsCancelledByOverDue
                            && (asn.ReportRequestSurvey.IsSchedulledRequest || asn.ReportRequestText.IsSchedulledRequest)).ToListAsync();

            var requests = assignments.Distinct()
                .Select(asn => asn.GetReportRequest())
                .Where(req => req.ReportSchedule.IsScheduleActive ?? false)
                .Distinct();


            var schedules = _dbContext.ReportSchedules
                .Include(sch => sch.Districts).ThenInclude(distr => distr.ReportUser)
                .Include(sch => sch.ReportRequestSurvey.ReportAssignments)
                .Include(sch => sch.ReportRequestText.ReportAssignments)
                .Include(sch => sch.ReportRequestSurvey.ReportSchedule)
                .Include(sch => sch.ReportRequestText.ReportSchedule)
                .Where(distr => distr.IsScheduleActive ?? false);

            List<ReportAssignment> newAssignments = new List<ReportAssignment>();
            //Теперь нужно продублировать назначения для этих отчетов
            foreach (var request in requests)
            {
                var calculatedDeadline = GetDeadlineDate(request.ReportSchedule);
                
                //Если до сдачи отчета больше заданного в расписании кол-ва дней - не создаем назначение.
                if (DateTime.Now.AddDays(request.ReportSchedule.DaysBeforeAutoAssignment) > calculatedDeadline)
                {
                    foreach (var user in request.ReportSchedule.Districts.Select(distr => distr.ReportUser))
                    {
                        newAssignments.Add(new()
                        {
                            ReportUser = user,
                            ReportRequestText = (request is ReportRequestText) ? (ReportRequestText)request : null,
                            ReportRequestSurvey = (request is ReportRequestSurvey) ? (ReportRequestSurvey)request : null,
                            ActualDeadline = calculatedDeadline
                        });
                    }

                    _dbContext.ReportAssignments.AddRange(newAssignments);
                    _dbContext.SaveChanges();
                    _logger.Log(LogLevel.Information, $"Created {newAssignments.Count} assignments by schedule");
                } 
            }
        }

        /// <summary>
        /// Устанавливаем признак "просрочено" для отчетов, которые не сданы и не отменены вовремя
        /// </summary>
        private async Task SetOverdueOnAssignments()
        {
            await _dbContext.ReportAssignments
                .Where(assignment =>  !assignment.IsCancelledByOverDue && assignment.ActualDeadline < DateTime.Now)
                .ForEachAsync(ass =>ass.IsCancelledByOverDue = true);
            _dbContext.SaveChanges();

            _logger.Log(LogLevel.Information, $"Assignments clean-up successful");
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
                    while ((short)calculatedDeadline.DayOfWeek != schedule.DayOfWeek)
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
