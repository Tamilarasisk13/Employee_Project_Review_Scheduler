using System.Collections.Generic;
using EmployeeDAL;
using EmployeeEntity;

namespace ReviewSchedulerBL
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRepositary employeeRepositary;
        public EmployeeBL()
        {
             employeeRepositary = new EmployeesRepositary();
        }
        //Method to add employee
        public Employee Add(Employee employee)
        {
           return employeeRepositary.Add(employee);
        }      

        //Method to generate random password
        public string GeneratePassword(string emailId,string MobileNumber)
        {
            return emailId.Substring(0,3)+MobileNumber.Substring(MobileNumber.Length-4);
        }

        //Method to check the user while login
       public AccountDetails CheckLogin(AccountDetails accountDetails)
        {
            return employeeRepositary.CheckLogin(accountDetails);
        }

        //Method to check already exists or not
        public bool CheckExists(string EmailId, long Mobilenumber)
        {
            return employeeRepositary.CheckExists(EmailId, Mobilenumber);
        }

        //Method to display employee details
        public IEnumerable<Employee> DisplayEmployeeDetails()
        {
            return employeeRepositary.DisplayEmployeeDetails();           
        }

        //Method to get account details
        public IEnumerable<AccountDetails> DisplayAccountDetails()
        {
            return employeeRepositary.DisplayAccountDetails();
        }

        //Method to delete employee details
        public void Delete(int employeeId)
        {
            employeeRepositary.Delete(employeeId);
        }

        //Method to add account details
        public AccountDetails AddAccountDetails(AccountDetails accountDetails)
        {
            return employeeRepositary.AddAccountDetails(accountDetails);

        }

        //Method to get employee by employeeId
        public Employee GetEmployeeById(int id)
        {
            return employeeRepositary.GetEmployeeById(id);
        }

        //Method to  Get Employee By AccountId
        public Employee GetEmployeeByAccountId(int id)
        {
            return employeeRepositary.GetEmployeeByAccountId(id);
        }

        //Method to update employee details
        public bool UpdateEmployee(Employee employee)
        {
            return employeeRepositary.UpdateEmployee(employee);
        }
        public List<Employee> GetEmployees()
        {
            return employeeRepositary.GetEmployees();
        }
        public bool UpdatePassword(AccountDetails accountDetails)
        {
            return employeeRepositary.UpdatePassword(accountDetails);
        }
    }
}
