namespace RegionReports.Data.Entities
{
    public class MailerProfile
    {
        public int Id { get; set; }

        /// <summary>
        /// Название профиля почтовых настроек
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// Адрес или имя почтового сервера
        /// </summary>
        public string MailServer { get; set; }

        /// <summary>
        /// Порт почтового сервера
        /// </summary>
        public int MailServerPort { get; set; }

        /// <summary>
        /// Логин для отправителя писем
        /// </summary>
        public string MailerLogin { get; set; }

        /// <summary>
        /// Пароль отправителя письма
        /// </summary>
        public string MailerPassword { get; set; }

        /// <summary>
        /// Активен ли этот профиль
        /// </summary>
        public bool IsProfileActive { get; set; }

        /// <summary>
        /// Отправлять ли письмо о новом назначении
        /// </summary>
        public bool SendAboutAssignment { get; set; }

        /// <summary>
        /// Предупреждать о скором истечении срока отчета
        /// </summary>
        public bool SendAboutNearDeadline { get; set; }

        /// <summary>
        /// Оповещать о том, что срок сдачи отчета истек
        /// </summary>
        public bool SendAboutOverdue { get; set; }

        /// <summary>
        /// Часов до предупреждения о ежедневном отчете
        /// </summary>
        public int? HoursBeforeDailySending { get; set; }

        /// <summary>
        /// Дней до напоминания о ежедневном отчете
        /// </summary>
        public int? DaysBeforeWeeklySending { get; set; }

        /// <summary>
        /// Дней до напоминания о ежемесячном отчете
        /// </summary>
        public int? DaysMonthlySending { get; set; }

        /// <summary>
        /// Дней до напоминания о отчете без расписаиня
        /// </summary>
        public int? DaysNonScheduledSending { get; set; }
    }
}

//Профили настройки почты:
//Профиль настроек почты.

//Название профиля

//Почтовый сервер
//Порт

//Учетная запись для отправки почты
//Пароль для отправки почты
//Enable Ssl

//Активный профиль?

//Отправлять респондентам письмо о назначении нового задания?

//Отправлять напоминание респондентам о несданном отчете.
//	Для ежемесячных -
//	Для Еженедельных -
//	Для Ежедневных -

//Отправлять ли письмо о том, что предоставление ответа просрочено.