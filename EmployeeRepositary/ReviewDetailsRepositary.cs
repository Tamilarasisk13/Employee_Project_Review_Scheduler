using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public class ReviewDetailsRepositary
    {
        public int CheckLogic(Review_Details reviewDetail)
        {
            int count = 0;
            IList<Review_Details> li = null;
            List<Review_Details> review = null;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                review = employeeContext.Review_Detail.ToList();

                li = review.FindAll(p => (p.Revieweename == reviewDetail.Reviewername && p.Date == reviewDetail.Date));
                if (li.Count != 0)
                {
                    count = -4;
                    return count;
                }
                li = review.FindAll(p => (p.Revieweename == reviewDetail.Revieweename && p.Date == reviewDetail.Date));
                if (li.Count != 0)
                {
                    count = -5;
                    return count;
                }
                li = review.FindAll(p => (p.Reviewername == reviewDetail.Revieweename && p.Date == reviewDetail.Date));
                if (li.Count != 0)
                {
                    count = -5;
                    return count;
                }
                return count;
            }
        }
        public int Add(Review_Details reviewDetail)
        {
            int count = 0;
            IList<Review_Details> li = null;
            List<Review_Details> review = null;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                review = employeeContext.Review_Detail.ToList();            
              
                li = review.FindAll(p => (p.Revieweename == reviewDetail.Reviewername && p.Date == reviewDetail.Date));
                if (li.Count != 0)
                {
                    count = -4;
                    return count;
                }
                li = review.FindAll(p => (p.Revieweename == reviewDetail.Revieweename && p.Date == reviewDetail.Date));
                if (li.Count != 0)
                {
                    count = -5;
                    return count;
                }
                li = review.FindAll(p => (p.Reviewername == reviewDetail.Revieweename && p.Date == reviewDetail.Date));
                if (li.Count != 0)
                {
                    count = -5;
                    return count;
                }
                employeeContext.Entry(reviewDetail).State = EntityState.Added;
                count = employeeContext.SaveChanges();
                return count;
            }
        }
        public void Delete(int employeeId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Review_Details reviewDetail = GetReviewDetailsById(employeeId);

                employeeContext.Entry(reviewDetail).State = EntityState.Deleted;
                employeeContext.SaveChanges();
                //SqlParameter sqlEmployee = new SqlParameter("@Id", employee.Id);
                //employeeContext.Database.ExecuteSqlCommand("Employee_Delete @Id", sqlEmployee);
                //SqlParameter sqlAccount = new SqlParameter("@AccountId", accountdetails.AccountId);
                //employeeContext.Database.ExecuteSqlCommand("AccountDetails_Delete @AccountId", sqlAccount);
            }
        }
        public Review_Details GetReviewDetailsById(int employeeId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.Review_Detail.Find(employeeId);
            }
        }

        public bool UpdateReview(Review_Details reviewDetail)
        {

            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                employeeContext.Entry(reviewDetail).State = EntityState.Modified;
                employeeContext.SaveChanges();
                return true;
            }

        }
        public IEnumerable<Review_Details> DisplayReviewDetails()
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {               
                return employeeContext.Review_Detail.Include("Employee").Include("Designation").Include("Department").ToList();
            }
        }
        public string GetName(int nameId)
        {

            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Employee employee = employeeContext.Employees.Find(nameId);
                return employee.Firstname;
            }
        }
        public string GetDesignation(int Id)
        {

            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Designations designations = employeeContext.EmployeeDesignations.Find(Id);
                return designations.DesignationName;
            }
        }

        public string GetDepartment(int Id)
        {

            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Departments department = employeeContext.EmployeeDepartments.Find(Id);
                return department.DepartmentName;
            }
        }

        public int GetEmployeeIdByAccountId(int accountId)
        {

            Employee employee;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                employee = employeeContext.Employees.FirstOrDefault(p => p.AccountId == accountId);
                return employee.Id;
            }
        }
        public Review_Details CheckExists(int employeeId)
        {
            Review_Details reviewDetail;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {

                return reviewDetail = employeeContext.Review_Detail.FirstOrDefault(p => p.Reviewername == employeeId.ToString() || p.Revieweename == employeeId.ToString());
            }

        }
        public IEnumerable<Review_Details> DisplayRevieweeReview(int userId)
        {
            IEnumerable<Review_Details> reviewdetail = null;
            List<Review_Details> review = null;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                review = employeeContext.Review_Detail.ToList();
                reviewdetail = review.FindAll(p => p.Reviewername == userId.ToString());
                return reviewdetail;

            }
        }
        public IEnumerable<Review_Details> DisplayReviewerReview(int userId)
        {
            IEnumerable<Review_Details> reviewdetail = null;
            List<Review_Details> review = null;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                review = employeeContext.Review_Detail.ToList();
                reviewdetail = review.FindAll(p => p.Revieweename == userId.ToString());
                return reviewdetail;

            }
        }
        public int DisplayReviews(int userId)
        {
            List<Review_Details> reviewerdetail = null;
            List<Review_Details> revieweeDetail = null;
            List<Review_Details> review = null;
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                review = employeeContext.Review_Detail.ToList();
                reviewerdetail = review.FindAll(p => p.Reviewername == userId.ToString());
                revieweeDetail = review.FindAll(p => p.Revieweename == userId.ToString());
                if (revieweeDetail.Count != 0 && reviewerdetail.Count != 0)
                    return 0;
                else if (reviewerdetail.Count == 0)
                    return 10;
                else
                    return 5;
            }
        }
    }
}
