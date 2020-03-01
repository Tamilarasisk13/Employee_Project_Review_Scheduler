using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Project_Review_Scheduler.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Invalid Username ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(15)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,15}", ErrorMessage = "Invalid password")]
        public string Password { get; set; }

    }
}