using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class DocVersion
    {
        public DocVersion()
        {
            Documents = new HashSet<Documents>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(3, ErrorMessage = "Name can not be less than 3 characters")]
        public string Name { get; set; }

        public int VersionNumber { get; set; }

        public string? Status { get; set; }

        public string? RouteFlag { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int? BatchId { get; set; }
        public virtual Batch? Batch { get; set; }
        public virtual ICollection<Documents>? Documents { get; set; }
    }
}
