using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEntity
{
   public class ExceptionLogger
    {
        [Key]
        public int ExceptionId { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrack { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public DateTime ExceptionLogTime { get; set; }
    }
}
