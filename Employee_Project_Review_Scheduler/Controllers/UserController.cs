using Employee_Project_Review_Scheduler.Models;
using EmployeeEntity;
using ReviewSchedulerBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    
    [CustomExceptionFilter]  // Custom Exception filter
    [Authorize(Roles = "Admin,User,Scheduler")]
    public class UserController : Controller
    {
        IEmployeeBL employeeBL;
        IDepartmentBL departmentBL;
        IDesignationBL designationBL;
        IReviewDetailsBL reviewDetailsBL;

        public UserController()
        {
            employeeBL = new EmployeeBL();
            departmentBL = new DepartmentBL();
            designationBL = new DesignationBL();
           reviewDetailsBL = new ReviewDetailsBL();
        }


        public ActionResult Index()
        {
            int UserAccountId = 0;
            int employeeId = 0;
            Review_Details reviewDetail;
            if (Session["AccountId"] != null)
            {
                UserAccountId = (int)Session["AccountId"];
                employeeId = reviewDetailsBL.GetEmployeeIdByAccountId(UserAccountId);
                reviewDetail = reviewDetailsBL.CheckExists(employeeId);
                List<Review_Details> review = reviewDetailsBL.DisplayReviewDetails().ToList();

                if (reviewDetail == null)
            {
                return RedirectToAction("NoSchedule", "ReviewSchedule");
            }
            else
            {
                //if (employeeId.ToString() == reviewDetail.Revieweename && employeeId.ToString() == reviewDetail.Reviewername)
                //{
                //    //TempData["Ih"] = reviewDetailsBL.DisplayReview(employeeId);                     
                //    return RedirectToAction("DisplayReviewerDetails");
                //}
                //else
                //{
                //   // TempData["Ih"] = reviewDetailsBL.DisplayReview(employeeId);
                //    return RedirectToAction("DisplayRevieweeDetails");
                //}

                int count = 0;
                count = reviewDetailsBL.DisplayReviews(employeeId);
                if (count == 10)
                {
                    TempData["Ih"] = reviewDetailsBL.DisplayReviewerReview(employeeId);
                    return RedirectToAction("DisplayReviewerDetails");
                }
                else if (count == 5)
                {
                    TempData["Ih"] = reviewDetailsBL.DisplayRevieweeReview(employeeId);
                    return RedirectToAction("DisplayRevieweeDetails");
                }
                else
                {
                    TempData["Ih"] = reviewDetailsBL.DisplayRevieweeReview(employeeId);
                    TempData["Id"] = reviewDetailsBL.DisplayReviewerReview(employeeId);
                    return RedirectToAction("DisplayBothDetails");

                    }


            }
        }
            return View();
    }
    public ActionResult DisplayReviewerDetails()
    {
        return View();
    }
    public ActionResult DisplayBothDetails()
    {
        return View();
    }
    public ActionResult DisplayRevieweeDetails()
    {
        return View();
    }
}
}