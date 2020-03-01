using Employee_Project_Review_Scheduler.Models;
using EmployeeEntity;
using ReviewShedulerBL;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    public class LoginController : Controller
    {
        EmployeeBL employeeBL = new EmployeeBL();
        public ViewResult LoginAction()    //Get method to check login
        {
            return View();
        }
        [HttpPost]    //Post method to get login
        public ActionResult LoginAction(LoginViewModel loginViewModel)
        {
            LoginUser loginUser = new LoginUser();
            if (ModelState.IsValid)
            {
                
                loginUser.Username = loginViewModel.Username;
                loginUser.Password = loginViewModel.Password;
                string result = employeeBL.CheckLogin(loginUser);
                if (result == "Admin")
                {
                    return RedirectToAction("Display","ReviewScheduler");
                }
                else if (result == "Scheduler")
                {
                    return RedirectToAction("Start", "ReviewScheduler");
                }
                else if (result == "Reviewer")
                {
                    return RedirectToAction("Start", "ReviewScheduler");
                }
                else if (result == "Reviewee")
                {
                    return RedirectToAction("Start", "ReviewScheduler");
                }
                else
                {
                    Response.Write("Username or password is Invalid");
                    return View();
                }
            }
            else
                return View("Start", "ReviewScheduler");
        }
    }
}