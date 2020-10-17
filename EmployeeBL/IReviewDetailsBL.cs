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
        
        int Add(Review_Details reviewDetail);
        IEnumerable<Review_Details> DisplayReviewDetails();
        int CheckLogic(Review_Details reviewDetail);      
        Review_Details CheckExists(int employeeId);   
        void Delete(int employeeId);
        Review_Details GetReviewDetailsById(int id);
        bool UpdateReview(Review_Details reviewDetail);
        int DisplayReviews(int Id);
        IEnumerable<Review_Details> DisplayReviewerReview(int Id);
        IEnumerable<Review_Details> DisplayRevieweeReview(int Id);
        // string GetName(int nameId);
        // int GetEmployeeIdByAccountId(int accountId);
        //  string GetDesignation(int Id);
        // string GetDepartment(int Id);
    }
}
