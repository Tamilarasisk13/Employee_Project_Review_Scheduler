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
    [Authorize(Roles = "Scheduler, User")]
    public class ReviewScheduleController : Controller
    {
       IEmployeeBL employeeBL;
        IDepartmentBL departmentBL;
        IDesignationBL designationBL;
        IReviewDetailsBL reviewDetailsBL;
        public ReviewScheduleController()
        {
            employeeBL = new EmployeeBL();
            departmentBL = new DepartmentBL();
            designationBL = new DesignationBL();
            reviewDetailsBL = new ReviewDetailsBL();
        }

        //Get Method to schedule the review for employees
        [HttpGet]
        public ActionResult ScheduleReview()
        {
            List<SelectListItem> reviewerDepartments = new List<SelectListItem>();
            ReviewDetailsViewModel reviewDetailsViewModel = new ReviewDetailsViewModel();

            List<Departments> states = departmentBL.GetDepartments();
            states.ForEach(x =>
            {
                reviewerDepartments.Add(new SelectListItem { Text = x.DepartmentName, Value = x.DepartmentId.ToString() });
            });
            reviewDetailsViewModel.Departments = reviewerDepartments;
            return View(reviewDetailsViewModel);
        }


        //Post Method to schedule the review for employees
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            if (ModelState.IsValid)
            {
                int revieweeDesignationId = Convert.ToInt32(form["RevieweeDesignationId"]);
                int reviewerDepartmentId = Convert.ToInt32(form["ReviewerDepartmentId"]);
                int revieweeDepartmentId = Convert.ToInt32(form["RevieweeDepartmentId"]);
                string reviewerName = (form["ReviewerName"]).ToString();
                int reviewerDesignationId = Convert.ToInt32(form["ReviewerDesignationId"]);
                string revieweeName = (form["RevieweeName"]).ToString();
                DateTime date = Convert.ToDateTime(form["Date"]);


                Review_Details reviewDetail = new Review_Details();
                reviewDetail.Reviewername = reviewerName;
                reviewDetail.Revieweename = revieweeName;
                reviewDetail.ReviewerDesignationId = reviewerDesignationId;
                reviewDetail.ReviewerDepartmentId = reviewerDepartmentId;
                reviewDetail.RevieweeDesignationId = revieweeDesignationId;
                reviewDetail.RevieweeDepartmentId = revieweeDepartmentId;
                reviewDetail.Date = date;

                if (reviewerName == revieweeName)
                {
                    TempData["Message"] = "Reviewer and Reviewee should not be same";
                    return RedirectToAction("DisplayMessages");
                }
                int count = reviewDetailsBL.Add(reviewDetail);
                if (count == -5)
                {
                    TempData["Message"] = "Already a review is scheduled on that day for reviewee";
                    return RedirectToAction("DisplayMessages");
                }
                else if (count == -4)
                {
                    TempData["Message"] = "Already a review is scheduled on that day for reviewer";
                    return RedirectToAction("DisplayMessages");
                }

                else if (count != 0)
                    return RedirectToAction("DisplayReviewDetails", reviewDetail);
            }
            return RedirectToAction("ScheduleReview");

        }

        //Method to display review details
        [Authorize(Roles = "Scheduler")]
        public ActionResult DisplayReviewDetails()
        {
            TempData["Employees"] = reviewDetailsBL.DisplayReviewDetails();
            return View();
        }

        //Method to delete review details data
        [Authorize(Roles = "Scheduler")]
        public ActionResult Delete(int id)
        {
            reviewDetailsBL.Delete(id);
            return RedirectToAction("DisplayReviewDetails");
        }

        //Get Method to edit review details data
        [Authorize(Roles = "Scheduler")]
        public ActionResult Edit(int id)
        {
            Review_Details reviewDetail = reviewDetailsBL.GetReviewDetailsById(id);
            //ViewBag.Departments = new SelectList(departmentBL.GetDepartments(), "DepartmentID", "DepartmentName");
            //ViewBag.Designation = new SelectList(designationBL.GetDesignations(), "DesignationID", "DesignationName");
            List<SelectListItem> reviewerDepartments = new List<SelectListItem>();
            ReviewDetailsViewModel reviewDetailsViewModel = new ReviewDetailsViewModel();

            List<Departments> states = departmentBL.GetDepartments();
            states.ForEach(x =>
            {
                reviewerDepartments.Add(new SelectListItem { Text = x.DepartmentName, Value = x.DepartmentId.ToString() });
            });
            ViewBag.Departments = new SelectList(departmentBL.GetDepartments(), "DepartmentID", "DepartmentName");
            reviewDetailsViewModel.Departments = reviewerDepartments;
            ReviewDetailsViewModel employeeViewModel = new ReviewDetailsViewModel();
            // employeeViewModel = AutoMapper.Mapper.Map<ReviewDetail, ReviewDetailsViewModel>(reviewDetail);
            employeeViewModel.Id = reviewDetail.Id;
            employeeViewModel.Reviewername = reviewDetail.Reviewername;
            employeeViewModel.ReviewerDesignationId = reviewDetail.ReviewerDesignationId;
            employeeViewModel.ReviewerDepartmentId = reviewDetail.ReviewerDepartmentId;
            employeeViewModel.Revieweename = reviewDetail.Revieweename;
            employeeViewModel.RevieweeDesignationId = reviewDetail.RevieweeDesignationId;
            employeeViewModel.RevieweeDepartmentId = reviewDetail.RevieweeDepartmentId;
            employeeViewModel.Date = reviewDetail.Date;
            return View(employeeViewModel);
        }

        //Post Method to edit review details data
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Scheduler")]
        public RedirectToRouteResult Update(Review_Details reviewDetail)
        {
            if (reviewDetail.Reviewername == reviewDetail.Revieweename)
            {
                TempData["Message"] = "Reviewer and Reviewee should not be same";
                return RedirectToAction("DisplayMessages");
            }
            int count = reviewDetailsBL.CheckLogic(reviewDetail);
            if (count == -5)
            {
                TempData["Message"] = "Already a review is scheduled on that day for reviewee";
                return RedirectToAction("DisplayMessages");
            }
            else if (count == -4)
            {
                TempData["Message"] = "Already a review is scheduled on that day for reviewer";
                return RedirectToAction("DisplayMessages");
            }
            else if (count == 0)
            reviewDetailsBL.UpdateReview(reviewDetail);
            return RedirectToAction("DisplayReviewDetails");
        }

        //Method to display no schedule message
        public ActionResult NoSchedule()
        {
            return View();
        }

        //Method to get Reviewer Designation
        [HttpPost]
        public ActionResult GetReviewerDesignation(string reviewerDepartmentId)
        {
            Employee employee = new Employee();
            int reviewerdepartmentId;
            List<SelectListItem> reviewerDesignations = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(reviewerDepartmentId))
            {
                reviewerdepartmentId = Convert.ToInt32(reviewerDepartmentId);
                List<Employee> employees = employeeBL.GetEmployees();
                List<Employee> designationName = employees.Where(x => x.DepartmentId == reviewerdepartmentId).ToList();

                designationName.ForEach(x =>
            {
                int designationId = x.DesignationId;
                Designations desig = designationBL.GetDesignationByDesignationId(designationId);
                reviewerDesignations.Add(new SelectListItem { Text = desig.DesignationName, Value = x.DesignationId.ToString() });
            });
            }
            return Json(reviewerDesignations, JsonRequestBehavior.AllowGet);
        }

        //Method to get Reviewer Names
        [HttpPost]
        public ActionResult GetReviewerNames(string reviewerDepartmentId, string reviewerDesignationId)
        {
            int reviewerdepartmentId, reviewerdesignationId;
            List<SelectListItem> reviewerNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(reviewerDesignationId))
            {
                reviewerdepartmentId = Convert.ToInt32(reviewerDepartmentId);
                reviewerdesignationId = Convert.ToInt32(reviewerDesignationId);
                List<Employee> employees = employeeBL.GetEmployees();
                List<Employee> employee = employees.Where(x => x.DesignationId == reviewerdesignationId && x.DepartmentId == reviewerdepartmentId).ToList();

                employee.ForEach(x =>
                {
                    reviewerNames.Add(new SelectListItem { Text = x.Firstname, Value = x.Id.ToString() });
                });
            }
            return Json(reviewerNames, JsonRequestBehavior.AllowGet);
        }

        //Method to get Reviewee Designation
        [HttpPost]
        public ActionResult GetRevieweeDesignation(string revieweeDepartmentId)
        {
            Employee employee = new Employee();
            int revieweedepartmentId;
            List<SelectListItem> revieweeDesignations = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(revieweeDepartmentId))
            {
                revieweedepartmentId = Convert.ToInt32(revieweeDepartmentId);
                List<Employee> employees = employeeBL.GetEmployees();
                List<Employee> designationName = employees.Where(x => x.DepartmentId == revieweedepartmentId).ToList();

                designationName.ForEach(x =>
                {
                    int designationId = x.DesignationId;
                    Designations desig = designationBL.GetDesignationByDesignationId(designationId);
                    revieweeDesignations.Add(new SelectListItem { Text = desig.DesignationName, Value = x.DesignationId.ToString() });
                });
            }
            return Json(revieweeDesignations, JsonRequestBehavior.AllowGet);
        }

        //Method to get Reviewee Names
        [HttpPost]
        public ActionResult GetRevieweeNames(string revieweeDepartmentId, string revieweeDesignationId)
        {
            int revieweedepartmentId, revieweedesignationId;
            List<SelectListItem> revieweeNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(revieweeDesignationId))
            {
                revieweedepartmentId = Convert.ToInt32(revieweeDepartmentId);
                revieweedesignationId = Convert.ToInt32(revieweeDesignationId);
                List<Employee> employees = employeeBL.GetEmployees();
                List<Employee> employee = employees.Where(x => x.DesignationId == revieweedesignationId && x.DepartmentId == revieweedepartmentId).ToList();
                employee.ForEach(x =>
                {
                    revieweeNames.Add(new SelectListItem { Text = x.Firstname, Value = x.Id.ToString() });
                });
            }
            return Json(revieweeNames, JsonRequestBehavior.AllowGet);
        }

        //Method to display warning messages
        public ActionResult DisplayMessages()
        {
            return View();
        }
    }
}



