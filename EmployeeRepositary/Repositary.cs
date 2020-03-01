using EmployeeEntity;
using System.Collections.Generic;
using System.Linq;
namespace EmployeeRepositary
{
    public class Repositary
    {
        public static List<Employee> employeesList = new List<Employee>();
        //static Repositary()
        //{
        //    employeesList.Add(new Employee { Firstname = "Tamil", Lastname = "arasi", Id =1, EmailId = "tamil@gmail.com", Gender = "female", Mobilenumber = 9787617628, DOB=Convert.ToDateTime("12/12/1995"), DOJ = Convert.ToDateTime("12/12/2020"), Username = "Tamil", Password = "tamil@123",Designation=(Designation)Enum.Parse(typeof(Designation), "HR") });
        //}
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
        public string CheckLogin(LoginUser loginUser)
        {
            string role = "";
            string designation = "";
            EmployeeContext employeeContext = new EmployeeContext();
             List<Employee> employeeList = employeeContext.Employees.ToList();
            foreach(var item in employeeList)
            {
                if(loginUser.Username==item.Username && loginUser.Password==item.Password)
                {                  
                   role = item.role;
                    designation = item.Designation.ToString();
                }
            }
            if (role == "Admin")
                return role;
            else 
                return designation;
            // Employee myUser = EmployeeContext.Employees.FirstOrDefault
            //    (u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));

            //if (myUser != null)
            //{
            //    //User was found
            //    //Proceed with your login process...
            //}
            //else    //User was not found
            //{
            //    //Do something to let them know that their credentials were not valid
            //}
            //bool flag = false;
            //foreach (Employee item in employeesList)
            //{
            //    if (item.Username.Equals(employee.Username) && item.Password.Equals(employee.Password))
            //    {
            //        flag = true;
            //        break;
            //    }
            //}
            //return flag;
        }
        //public string GetDesignation(string UserRole)
        //{
        //    string role = "";
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    List<Employee> employeeList = employeeContext.Employees.ToList();
        //    foreach(var item in employeeList)
        //    {
        //        if(employee.Username==item.Username && employee.Password==item.Password)
        //        {                  
        //           role = item.role;
        //        }
        //    }
        //    return role;
        //}
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
