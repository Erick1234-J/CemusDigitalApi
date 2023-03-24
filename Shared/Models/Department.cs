using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Department
    {
        public Department()
        {
                Employees = new HashSet<Employee>();
                Batches = new HashSet<Batch>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(3, ErrorMessage = "Name can not be less than 3 characters")]
        public string Name { get; set; } = string.Empty;

        public string? Status { get; set; } = string.Empty;

        public string? RouteFlag { get; set; } = string.Empty;
        public ICollection<Employee>? Employees { get; set;} 

        public ICollection<Batch>? Batches { get; set;}
    }
}
