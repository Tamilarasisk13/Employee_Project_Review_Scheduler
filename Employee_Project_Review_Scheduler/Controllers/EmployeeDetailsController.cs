using Employee_Project_Review_Scheduler.Models;
using EmployeeEntity;
using ReviewSchedulerBL;
using System;
using System.Web.Mvc;


namespace Employee_Project_Review_Scheduler.Controllers
{
    
    //[CustomExceptionFilter]  // Custom Exception filter
    public class EmployeeDetailsController : Controller
    {
        IEmployeeBL employeeBL;
        IDepartmentBL departmentBL;
        IDesignationBL designationBL;
        public EmployeeDetailsController()
        {
            employeeBL = new EmployeeBL();
            departmentBL = new DepartmentBL();
            designationBL = new DesignationBL();
        }
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            //throw new Exception("This is unhandled exception");
            return View();
        }

        //Get method to add employee details
        public ViewResult AddEmployee()
        {
            ViewBag.Departments = new SelectList(departmentBL.GetDepartments(), "DepartmentID", "DepartmentName");
            ViewBag.Designation = new SelectList(designationBL.GetDesignations(), "DesignationID", "DesignationName");
            return View();
        }

        //Post method to add employee details
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 10)]
        public ActionResult AddEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();
                if (ModelState.IsValid)
                {
                    bool existsResult = employeeBL.CheckExists(employeeViewModel.EmailId, employeeViewModel.Mobilenumber);
                    if (existsResult == true)
                    {
                        AccountDetails accountDetails = new AccountDetails();
                        accountDetails.Username = employeeViewModel.EmailId;
                        //accountDetails.Id = id;
                        accountDetails.Password = employeeBL.GeneratePassword(employeeViewModel.EmailId, employeeViewModel.Mobilenumber.ToString());
                        accountDetails.Role = "User";
                        AccountDetails account = employeeBL.AddAccountDetails(accountDetails);
                        Employee employees = AutoMapper.Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                        employees.AccountId = account.AccountId;
                        Employee employeeDetails = employeeBL.Add(employees);
                        return RedirectToAction("DisplayEmployeeDetails");
                    }
                    else
                    {
                        Response.Write("Employee is alreay exists");                       
                    }
                }
                ViewBag.Departments = new SelectList(departmentBL.GetDepartments(), "DepartmentID", "DepartmentName");
                ViewBag.Designation = new SelectList(designationBL.GetDesignations(), "DesignationID", "DesignationName");
                return View();
            }

     
        //Method to display employee details
        [Authorize(Roles = "Admin")]
        public ActionResult DisplayEmployeeDetails()
        {
            TempData["Employees"] = employeeBL.DisplayEmployeeDetails();
            return View();
        }

        //public ActionResult DisplayEmployeeDetails()
        //{
        //    List<Employee> employees = employeeBL.DisplayEmployeeDetails();
        //    EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        //    employeeViewModel = AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employees);
        //    return View(employeeViewModel);
        //}



        [Authorize(Roles = "Admin,User,Scheduler")]
        public ActionResult UpdateProfile()
        {
            int UserAccountId = 0;
            if (Session["AccountId"] != null)
            {
                UserAccountId = (int)Session["AccountId"];
            }
            Employee employeeDetails = employeeBL.GetEmployeeByAccountId(UserAccountId);
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel = AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employeeDetails);
            return View(employeeViewModel);
        }

        [Authorize(Roles = "Admin,User,Scheduler")]
        public ActionResult UpdateMyProfile(int id)
        {
            Employee employee = employeeBL.GetEmployeeById(id);
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel = AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult UpdateMyProfile(Employee employee)
        {
            employeeBL.UpdateEmployee(employee);
            return RedirectToAction("UpdateProfile");
        }
        //Method to display account details
        [Authorize(Roles = "Admin")]
        public ActionResult DisplayAccountDetails()
        {
            TempData["Accounts"] = employeeBL.DisplayAccountDetails();
            return View();
        }

        //Method to delete employee data
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            employeeBL.Delete(id);
            return RedirectToAction("DisplayEmployeeDetails");
        }

        //Get Method to edit the employee data
        public ViewResult Edit(int id)
        {
            Employee employee = employeeBL.GetEmployeeById(id);
            ViewBag.Departments = new SelectList(departmentBL.GetDepartments(), "DepartmentID", "DepartmentName");
            ViewBag.Designation = new SelectList(designationBL.GetDesignations(), "DesignationID", "DesignationName");
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel = AutoMapper.Mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(employeeViewModel);
        }

        //Post Method to edit the employee data
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public RedirectToRouteResult Update(Employee employee)
        {
            employeeBL.UpdateEmployee(employee);
            return RedirectToAction("DisplayEmployeeDetails");
        }

    }
}
