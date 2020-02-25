using System;
using EmployeeEntity;
using System.Data.Entity;
using System.Collections.Generic;
using static EmployeeEntity.Employee;
using System.Linq;

namespace EmployeeRepositary
{
    public class Repositary
    {
        public static List<Employee> employees = new List<Employee>();
        static Repositary()
        {          
            //employees.Add(new Employee {firstName= "Tamil",lastName= "arasi", id=1, "female", "tamil@gmail.com", 9787617628, Convert.ToDateTime("12/12/1995"), Convert.ToDateTime("12/12/2020"), "Tamil", "tamil@123", (Designation)Enum.Parse(typeof(Designation), "HR") });
            employees.Add(new Employee { Firstname = "Tamil", Lastname = "arasi", Id =1, EmailId = "tamil@gmail.com", Gender = "female", Mobilenumber = 9787617628, DOB=Convert.ToDateTime("12/12/1995"), DOJ = Convert.ToDateTime("12/12/2020"), Username = "Tamil", Password = "tamil@123",Designation=(Designation)Enum.Parse(typeof(Designation), "HR") });
        }
        public List<Employee> GetEmployees()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            return employeeContext.employees.ToList();
        }
        public int Count()
        {
            return employees.Count;
        }
        public void Add(Employee employee)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            employeeContext.employees.Add(employee);
            //employees.Add(employee);
        }
        public static IEnumerable<Employee> GetEmployee()
        {
            return employees;
        }
        public bool CheckLogin(string username, string password)
        {
            bool flag = false;
            foreach (Employee item in employees)
            {
                if (item.Username.Equals(username) && item.Password.Equals(password))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void Delete(int employeeId)
        {
            Employee employee = GetEmployeeById(employeeId);
            if (employee != null)
                employees.Remove(employee);
        }
        public void Update(Employee employee)
        {
            Employee employeeObject = employees.Find(id => id.Id == employee.Id);
            employeeObject.Firstname= employee.Firstname;
            employeeObject.Lastname = employee.Lastname;
            employeeObject.EmailId = employee.EmailId;
            employeeObject.DOB = employee.DOB;
            employeeObject.DOJ= employee.DOJ;
            employeeObject.Mobilenumber = employee.Mobilenumber;
            employeeObject.Gender = employee.Gender;
            employeeObject.Username = employee.Username;
            employeeObject.Password = employee.Password;
            employeeObject.Designation = employee.Designation;
        }
        public Employee GetEmployeeById(int userEmployeeId)
        {
            return employees.Find(id => id.Id == userEmployeeId);
        }
    }
}
