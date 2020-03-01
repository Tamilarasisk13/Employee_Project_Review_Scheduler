using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace EmployeeEntity
{
    public enum Designation
    {
        Scheduler,
        Reviewer,
        Reviewee,

    }
    public class Employee 
    {
        [Key]
        public int Id { get; set; }

        public string Firstname { get; set; }
       
        public string Lastname { get; set; }     
  
        public string EmailId { get; set; }
        
        public string Gender { get; set; }
       
        public long Mobilenumber { get; set; }

        public DateTime DOB { get; set; }
    
        public DateTime DOJ { get; set; }
 
        public string Username { get; set; }
      
        public string Password { get; set; }

        public string ConformPassword { get; set; }

        public Designation Designation { get; set; }

        public string employeeRole = "User";

        public string role
        {
            get
            {
                return employeeRole;
            }
            set
            {
                value = employeeRole;
            }
        }

        
    }
}

