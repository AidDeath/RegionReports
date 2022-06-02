namespace RegionReports.Data.Entities
{
    /// <summary>
    /// Область
    /// </summary>
    public class Region
    {
        public int Id { get; set; }

        public string RegionName { get; set; } = "";

        public List<District> Districts { get; set; } = new();
    }
}