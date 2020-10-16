using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEntity
{
   public class Review_Details
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string Reviewername { get; set; }
        public  Employee Employee { get; set; }

        public int ReviewerDesignationId { get; set; }
        public  Designations Designation { get; set; }

        public int ReviewerDepartmentId { get; set; }
        public  Departments Department { get; set; }

        [MaxLength(30)]
        public string Revieweename { get; set; }

        public int RevieweeDesignationId { get; set; }
        

        public int RevieweeDepartmentId { get; set; }


        [Required(ErrorMessage = "* Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
