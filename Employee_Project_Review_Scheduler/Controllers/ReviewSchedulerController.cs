
using EmployeeEntity;
using UserEntity;
using EmployeeRepositary;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Employee_Project_Review_Scheduler.Controllers
{
    public class ReviewSchedulerController : Controller
    {
        Repositary repositary = new Repositary();
        // GET: ReviewScheduler
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginUser loginUser)
        {
            //repositary.Add(employee);
            bool result = repositary.CheckLogin(loginUser);
            if (result == true)
            {
                Response.Write("Login Successfully");
                return RedirectToAction("Index");
            }
                
            else
            {
               // Response.Write("Username or password is incorrect");
                return View();
            }           
        }
        public ActionResult Display()
        {
            IEnumerable<Employee> employees = Repositary.GetEmployee();
            ViewData["Employees"] = employees;
            return View();
        }
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            repositary.Add(employee);
            Response.Write("Added Successfully");
            return RedirectToAction("Display") ;
        }
    }
}