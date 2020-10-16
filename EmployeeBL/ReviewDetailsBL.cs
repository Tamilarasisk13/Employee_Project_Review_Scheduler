
using EmployeeDAL;
using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewSchedulerBL
{
    public class ReviewDetailsBL : IReviewDetailsBL
    {

        ReviewDetailsRepositary reviewDetailsRepositary = new ReviewDetailsRepositary();
        //public int AddReviewDetails(int reviewerDepartmentId,int reviewerDesignationId, int reviewerName,int revieweeDepartmentId,int revieweeDesignationId, int revieweeName,DateTime date)
        //{
        //    return reviewDetailsRepositary.AddReviewDetails(reviewerDepartmentId, reviewerDesignationId, reviewerName, revieweeDepartmentId, revieweeDesignationId, revieweeName,date);
        //}

        public int Add(Review_Details reviewDetail)
        {
            return reviewDetailsRepositary.Add(reviewDetail);
        }
        public int CheckLogic(Review_Details reviewDetail)
        {
            return reviewDetailsRepositary.CheckLogic(reviewDetail);
        }
        //Method to delete revire details
        public void Delete(int employeeId)
        {
            reviewDetailsRepositary.Delete(employeeId);
        }
        public bool UpdateReview(Review_Details reviewDetail)
        {
            return reviewDetailsRepositary.UpdateReview(reviewDetail);
        }
        public Review_Details GetReviewDetailsById(int id)
        {
            return reviewDetailsRepositary.GetReviewDetailsById(id);
        }
        public IEnumerable<Review_Details> DisplayReviewDetails( )
        {
            return reviewDetailsRepositary.DisplayReviewDetails();
        }
        public string GetName(int nameId)
        {
            return reviewDetailsRepositary.GetName(nameId);
        }
        public string GetDesignation(int Id)
        {
            return reviewDetailsRepositary.GetDesignation(Id);
        }
        public string GetDepartment(int Id)
        {
            return reviewDetailsRepositary.GetDepartment(Id);
        }

        public int GetEmployeeIdByAccountId(int accountId)
        {
            return reviewDetailsRepositary.GetEmployeeIdByAccountId(accountId);
        }
        public Review_Details CheckExists(int employeeId)
        {
            return reviewDetailsRepositary.CheckExists(employeeId);
        }
        public IEnumerable<Review_Details> DisplayRevieweeReview(int Id)
        {
            return reviewDetailsRepositary.DisplayRevieweeReview(Id);
        }
        public IEnumerable<Review_Details> DisplayReviewerReview(int Id)
        {
            return reviewDetailsRepositary.DisplayReviewerReview(Id);
        }
        public int DisplayReviews(int Id)
        {
            return reviewDetailsRepositary.DisplayReviews(Id);
        }
    }
}
