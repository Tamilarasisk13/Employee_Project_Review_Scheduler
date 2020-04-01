using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Project_Review_Scheduler.Models
{
    public class DesignationViewModel
    {
        [Required(ErrorMessage = "* Designation is required")]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Designation")]
        public string DesignationName { get; set; }
    }

}