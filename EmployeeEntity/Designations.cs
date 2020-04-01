using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEntity
{
    public class Designations
    {
        [Key]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "* Designation name is required")]
        [MaxLength(30, ErrorMessage = "* Designation name is less than 30 characters")]
        public string DesignationName { get; set; }
    }
}
