using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Project_Review_Scheduler.Models
{
    public enum Designation
    {
        Scheduler,
        Reviewer,
        Reviewee,
    }
    public class EmployeeViewModel
    {

        [Required(ErrorMessage = "Firstname is required")]
        [MaxLength(30)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [MaxLength(30)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid Lastname")]
        public string Lastname { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }


        [Required(ErrorMessage = "EmailId is required")]
        [MaxLength(60)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
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
    }
}