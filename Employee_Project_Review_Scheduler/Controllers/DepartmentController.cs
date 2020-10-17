using Employee_Project_Review_Scheduler.Models;
using EmployeeEntity;
using ReviewSchedulerBL;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    
    [CustomExceptionFilter]  // Custom Exception filter
    public class DepartmentController : Controller
    {
        IDepartmentBL departmentBL;

        public DepartmentController()
        {
            departmentBL = new DepartmentBL();
        }

        //Get Method to add the department
        public ViewResult AddDepartments()
        {
            return View();
        }

        //Post method to add the department
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddDepartments(DepartmentViewModel departmentViewModel)
        {
            Departments departments = new Departments();

            if (ModelState.IsValid)
            {
                departments.DepartmentName = departmentViewModel.DepartmentName;
                departmentBL.AddDepartment(departments);
                return RedirectToAction("DisplayDepartments");
            }
            else
                return View();
        }


        //Method to delete Departments
        [Authorize(Roles = "Admin")]
        public ViewResult DeleteDepartments(int id)
        {
            departmentBL.DeleteDepartments(id);
            TempData["Departments"] = departmentBL.GetDepartments();
            return View("DisplayDepartments");
        }

        //Method to display Departments
        [Authorize(Roles = "Admin")]
        public ActionResult DisplayDepartments()
        {
            TempData["Departments"] = departmentBL.GetDepartments();
            return View();
        }
    }
}