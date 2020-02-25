
using EmployeeEntity;
using EmployeeRepositary;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

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
                    Response.Write("username or password is Invalid");
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
        public ActionResult Delete(int id)
        {
            repositary.Delete(id);
            TempData["Message"] = "Employee is deleted successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Employee employee = repositary.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
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