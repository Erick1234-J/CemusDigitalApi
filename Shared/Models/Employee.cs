using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared.Models
{
    public class Employee
    {
        public Employee()
        {
            Documents = new HashSet<Documents>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "First Name can not be less than 3 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(3, ErrorMessage = "Last Name can not be less than 3 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Title")]
        [MinLength(3, ErrorMessage = "Title can not be less than 3 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Address")]
        [MinLength(3, ErrorMessage = "Address can not be less than 3 characters")]
        public string Address { get; set; } = string.Empty;

        public int EmployeeNo { get; set; }

        public string? Status { get; set; } = string.Empty;

        public string? RouteFlag {  get; set; } = string.Empty;

        public int? DepartmentsId { get; set; }
        public virtual Department? Departments { get; set; }

        public  ICollection<Documents>? Documents { get; set; }
    }
}
