using System;
using System.ComponentModel.DataAnnotations;
namespace EmployeeEntity
{
    public class Employee
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
        [Required(ErrorMessage = "Firstname is required")]
        [MaxLength(30)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Lastname")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(30)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Lastname")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Id is required")]
        [MaxLength(5)]
        [Range(1, 99999)]
        [RegularExpression(@"^[0-9]{5}", ErrorMessage = "Invalid Id")]
        public string id { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [MaxLength(60)]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Please enter correct email address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string emailId { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string gender { get; set; }


        [Required(ErrorMessage = "Mobilenumber is required")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
 	    [RegularExpression(@"^\(?([6-9]{1})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string mobileNumber { get; set; }


        [Required(ErrorMessage = "DOB is required")]
        [MaxLength(10)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid DOB")]
        public DateTime dob { get; set; }


        [Required(ErrorMessage = "DOJ is required")]
        [MaxLength(10)]
        [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid DOJ")]
        public DateTime doj { get; set; }


        [Required(ErrorMessage = "Username is required")]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Invalid Username ")]
        public string userName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [MaxLength(15)]
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$", ErrorMessage = "Invalid Password")]
        public string password { get; set; }


        [Required(ErrorMessage = " Conform Password is required")]
        [MaxLength(15)]
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$", ErrorMessage = "Invalid conform Password")]
        public string conformPassword { get; set; }

       
        public Designation designation { get; set; }


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

