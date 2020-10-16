using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee_Project_Review_Scheduler.Models
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "*Department is required")]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Department")]
        public string DepartmentName { get; set; }
    }
}