using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;

namespace ReviewSchedulerBL
{
   public interface IDesignationBL
    {
        bool AddDesignation(Designations designations);
        IEnumerable<Designations> GetDesignations();
        
        void DeleteDesignations(int designationId);
    }
}
