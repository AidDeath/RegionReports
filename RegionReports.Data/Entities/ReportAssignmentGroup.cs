namespace RegionReports.Data.Entities
{
    public  class ReportAssignmentGroup
    {
        public int Id { get; set; }

        public List<ReportAssignment> Assignments { get; set; }
    }
}
