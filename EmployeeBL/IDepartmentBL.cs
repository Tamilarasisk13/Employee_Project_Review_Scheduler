using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSchedulerBL
{
    public interface IDepartmentBL
    {
        bool AddDepartment(Departments departments);
        List<Departments> GetDepartments();
        
        void DeleteDepartments(int departmentId);
    }
}
