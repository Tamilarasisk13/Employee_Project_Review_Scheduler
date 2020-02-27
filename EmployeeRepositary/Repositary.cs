using System;
using EmployeeEntity;
using System.Collections.Generic;
using System.Linq;
namespace EmployeeRepositary
{
    public class Repositary
    {
        public static List<Employee> employeesList = new List<Employee>();
        static Repositary()
        {
            employeesList.Add(new Employee { Firstname = "Tamil", Lastname = "arasi", Id =1, EmailId = "tamil@gmail.com", Gender = "female", Mobilenumber = 9787617628, DOB=Convert.ToDateTime("12/12/1995"), DOJ = Convert.ToDateTime("12/12/2020"), Username = "Tamil", Password = "tamil@123",Designation=(Designation)Enum.Parse(typeof(Designation), "HR") });
        }
        public void GetEmployees()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            employeeContext.Employees.ToList();
           
        }
      
        public bool Add(Employee employee)
        {
            //try
            //{
                EmployeeContext employeeContext = new EmployeeContext();
                employeeContext.Employees.Add(employee);
                employeeContext.SaveChanges();
                return true;
            //}
          //catch(Exception e)
          //  {
          //      Console.WriteLine(e.Message + e.StackTrace);
          //      return false;
          //  }
            //employees.Add(employee);
        }
        public static IEnumerable<Employee> GetEmployee()
        {
            return employeesList;
        }
        public bool CheckLogin(string username, string password)
        {
            bool flag = false;
            foreach (Employee item in employeesList)
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
                employeesList.Remove(employee);
            //EmployeeContext employeeContext = new EmployeeContext();
            //employeeContext.Employees.Remove(employee);
            //employeeContext.SaveChanges();

        }
        public void Update(Employee employee)
        {
            Employee employeeObject = employeesList.Find(id => id.Id == employee.Id);
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
            return employeesList.Find(id => id.Id == userEmployeeId);
        }
    }
}
