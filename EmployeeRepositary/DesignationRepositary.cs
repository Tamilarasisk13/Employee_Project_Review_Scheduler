using EmployeeEntity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace EmployeeDAL
{
   public class DesignationRepositary : IDesignationRepositary
    {
        //Method to get employee Designations
        public IEnumerable<Designations> GetDesignations()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            return employeeContext.EmployeeDesignations.ToList();
        }

        //Method to add employee designation
        public bool AddDesignations(Designations designations)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                SqlParameter sql = new SqlParameter("@DesignationName", designations.DesignationName);
                int count = employeeContext.Database.ExecuteSqlCommand("Designations_Insert @DesignationName", sql);
                //employeeContext.Entry(designations).State = EntityState.Added;
                //employeeContext.SaveChanges();
            }
            return true;
        }

        //Method to delete employee designation
        public void DeleteDesignations(int designationId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                Designations designations = GetEmployeeById(designationId);
                SqlParameter sql = new SqlParameter("@DesignationId", designations.DesignationId);
                employeeContext.Database.ExecuteSqlCommand("Designations_Delete @DesignationId", sql);
                //employeeContext.Entry(designations).State = EntityState.Deleted;
                //employeeContext.SaveChanges();
            }
        }

        //Method to get employee by DesignationId
        public Designations GetEmployeeById(int designationId)
        {
            using (EmployeeContext employeeContext = new EmployeeContext())
            {
                return employeeContext.EmployeeDesignations.Find(designationId);
            }
        }
    }
}
