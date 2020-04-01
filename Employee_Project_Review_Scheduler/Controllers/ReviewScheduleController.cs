
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    
    [CustomExceptionFilter]  // Custom Exception filter
    public class ReviewScheduleController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        //Method to schedule the review
        public ViewResult ScheduleReview()
        {

            return View();
        }
    }
}