using System;

namespace Employee_Project_Review_Scheduler.Models
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
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public long Mobilenumber { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConformPassword { get; set; }
        public Designation Designation { get; set; }
    }
}