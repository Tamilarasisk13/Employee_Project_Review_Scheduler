using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public interface IReviewDetailsRepositary
    {
        // int AddReviewDetails(int reviewerDepartmentId, int reviewerDesignationId, int reviewerName, int revieweeDepartmentId, int revieweeDesignationId, int revieweeName,DateTime date);
        int Add(Review_Details reviewDetail);
        IEnumerable<Review_Details> DisplayEmployeeDetails();
        string GetName(int nameId);
        int GetEmployeeIdByAccountId(int accountId);
        Review_Details CheckExists(int employeeId);
         int CheckLogic(Review_Details reviewDetail);
        void Delete(int employeeId);
        bool UpdateReview(Review_Details reviewDetail);
        // IQueryable<ReviewDetail> DisplayReview(int Id);
        string GetDesignation(int Id);
        string GetDepartment(int Id);
        int DisplayReviews(int Id);
        IEnumerable<Review_Details> DisplayReviewerReview(int userId);
        IEnumerable<Review_Details> DisplayRevieweeReview(int userId);
    }
}
