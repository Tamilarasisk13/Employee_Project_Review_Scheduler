using EmployeeEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Project_Review_Scheduler.Models
{
    public class EmployeeViewModel
    {

        [Required(ErrorMessage = "* Firstname is required")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = " Enter only alphabets")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "* Lastname is required")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = " Enter only alphabets")]
        public string Lastname { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "* EmailId is required")]
        [Index(IsUnique = true)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string EmailId { get; set; }

        [Required(ErrorMessage = "* Gender is required")]

        public string Gender { get; set; }

        [Required(ErrorMessage = "* Mobilenumber is required")]
        // [DataType(DataType.PhoneNumber)]
        [Index(IsUnique = true)]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Mobile Number is Invalid")]
        public long Mobilenumber { get; set; }


        [Required(ErrorMessage = "* DOB is required")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "* DOJ is required")]
        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        public int DesignationId { get; set; }
        public Designations Designation { get; set; }

        public int DepartmentId { get; set; }
        public Departments Department { get; set; }

        public int AccountId { get; set; }
        public AccountDetails AccountDetails { get; set; }
    }
}