using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSchedulerBL
{
    public interface IReviewDetailsBL
    {
        // int AddReviewDetails(int reviewerDepartmentId, int reviewerDesignationId, int reviewerName, int revieweeDepartmentId, int revieweeDesignationId, int revieweeName,DateTime date);
        int Add(Review_Details reviewDetail);
        IEnumerable<Review_Details> DisplayReviewDetails();
        int CheckLogic(Review_Details reviewDetail);
        string GetName(int nameId);
        int GetEmployeeIdByAccountId(int accountId);
        Review_Details CheckExists(int employeeId);
        string GetDesignation(int Id);
        void Delete(int employeeId);
        Review_Details GetReviewDetailsById(int id);
        bool UpdateReview(Review_Details reviewDetail);
        string GetDepartment(int Id);
        int DisplayReviews(int Id);
        IEnumerable<Review_Details> DisplayReviewerReview(int Id);
        IEnumerable<Review_Details> DisplayRevieweeReview(int Id);
    }
}
