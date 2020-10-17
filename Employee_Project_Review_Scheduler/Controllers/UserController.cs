using EmployeeEntity;
using ReviewSchedulerBL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler.Controllers
{
    [CustomExceptionFilter]  // Custom Exception filter
    [Authorize(Roles = "Admin,User,Scheduler")]
    public class UserController : Controller
    {
        IReviewDetailsBL reviewDetailsBL;

        public UserController()
        {
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

        //Method to display reviewer Schedule details
        public ActionResult DisplayReviewerDetails()
        {
            return View();
        }

        //Method to display reviewer and reviewee Schedule details
        public ActionResult DisplayBothDetails()
        {
            return View();
        }

        //Method to display reviewee Schedule details
        public ActionResult DisplayRevieweeDetails()
        {
            return View();
        }
    }
}



//@* @model Employee_Project_Review_Scheduler.Models.ReviewDetailsViewModel

//@{
//    ViewBag.Title = "Index";
//    Layout = "~/Views/Shared/_EmployeeMasterPage.cshtml";
//}

//<h2>Index</h2>

//<table border = "0" align="center" cellpadding="6" style="padding-top:30px;">

//    <tr>
//        <td style = "color:brown;font-size:20px;" > Id </ td >
//        < td style="color:brown;font-size:20px;">Reviewer Name</td>
//         <td style = "color:brown;font-size:20px;" > Reviewer Designation</td>
//         <td style = "color:brown;font-size:20px;" > Reviewer Department</td>
//         <td style = "color:brown;font-size:20px;" > Date </ td >
 
//     </ tr >
//     @foreach(EmployeeEntity.Review_Details employee in (IEnumerable<EmployeeEntity.Review_Details>)TempData["Ih"])
//     {
//        < tr >
//            < td style = "font-size:20px;" > @employee.Id </ td >
 
//             < td style = "font-size:20px;" > @employee.Reviewername </ td >
  
//              < td style = "font-size:20px;" > @employee.ReviewerDesignationId </ td >
   
//               < td style = "font-size:20px;" > @employee.ReviewerDepartmentId </ td >
    
//                < td style = "font-size:20px;" > @employee.Date </ td >
     
//             </ tr >
//     }
//</table>*@