using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace EmployeeEntity
{
    public enum Designation
    {
        HR,
        Scheduler,
        CEO,
        Reviewer,
        Reviewee,
        Tester,
        Developer
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

        //public Employee(string firstName, string lastName, int id, string emailId, string gender, long mobileNumber, DateTime dob, DateTime doj,string userName, string password, Designation designation )
        //{
        //    this.firstName = firstName;
        //    this.lastName = lastName;
        //    this.id = id;
        //    this.emailId = emailId;
        //    this.gender = gender;
        //    this.mobileNumber = mobileNumber;
        //    this.dob = dob;
        //    this.doj = doj;
        //    this.userName = userName;
        //    this.password = password;
        //    this.designation = designation;
        //}
    }
}

