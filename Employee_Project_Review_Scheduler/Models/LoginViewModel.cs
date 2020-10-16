using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee_Project_Review_Scheduler.Models
{
    public class LoginViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int AccountId { get; set; } 

        [Required(ErrorMessage = "*Username is required")]
        
        public string Username { get; set; }

        [Required(ErrorMessage = "*Password is required")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "* Password is required")]
        //[Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        //public string ConformPassword { get; set; }

        //public string Role{get;set;}
    }
}