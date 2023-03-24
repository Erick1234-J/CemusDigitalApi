using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Batch
    {
        public Batch()
        {
            Versions = new HashSet<DocVersion>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(3, ErrorMessage = "Name can not be less than 3 characters")]
        public string Name { get; set; }

        public int BatchCode { get; set; }

        public string? Status { get; set; }

        public string? RouteFlag { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public int? DepartmentId { get; set; }
        public virtual ICollection<DocVersion>? Versions { get; set; }

        public virtual Department? Department { get; set; }
    }
}
