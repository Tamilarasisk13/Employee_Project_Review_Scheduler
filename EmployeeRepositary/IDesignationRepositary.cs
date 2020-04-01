using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
   public interface IDesignationRepositary
    {
        
        IEnumerable<Designations> GetDesignations();
        bool AddDesignations(Designations designations);
        void DeleteDesignations(int designationId);
        Designations GetEmployeeById(int designationId);
    }
}
