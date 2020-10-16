using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Models
{
    public class ReviewDetailsViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id;

        public IList<SelectListItem> Designations { get; set; }
        public IList<SelectListItem> Departments { get; set; }
        public IList<SelectListItem> ReviewerName { get; set; }
        public IList<SelectListItem> RevieweeName { get; set; }

        [MaxLength(30)]
        public string Reviewername { get; set; }

        public Employee Employee { get; set; }

        public int ReviewerDesignationId { get; set; }

        public Designations Designation { get; set; }

        public int ReviewerDepartmentId { get; set; }

        public Departments Department { get; set; }

        [MaxLength(30)]
        public string Revieweename { get; set; }

        public int RevieweeDesignationId { get; set; }

        public int RevieweeDepartmentId { get; set; }

        [Required(ErrorMessage = "* Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}