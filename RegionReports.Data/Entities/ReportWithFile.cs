namespace RegionReports.Data.Entities
{
    public class ReportWithFile : ReportBase
    {
        public int ResponseFileId { get; set; }
        public ResponseFile ResponseFile { get; set; }
    }

    public class ResponseFile : ReportFileBase
    {
        public ReportWithFile ReportWithFile { get; set; }
    }
}