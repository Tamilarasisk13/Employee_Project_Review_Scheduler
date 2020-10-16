using EmployeeEntity;
using System.Collections.Generic;

namespace ReviewSchedulerBL
{
   public interface IEmployeeBL
    {
        Employee GetEmployeeByAccountId(int id);
        Employee GetEmployeeById(int id);
        AccountDetails CheckLogin(AccountDetails accountDetails);
        Employee Add(Employee employee);
        bool CheckExists(string EmailId, long Mobilenumber);
        AccountDetails AddAccountDetails(AccountDetails accountDetails);
        string GeneratePassword(string emailId, string MobileNumber);
        IEnumerable<Employee> DisplayEmployeeDetails();
        IEnumerable<AccountDetails> DisplayAccountDetails();
        void Delete(int employeeId);
        bool UpdateEmployee(Employee employee);
         List<Employee> GetEmployees();
        bool UpdatePassword(AccountDetails accountDetails);

        //Employee GetEmployeeByDepartmenIDAndDesignationID(int DepartmentId, int DesignationId);
    }
}
