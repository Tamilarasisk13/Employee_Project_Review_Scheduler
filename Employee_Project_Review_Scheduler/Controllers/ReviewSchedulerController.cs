using EmployeeEntity;
using ReviewShedulerBL;
using System.Web.Mvc;
using System.Collections.Generic;
using EmployeeRepositary;
using System.Linq;
using System;
using Employee_Project_Review_Scheduler.Models;
using System.Net;
using System.Data.Entity;

namespace Employee_Project_Review_Scheduler.Controllers
{
    [HandleError]
    public class ReviewSchedulerController : Controller
    {
        Repositary repositary = new Repositary();
        EmployeeBL employeeBL = new EmployeeBL();
        [ActionName("Start")]
        public ViewResult Index()
        {
            //throw new Exception("This is unhandled exception");
            return View("Index");
        }
        //[NonAction]
        //public int EmployeeCount()
        //{
        //    return bl.Count();
        //}
        
        //Add Method
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration = 10)]
        public ActionResult AddEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee employee = new Employee();
           
            try
            {

                if (ModelState.IsValid)
                {
                    employee.Id = employeeViewModel.Id;
                    employee.Firstname = employeeViewModel.Firstname;
                    employee.Lastname = employeeViewModel.Lastname;
                    employee.EmailId = employeeViewModel.EmailId;
                    employee.Gender = employeeViewModel.Gender;
                    employee.Mobilenumber = employeeViewModel.Mobilenumber;
                    employee.DOB = employeeViewModel.DOB;
                    employee.DOJ = employeeViewModel.DOJ;
                    employee.Username = employeeViewModel.Username;
                    employee.Password = employeeViewModel.Password;
                    employee.ConformPassword = employeeViewModel.ConformPassword;
                    employee.Designation = (EmployeeEntity.Designation)employeeViewModel.Designation;
                    //bl.GetEmployees();
                    employeeBL.Add(employee);
                    Response.Write("Added Successfully");
                    return RedirectToAction("Display");
                }
                return View();
            }
            catch (Exception e)
            {
                Response.Write(e.Message + e.StackTrace);
                return RedirectToAction("Index");
            }          
        }
        //Get values from database
        public ActionResult Display()
        {
            
            EmployeeContext context = new EmployeeContext();
            TempData["Employees"] = context.Employees.ToList();
            return View();            
        }   
        //Method to delete a row   
        public RedirectToRouteResult Delete(int id)
        {
            EmployeeContext context = new EmployeeContext();
            Employee employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Display");           
        }
        //Get Method to edit the data
        public ViewResult Edit(int id)
        {
            Employee employee = employeeBL.GetEmployeeById(id);
            return View(employee);

        }
        //Post Method to edit the data
        [HttpPost]
        public RedirectToRouteResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                repositary.Update(employee);
                TempData["Message"] = "Employee is Updated successfully";
                return RedirectToAction("Display");
            }
            return RedirectToAction("Index");
            //return View("Edit", employee);
        }
    }
}