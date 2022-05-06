using RegionReports.Data.Interfaces;

namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Предоставленная информация на запрос в виде опроса
    /// </summary>
    public class ReportSurvey : ReportBase, IReport
    {

        /// <summary>
        /// Отмеченные пользователем пункты опроса
        /// </summary>
        public List<ReportSurveyOption> SelectableOptions { get; set; } = new List<ReportSurveyOption>();

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
