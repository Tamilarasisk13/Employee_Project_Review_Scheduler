using EmployeeDAL;
using EmployeeEntity;
using System;
using System.Collections.Generic;

namespace ReviewSchedulerBL
{
    public class DesignationBL : IDesignationBL
    {
        IDesignationRepositary designationRepositary;
        public DesignationBL()
        {
            designationRepositary = new DesignationRepositary();
        }
        //Method to add designation
        public bool AddDesignation(Designations designations)
        {
            return designationRepositary.AddDesignations(designations);
        }

        //Method to get designation
        public IEnumerable<Designations> GetDesignations()
        {
            return designationRepositary.GetDesignations();
        }

        //Method to delete designation
        public void DeleteDesignations(int designationId)
        {
            designationRepositary.DeleteDesignations(designationId);
        }
    }
}
