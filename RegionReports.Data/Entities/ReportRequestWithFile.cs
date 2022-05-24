namespace RegionReports.Data.Entities
{
    public class ReportRequestWithFile : ReportRequestBase
    {
        public int Id { get; set; }
        public int ReportRequestFileId { get; set; }
        public ReportRequestTemplateFile TemplateFile { get; set; }
    }

    public class ReportRequestTemplateFile : ReportFileBase
    {
        public ReportRequestWithFile ReportRequestWithFile { get; set; }
    }
}
