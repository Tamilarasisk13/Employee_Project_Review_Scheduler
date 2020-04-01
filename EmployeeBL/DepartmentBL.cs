using EmployeeEntity;
using System.Collections.Generic;
using EmployeeDAL;

namespace ReviewSchedulerBL
{
    public class DepartmentBL : IDepartmentBL
    {
        IDepartmentRepositary departmentRepositary;
        public DepartmentBL()
        {
            departmentRepositary = new DepartmentRepositary();
        }
        //Method to add department
        public bool AddDepartment(Departments departments)
        {
            return departmentRepositary.AddDepartments(departments);
        }

        //Method to get department
        public IEnumerable<Departments> GetDepartments()
        {
            return departmentRepositary.GetDepartments();
        }
      
        //Method to delete department
        public void DeleteDepartments(int departmentId)
        {
            departmentRepositary.DeleteDepartments(departmentId);
        }
    }
}
