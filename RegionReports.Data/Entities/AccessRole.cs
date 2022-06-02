namespace RegionReports.Data.Entities
{
    public class AccessRole
    {
        public int Id { get; set; }
        public string WindowsRoleName { get; set; }

        public bool IsAdministrator { get; set; }
    }
}