using EmployeeEntity;
using ReviewShedulerBL;
using System.Web.Mvc;
using System.Collections.Generic;
using EmployeeRepositary;
using System.Linq;
using System;
using Employee_Project_Review_Scheduler.Models;
using System.Text;
using System.Web;

namespace Employee_Project_Review_Scheduler.Controllers
{
    //[HandleError]
    public class ReviewSchedulerController : Controller
    {
        Repositary repositary = new Repositary();
        EmployeeBL bl = new EmployeeBL();
        // GET: ReviewScheduler 
        [ActionName("Start")]
        public ViewResult Index()
        {
            //throw new Exception("This is unhandled exception");
            return View("Index");
        }
        //[NonAction]
        //public int EmployeeCount()
        //{
        //    return bl.Count();
        //}
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            if (ModelState.IsValid)
            {
                bool result = bl.CheckLogin(username, password);
                if (result == true)
                {
                    Response.Write("Login Successfully");
                    return View("Index");
                }
                else
                {
                    Response.Write("username or password is Invalid");
                    return RedirectToAction("Login");
                }
            }
            else
                return View("Index");
        }
        public ViewResult Display()
        {
            IEnumerable<EmployeeEntity.Employee> employees = Repositary.GetEmployee();
            ViewData["Employees"] = employees;
            return View();
        }
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();
            //StringBuilder sb = new StringBuilder();
            //sb.Append(HttpUtility.HtmlEncode(employeeViewModel.Firstname));
            //sb.Replace("&lt;b&gt;", "<b>");
            //sb.Replace("&lt;/b&gt;", "<b>");
            //sb.Replace("</b>", "</b>";)
            //employee.Description = sb.ToString();

            //string strDes = HttpUtility.HtmlEncode(employee.Description);
            //employee.Description = strDes;
            try
            {

                if (ModelState.IsValid)
                {
                    employee.Id = employeeViewModel.Id;
                    employee.Firstname = employeeViewModel.Firstname;
                    employee.Lastname = employeeViewModel.Lastname;
                    employee.EmailId = employeeViewModel.EmailId;
                    employee.Gender = employeeViewModel.Gender;
                    employee.Mobilenumber = employeeViewModel.Mobilenumber;
                    employee.DOB = employeeViewModel.DOB;
                    employee.DOJ = employeeViewModel.DOJ;
                    employee.Username = employeeViewModel.Username;
                    employee.Password = employeeViewModel.Password;
                    employee.ConformPassword = employeeViewModel.ConformPassword;
                    employee.Designation = (EmployeeEntity.Designation)employeeViewModel.Designation;
                    //bl.GetEmployees();
                    bl.Add(employee);
                    Response.Write("Added Successfully");
                    return RedirectToAction("Display");
                }
                return View();
            }
            catch (Exception e)
            {
                Response.Write(e.Message + e.StackTrace);
                return RedirectToAction("Index");
            }
            //return View();
        }
        public ActionResult Delete(int employee)
        {
            bl.GetEmployees();
            bl.Delete(employee);
            TempData["Message"] = "Employee is deleted successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            EmployeeEntity.Employee employee = bl.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(EmployeeEntity.Employee employee)
        {
            if (ModelState.IsValid)
            {
                repositary.Update(employee);
                TempData["Message"] = "Employee is Updated successfully";
                return RedirectToAction("Display");
            }
            return RedirectToAction("Index");
            //return View("Edit", employee);
        }
    }
}