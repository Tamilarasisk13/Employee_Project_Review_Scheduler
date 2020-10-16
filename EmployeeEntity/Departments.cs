using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "* Department name is required")]
        [MaxLength(30, ErrorMessage = "* Department name is less than 30 characters")]
        
        public string DepartmentName { get; set; }

        public  ICollection<Employee> Employees { get; set; }
        public  ICollection<Review_Details> Review_Detail { get; set; }

    }
}
