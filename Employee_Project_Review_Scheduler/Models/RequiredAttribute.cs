using System;

namespace Employee_Project_Review_Scheduler.Models
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}