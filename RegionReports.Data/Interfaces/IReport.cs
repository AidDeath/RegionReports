using RegionReports.Data.Entities;

namespace RegionReports.Data.Interfaces
{
    internal interface IReport
    {
        public int Id { get; set; }

        public int ReportUserId { get; set; }

        /// <summary>
        /// Пользователь выполнивший отчет
        /// </summary>
        public ReportUser? ReportUser { get; set; }

        /// <summary>
        /// Дата ответа
        /// </summary>
        public DateTime DateFilled { get; set; }

        public ReportAssignment? ReportAssignment { get; set; }
    }
}