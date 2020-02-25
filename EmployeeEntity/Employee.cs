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
        
        [Required(ErrorMessage = "Firstname is required")]
        [MaxLength(30)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Lastname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(30)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Lastname")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Id is required")]        
        [Range(1, 99999)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Mobilenumber is required")]
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([6-9]{1}[0-9]{9})$", ErrorMessage = "Entered phone format is not valid.")]
        public long Mobilenumber { get; set; }


        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "DOJ is required")]
        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Invalid Username ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(15)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,15}", ErrorMessage = "Invalid password")]
        public string Password { get; set; }

        [Required(ErrorMessage = " Conform Password is required")]
        [MaxLength(15)]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
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

