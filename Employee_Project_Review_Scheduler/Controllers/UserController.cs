using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    
    [CustomExceptionFilter]  // Custom Exception filter
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}