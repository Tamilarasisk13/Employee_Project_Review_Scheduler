
using System.Data.Entity;
using EmployeeEntity;


namespace EmployeeDAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("ProjectConnection")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departments> EmployeeDepartments { get; set; }
        public DbSet<Designations> EmployeeDesignations { get; set; }
        public DbSet<AccountDetails>Account{ get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }

        //Method to create stored procedure
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().MapToStoredProcedures();
            modelBuilder.Entity<Departments>().MapToStoredProcedures();
            modelBuilder.Entity<Designations>().MapToStoredProcedures();
            modelBuilder.Entity<AccountDetails>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
    }
}
