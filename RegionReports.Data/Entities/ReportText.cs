using RegionReports.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionReports.Data.Entities
{
    public class ReportText : ReportBase, IReport
    {
        /// <summary>
        /// Текст ответа респондента в HTML
        /// </summary>
        public string RepsonseString { get; set; } = string.Empty;
    }
}
