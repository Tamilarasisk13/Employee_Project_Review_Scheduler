using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEntity
{
    //public enum Designation
    //{
    //    Scheduler,
    //    Reviewer,
    //    Reviewee,

    //}
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Firstname is required")]
        [MaxLength(30)]        
        public string Firstname { get; set; }

        [Required(ErrorMessage = "* Lastname is required")]
        [MaxLength(30)]        
        public string Lastname { get; set; }

        [Required(ErrorMessage = "* EmailId is required")]
        [MaxLength(60)]
        [Index(IsUnique = true)]       
        public string EmailId { get; set; }

        [Required(ErrorMessage = "* Gender is required")]
        [MaxLength(6)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "* Mobilenumber is required")]

        [DataType(DataType.PhoneNumber)]
        [Index(IsUnique = true)]        
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

