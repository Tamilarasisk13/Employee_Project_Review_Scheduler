using Employee_Project_Review_Scheduler.Models;
using EmployeeEntity;
using ReviewSchedulerBL;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Employee_Project_Review_Scheduler.Controllers
{
    
    [CustomExceptionFilter]  // Custom Exception filter
    public class LoginController : Controller
    {
        EmployeeBL employeeBL;
        public LoginController()
        {
            employeeBL = new EmployeeBL();
        }

        //Get method to login user
        public ViewResult Login()
        {
            return View();
        }

        //Get method to login user
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            AccountDetails accountDetails = new AccountDetails();
            if (ModelState.IsValid)
            {
                accountDetails.Username = loginViewModel.Username;
                accountDetails.Password = loginViewModel.Password;
                AccountDetails account = employeeBL.CheckLogin(accountDetails);
                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.Username, false);
                    var authticket = new FormsAuthenticationTicket(1, account.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, account.Role);
                    string encryptedticket = FormsAuthentication.Encrypt(authticket);
                    var authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedticket);
                    HttpContext.Response.Cookies.Add(authcookie);
                    Session["AccountId"] = account.AccountId;
                    //Employee employeeDetails = employeeBL.GetEmployeeByAccountId(account.AccountId);
                    //TempData["Employee"] = employeeDetails;
                    return RedirectToAction("ViewMyProfile", "EmployeeDetails");
                }

                else
                {
                    //ModelState.AddModelError("", "invalid login attempt.");
                    Response.Write("Username or password is Invalid");
                    return View();
                }



            }
            return View();
        }

        //Logout method
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "EmployeeDetails");
        }
    }
}