﻿namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Предоставленная информация на запрос в виде опроса
    /// </summary>
    public class ReportSurvey
    {
        public int Id { get; set; }

        public int ReportUserId { get; set; }

        /// <summary>
        /// Пользователь заполнивший опрос
        /// </summary>
        public ReportUser? ReportUser { get; set; }

        /// <summary>
        /// Дата ответа
        /// </summary>
        public DateTime DateFilled { get; set; } = DateTime.Now;

        /// <summary>
        /// Отмеченные пользователем пункты опроса
        /// </summary>
        public List<ReportSurveyOption> SelectedOptions { get; set; } = new List<ReportSurveyOption>();

        public int ReportAssignmentId { get; set; }
        /// <summary>
        /// Ссылка на назначение, по которому сделан этот отчет
        /// </summary>
        public ReportAssignment ReportAssignment { get; set; }

    }

    public class ReportSurveyOption
    {
        public int Id { get; set; }

        public int ReportSurveyId { get; set; }

        public ReportSurvey? ReportSurvey { get; set; }


        /// <summary>
        /// Выбран ли этот конкретный пункт пользователем при заполнении опроса
        /// </summary>
        public bool Checked { get; set; } = false;

        public int ReportRequestSurveyOptionId { get; set; }
        /// <summary>
        /// Вариант выбора из задания
        /// </summary>
        public ReportRequestSurveyOption? ReportRequestSurveyOption { get; set; }

    }
}
