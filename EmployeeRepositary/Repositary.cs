using System;
using EmployeeEntity;
using UserEntity;
using System.Collections.Generic;
using static EmployeeEntity.Employee;
namespace EmployeeRepositary
{
    public class Repositary
    {
        public static List<Employee> employees = new List<Employee>();
        static Repositary()
        {          
            //employees.Add(new Employee {firstName= "Tamil",lastName= "arasi", id=1, "female", "tamil@gmail.com", 9787617628, Convert.ToDateTime("12/12/1995"), Convert.ToDateTime("12/12/2020"), "Tamil", "tamil@123", (Designation)Enum.Parse(typeof(Designation), "HR") });
            employees.Add(new Employee { firstName = "Tamil", lastName = "arasi", id = "1", emailId = "tamil@gmail.com", gender = "female", mobileNumber = "9787617628", dob ="12/12/1995", doj = "12/12/2020", userName = "Tamil", password = "tamil@123",designation=(Designation)Enum.Parse(typeof(Designation), "HR") });
        }
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public static IEnumerable<Employee> GetEmployee()
        {
            return employees;
        }
        public bool CheckLogin(LoginUser loginuser)
        {
            bool flag = false;
            foreach (Employee item in employees)
            {
                if (item.userName.Equals(loginuser.username) && item.password.Equals(loginuser.password))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
