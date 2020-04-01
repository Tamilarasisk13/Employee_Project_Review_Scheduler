using Employee_Project_Review_Scheduler.Models;
using EmployeeEntity;
using ReviewSchedulerBL;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    
    [CustomExceptionFilter]  // Custom Exception filter
    public class DesignationController : Controller
    {
        IDesignationBL designationBL;
        public DesignationController()
        {
            designationBL = new DesignationBL();
        }
        public ActionResult Index()
        {
            return View();
        }
        //Get Method to add the departments
        public ViewResult AddDesignations()
        {
            return View();
        }

        //Post method to add the department
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddDesignations(DesignationViewModel designationViewModel)
        {
            Designations designations = new Designations();

            if (ModelState.IsValid)
            {
                designations.DesignationName = designationViewModel.DesignationName;
                designationBL.AddDesignation(designations);
                return RedirectToAction("DisplayDesignations");
            }
            else
                return View();
        }


        //Method to delete designation
        [Authorize(Roles = "Admin")]
        public ViewResult DeleteDesignations(int id)
        {
            designationBL.DeleteDesignations(id);
            TempData["Designations"] = designationBL.GetDesignations();
            return View("DisplayDesignations");
        }

        //Method to display designation
        [Authorize(Roles = "Admin")]
        public ActionResult DisplayDesignations()
        {
            TempData["Designations"] = designationBL.GetDesignations();
            return View();
        }
    }
}