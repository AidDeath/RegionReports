using RegionReports.Data.Interfaces;

namespace RegionReports.Data.Entities
{
    public class ReportBase : IReport
    {
        public int Id { get; set; }
        public int ReportUserId { get; set; }
        public ReportUser? ReportUser { get; set; }
        public int ReportAssignmentId { get; set; }
        public ReportAssignment ReportAssignment { get; set; }
        public DateTime DateFilled { get; set; } = DateTime.Now;


    }
}
