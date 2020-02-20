
using EmployeeEntity;
using UserEntity;
using EmployeeRepositary;
using System.Web.Mvc;

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
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddEmployee(Employee employee)
        {
            repositary.Add(employee);
            Response.Write("Added Successfully");
            return View();
        }
    }
}