using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RegionReports.Data.Entities
{
    public class ReportFileBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fileUniqueName")]
        public string FileUniqueName { get; set; } = "";

        [JsonPropertyName("fileOriginalName")]
        public string FileOriginalName { get; set; } = "";

        [JsonPropertyName("fileType")]
        public int FileType { get; set; }


    }
}
