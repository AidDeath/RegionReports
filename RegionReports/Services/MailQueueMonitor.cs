using RegionReports.Data;
using RegionReports.Data.Entities;
using RegionReports.Helpers;
using System.Net;
using System.Net.Mail;

namespace RegionReports.Services
{
    public class MailQueueMonitor
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly ILogger _logger;
        private readonly CancellationToken _cancellationToken;
        private readonly RegionReportsContext _dbContext;

        private SmtpClient smtpClient;
        private Queue<MailMessage> mailMessages = new();

        //Признак того,что нужно обновить настройки smtp
        public bool isSmtpSettingsUpdateNeeded { get; private set; }

        private bool isSmtpWorks;

        private bool isLoopActive = true;

        public MailQueueMonitor(IBackgroundTaskQueue taskQueue,
            ILogger<MailQueueMonitor> logger,
            IHostApplicationLifetime applicationLifetime,
            RegionReportsContext context)
        {
            _taskQueue = taskQueue;
            _logger = logger;
            _cancellationToken = applicationLifetime.ApplicationStopping;
            _dbContext = context;

            UpdateSmtpClientSettings();
        }

        public void StartMonitorLoop()
        {
            _logger.LogInformation("Mailer queue is initialized now");

            // Run a console user input loop in a background thread
            Task.Run(async () => await MonitorAsync());
        }

        private async ValueTask MonitorAsync()
        {
            while (isLoopActive && !_cancellationToken.IsCancellationRequested )
            {
                //Если нужно применить новые настройки - прменяем
                if (isSmtpSettingsUpdateNeeded) UpdateSmtpClientSettings();

                //Проверяем. работает ли Smtp, если нет - ждём пять минут и проверяем ещё раз
                if (isSmtpWorks)
                {
                    await _taskQueue.QueueBackgroundWorkItemAsync(BuildMessageTask);
                }
                else
                {
                    await Task.Delay(TimeSpan.FromMinutes(5));
                    isSmtpWorks = SmtpHelper.TestConnection(smtpClient.Host);
                }
                
            }

            //Здесь можно добавить сохранение очереди писем, позже
        }

        public void AddAsnMessageToQueue(ReportAssignment asn)
        {
            mailMessages.Enqueue(BuildAssignmentMessage(asn));
        }


        private async ValueTask BuildMessageTask(CancellationToken cancellationToken)
        {
            try
            {
                if (mailMessages.Count > 0) 
                {
                    var message = mailMessages.Dequeue();
                    //_logger.LogInformation(message);
                    smtpClient.Send(message);
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
            catch(OperationCanceledException)
            {
                // Prevent throwing if the Delay is cancelled
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error sending mail - {ex.GetBaseException().Message}"); ;
            }

        }

        public void UpdateSmtpClientSettings()
        {
            var profile = _dbContext.MailersProfiles.FirstOrDefault(prof => prof.IsProfileActive);
            if (profile is null)
            {
                _logger.LogWarning("Mail settings are not set, Mailer suspended until settings changed");
                isSmtpWorks = false;
                isLoopActive = false;
                return;
            }
             

            smtpClient = new SmtpClient()
            {
                Host = profile.MailServer,
                EnableSsl = false,
                Credentials = new NetworkCredential() { UserName = profile.MailerLogin, Password = profile.MailerPassword }
            };

            isSmtpSettingsUpdateNeeded = false;

            try
            {
                isSmtpWorks = SmtpHelper.TestConnection(smtpClient.Host);
            }
            catch (Exception ex)
            {
                _logger.LogError("Mail settings are incorrect: " + ex.GetBaseException().Message);
                isLoopActive=false;
                isSmtpWorks = false;
                return;
            }
            

            isLoopActive = true;


        }

        public void RenewSmtpSettings()
        {
            isSmtpSettingsUpdateNeeded = true;
            isLoopActive = true;
        }

        public MailMessage BuildAssignmentMessage(ReportAssignment reportAssignment)
        {
            var address = @"https://localhost:5001/reportinput/" + reportAssignment.Id;
            var messageBody = @"<h3>Добрый день!</h3> <br/> <div><p>Вам на исполнение назначен отчет.</p> 
                        <p>Для заполнения перейдите по ссылке, либо перейдите в раздел <b>Мои отчеты</b> в личном кабинете</p> 
                        <a href=" + $"\"{address}\"" + " > Перейти к заполнению</a> </div>";

            var message = new MailMessage(((NetworkCredential)smtpClient.Credentials)?.UserName ?? String.Empty, 
                reportAssignment.ReportUser.Email, "Новое задание для отчета", "") 
            { 
                IsBodyHtml = true 
            };

            message.Body = messageBody;

            return message;
        }

    }
}
