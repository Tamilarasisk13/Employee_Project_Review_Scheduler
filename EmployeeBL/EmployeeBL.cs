using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using EmployeeRepositary;
namespace ReviewShedulerBL
{
    public class EmployeeBL
    {
        Repositary repositary = new Repositary();
        public void Add(Employee employee)
        {
            repositary.Add(employee);
        }
       public void GetEmployees()
        {
            repositary.GetEmployees();
        }
       public bool CheckLogin(string username, string password)
        {
            return repositary.CheckLogin(username, password);
        }
        public void Delete(int employeeId)
        {
            repositary.Delete(employeeId);
        }
        public Employee GetEmployeeById(int id)
        {
            return GetEmployeeById(id);
        }
    }
}
