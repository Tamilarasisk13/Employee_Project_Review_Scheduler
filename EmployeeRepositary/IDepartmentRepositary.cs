using System;
using EmployeeEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    //Interface of Department Repositary
    public interface IDepartmentRepositary
    {       
        List<Departments> GetDepartments();
        bool AddDepartments(Departments departments);
        void DeleteDepartments(int departmentId);
        Departments GetEmployeeById(int departmentId);
    }
}
