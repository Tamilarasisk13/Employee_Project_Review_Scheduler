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
        IDepartmentBL departmentBL;
        IDesignationBL designationBL;
        public LoginController()
        {
            employeeBL = new EmployeeBL();
            departmentBL = new DepartmentBL();
            designationBL = new DesignationBL();
        }

        //Get method to login user
        public ViewResult Login()
        {
            return View();
        }

        //Post method to login user
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
                    return RedirectToAction("ViewProfile", "EmployeeDetails");
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

        //Get method to edit password
        public ActionResult EditPassword()
        {      
            return View();
        }

        //Post method to edit password
        [HttpPost]
        [AllowAnonymous]
        public ActionResult EditPassword(LoginViewModel loginViewModel,string ConformPassword)
        {
           if(loginViewModel.Password!=ConformPassword)
            {
                TempData["Message"] = "Password and Conform password must match";
                return RedirectToAction("DisplayMessages");
            }
            AccountDetails accountDetails = new AccountDetails();          
            accountDetails.Username = loginViewModel.Username;
            accountDetails.Password = loginViewModel.Password;
            bool flag=employeeBL.UpdatePassword(accountDetails);
            if(flag==true)
            return RedirectToAction("Login");
            TempData["Message"] = "Please enter valid username";
            return RedirectToAction("DisplayMessages");
        }

        //Method to display messages
        public ActionResult DisplayMessages()
        {
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