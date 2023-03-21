using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Documents
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public string? Status { get; set; } = string.Empty;
        
        public string? RouteFlag { get; set; } = string.Empty;
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public int? VersionId { get; set; }
        public virtual DocVersion? Version { get; set; }
    }
}
