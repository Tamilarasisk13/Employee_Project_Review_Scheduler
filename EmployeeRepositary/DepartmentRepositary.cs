using EmployeeEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace EmployeeDAL
{
    public class DepartmentRepositary: IDepartmentRepositary
    {

        //Method to get employee departments
        public IEnumerable<Departments> GetDepartments()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            return employeeContext.EmployeeDepartments.ToList();
        }

        //Method to add department
        public bool AddDepartments(Departments departments)
        {
            //using (EmployeeContext employeeContext = new EmployeeContext())
            //{
            //    SqlParameter sql = new SqlParameter("@DepartmentName", departments.DepartmentName);
            //    int count = employeeContext.Database.ExecuteSqlCommand("Departments_Insert @DepartmentName", sql);
            //    return true;
            //}

            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                employeeContext.Entry(departments).State = EntityState.Added;
                employeeContext.SaveChanges();
            }
            return true;
        }

        //Method to delete department
        public void DeleteDepartments(int departmentId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Departments departments= GetEmployeeById(departmentId);
                employeeContext.Entry(departments).State = EntityState.Deleted;
                employeeContext.SaveChanges();
            }
        }

        //Method to get employee by DepartmentId
        public Departments GetEmployeeById(int departmentId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.EmployeeDepartments.Find(departmentId);
            }
        }
    }
}
