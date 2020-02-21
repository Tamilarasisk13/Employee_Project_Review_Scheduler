
using EmployeeEntity;
using EmployeeRepositary;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Employee_Project_Review_Scheduler.Controllers
{
    public class ReviewSchedulerController : Controller
    {
        Repositary repositary = new Repositary();
        // GET: ReviewScheduler 
       [ActionName("Start")]
        public ActionResult Index()
        {
            return View("Index");
        }
        [NonAction]
        public int EmployeeCount()
        {
            return repositary.Count();
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            //repositary.Add(employee);
            if (ModelState.IsValid)
            {
                bool result = repositary.CheckLogin(username,password);
                if (result == true)
                {
                    Response.Write("Login Successfully");
                    return View("Index");
               
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
                return View("Index");
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
            if (ModelState.IsValid)
            {
                repositary.Add(employee);
                Response.Write("Added Successfully");
                RedirectToAction("Display");
            }
            return View();
        }
    }
}