
using System.Data.Entity;
using EmployeeEntity;

namespace EmployeeRepositary
{
      public class EmployeeContext : DbContext
        {
        public EmployeeContext():base("SampleConnection")
        {

        }
            public DbSet<Employee> employees { get; set; }
        }
  
}
