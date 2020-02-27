
using System.Data.Entity;
using EmployeeEntity;

namespace EmployeeRepositary
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("ProjectConnection")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
