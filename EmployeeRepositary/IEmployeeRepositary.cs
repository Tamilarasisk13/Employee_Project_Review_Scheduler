using EmployeeEntity;
using System.Collections.Generic;

namespace EmployeeDAL
{
   public interface IEmployeeRepositary
    {
        IEnumerable<Employee> DisplayEmployeeDetails();
        IEnumerable<AccountDetails> DisplayAccountDetails();
        Employee Add(Employee employee);
        bool CheckExists(string EmailId, long Mobilenumber);
        AccountDetails CheckLogin(AccountDetails accountDetails);
        void Delete(int employeeId);
        Employee GetEmployeeById(int userEmployeeId);
        bool UpdateEmployee(Employee employee);
        Employee GetEmployeeByAccountId(int id);
        AccountDetails GetAccountById(int userEmployeeId);
        AccountDetails AddAccountDetails(AccountDetails accountDetails);
    }
}
