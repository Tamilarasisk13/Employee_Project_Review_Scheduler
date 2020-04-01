using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEntity
{
   public  class AccountDetails
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "* Username is required")]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

       
        [Required(ErrorMessage = "* Password is required")]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Password { get; set; }
       
        //public int DesignationId { get; set; }

        public string Role { get; set; }
    }
}
