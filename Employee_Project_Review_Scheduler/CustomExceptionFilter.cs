using EmployeeDAL;
using System;
using EmployeeEntity;
using System.Web.Mvc;

namespace Employee_Project_Review_Scheduler
{

    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            ExceptionLogger logger = new ExceptionLogger()
            {
                ExceptionMessage = filterContext.Exception.Message,
                ExceptionStackTrack = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ExceptionLogTime = DateTime.Now
            };
            EmployeeContext dbContext = new EmployeeContext();
            dbContext.ExceptionLoggers.Add(logger);
            dbContext.SaveChanges();

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };

        }
    }
}