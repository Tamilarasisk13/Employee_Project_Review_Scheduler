using System;
using EmployeeEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
   public interface IDepartmentRepositary
    {
        
        IEnumerable<Departments> GetDepartments();
        bool AddDepartments(Departments departments);
        void DeleteDepartments(int departmentId);
        Departments GetEmployeeById(int departmentId);
    }
}
