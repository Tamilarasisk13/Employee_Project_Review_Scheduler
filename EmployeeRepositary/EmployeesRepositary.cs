using EmployeeEntity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System;

namespace EmployeeDAL
{
    public class EmployeesRepositary : IEmployeeRepositary
    {
        //Method to get employee details
        public IEnumerable<Employee> DisplayEmployeeDetails()
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.Employees.Include("Department").Include("Designation").ToList();
            }
        }

        //Method to get account details
        public IEnumerable<AccountDetails> DisplayAccountDetails()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            return employeeContext.Account.ToList();
        }

        //Method to add employee
        public Employee Add(Employee employee)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {

                //SqlParameter sqlFirstname = new SqlParameter("@Firstname", employee.Firstname);
                //SqlParameter sqlLastname = new SqlParameter("@Lastname", employee.Lastname);
                //SqlParameter sqlEmailId = new SqlParameter("@EmailId", employee.EmailId);
                //SqlParameter sqlGender = new SqlParameter("@Gender", employee.Gender);
                //SqlParameter sqlMobilenumber = new SqlParameter("@Mobilenumber", employee.Mobilenumber);
                //SqlParameter sqlDOB = new SqlParameter("@DOB", employee.DOB);
                //SqlParameter sqlDOJ = new SqlParameter("@DOJ", employee.DOJ);
                //SqlParameter sqlDesignationId = new SqlParameter("@DesignationId", employee.DesignationId);
                //SqlParameter sqlDepartmentId = new SqlParameter("@DepartmentId", employee.DepartmentId);
                //SqlParameter sqlAccountId = new SqlParameter("@AccountId", employee.AccountId);
                //int count = employeeContext.Database.ExecuteSqlCommand("Employee_Insert @Firstname,@Lastname,@EmailId,@Gender,@Mobilenumber, @DOB, @DOJ, @DesignationId, @DepartmentId,@AccountId", sqlFirstname, sqlLastname, sqlEmailId, sqlGender, sqlMobilenumber, sqlDOB, sqlDOJ, sqlDesignationId, sqlDepartmentId, sqlAccountId);
                employeeContext.Entry(employee).State = EntityState.Added;
                employeeContext.SaveChanges();
                return employee;

            }
        }

        //Method to add emloyee details
        public AccountDetails AddAccountDetails(AccountDetails accountDetails)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {


                //SqlParameter sqlUsername = new SqlParameter("@Username", accountDetails.Username);
                //SqlParameter sqlPassword = new SqlParameter("@Password", accountDetails.Password);
                //SqlParameter sqlRole = new SqlParameter("@Role", accountDetails.Role);
                //int count = employeeContext.Database.ExecuteSqlCommand("AccountDetails_Insert @Username,@Password,@Role", sqlUsername, sqlPassword, sqlRole);
                employeeContext.Entry(accountDetails).State = EntityState.Added;
                employeeContext.SaveChanges();
                return accountDetails;


            }
        }

        //Method to check already exists or not
        public bool CheckExists(string EmailId, long Mobilenumber)
        {
            Employee employee;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                employee = employeeContext.Employees.FirstOrDefault(p => p.EmailId == EmailId || p.Mobilenumber == Mobilenumber);
            }
            if (employee == null)
                return true;
            else
                return false;
        }



        public AccountDetails CheckLogin(AccountDetails accountDetails)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.Account.FirstOrDefault(p => p.Username == accountDetails.Username && p.Password == accountDetails.Password);
            }
        }


        //Method to delete employee details with their account details
        public void Delete(int employeeId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Employee employee = GetEmployeeById(employeeId);
                AccountDetails accountdetails = GetAccountById(employee.AccountId);
                //employeeContext.Entry(employee).State = EntityState.Deleted;
                //employeeContext.SaveChanges();
                SqlParameter sqlEmployee = new SqlParameter("@Id", employee.Id);
                employeeContext.Database.ExecuteSqlCommand("Employee_Delete @Id", sqlEmployee);
                SqlParameter sqlAccount = new SqlParameter("@AccountId", accountdetails.AccountId);
                employeeContext.Database.ExecuteSqlCommand("AccountDetails_Delete @AccountId", sqlAccount);
            }
        }

        //Method to get employee by employeeId
        public Employee GetEmployeeById(int userEmployeeId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.Employees.Find(userEmployeeId);
            }
        }

        //Method to get Employee by AccountId
        public Employee GetEmployeeByAccountId(int userAccountId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.Employees.Include("Department").Include("Designation").FirstOrDefault(p => p.AccountId == userAccountId);
            }

        }


        //Method to get account by AccountId
        public AccountDetails GetAccountById(int accountId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.Account.Find(accountId);
            }
        }
        public List<Employee> GetEmployees()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            return employeeContext.Employees.ToList();
        }
        //Method to update employee
        public bool UpdateEmployee(Employee employee)
        {
            //try
            //{
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                employeeContext.Entry(employee).State = EntityState.Modified;
                employeeContext.SaveChanges();
                return true;
            }
            //}
            //    catch
            //    {
            //        return false;
            //    }
        }
        //Attaching an entity of type 'EmployeeEntity.AccountDetails' failed because another entity of the same type already has the same primary key value.This can happen when using the 'Attach' method or setting the state of an entity to 'Unchanged' or 'Modified' if any entities in the graph have conflicting key values.This may be because some entities are new and have not yet received database-generated key values.In this case use the 'Add' method or the 'Added' entity state to track the graph and then set the state of non-new entities to 'Unchanged' or 'Modified' as appropriate.
        public bool UpdatePassword(AccountDetails accountDetails)
        {
            //int count = 0;
            AccountDetails accountdetails;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {

                    accountdetails= employeeContext.Account.FirstOrDefault(p=>p.Username==accountDetails.Username);
                if(accountdetails==null)
                {
                    return false;
                }
                    accountdetails.Password = accountDetails.Password;
                    employeeContext.Entry(accountdetails).State = EntityState.Modified;
                    employeeContext.SaveChanges();
                    return true;
             
            }
        }

    }
}


