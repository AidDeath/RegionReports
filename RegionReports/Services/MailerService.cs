using RegionReports.Data;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using System.Net;
using System.Net.Mail;

namespace RegionReports.Services
{
    public class MailerService
    {
        private readonly RegionReportsContext _dbContext;
        private readonly IDbAccessor _database;
        private readonly MailQueueMonitor _mailQueue;

        public MailerService(RegionReportsContext dbContext, IDbAccessor database, MailQueueMonitor mailQueue)
        {
            _dbContext = dbContext;
            _database = database;
            _mailQueue = mailQueue;
        }

        public IEnumerable<MailerProfile>? GetAllMailerProfiles()
        {
            return _database.MailerProfiles.GetQueryable().ToList();
        }

        public void UpdateMailerProfile(MailerProfile mailerProfile)
        {
            _database.MailerProfiles.Update(mailerProfile);
            _mailQueue.RenewSmtpSettings();
        }


        public void SendAssignmentMessage(ReportAssignment assignment)
        {

            _mailQueue.AddAsnMessageToQueue(assignment);
        }

        [Obsolete]
        public MailMessage BuildAssignmentMessage(ReportAssignment reportAssignment)
        {
            var address = @"https://localhost:5001/reportinput/" + reportAssignment.Id;
            var messageBody = @"<h3>Добрый день!</h3> <br/> <div><p>Вам на исполнение назначен отчет.</p> 
                        <p>Для заполнения перейдите по ссылке, либо перейдите в раздел <b>Мои отчеты</b> в личном кабинете</p> 
                        <a href="+ $"\"{address}\"" + " > Перейти к заполнению</a> </div>";

            var mailerName = _database.MailerProfiles.GetQueryable().FirstOrDefault(p => p.IsProfileActive)?.MailerLogin;
            var message = new MailMessage(mailerName ?? String.Empty, reportAssignment.ReportUser.Email, "Новое задание для отчета", "") { IsBodyHtml = true };

            message.Body = messageBody;

            return message;
        }

        public void UpdateMailSettings() => _mailQueue.RenewSmtpSettings();
    }

}