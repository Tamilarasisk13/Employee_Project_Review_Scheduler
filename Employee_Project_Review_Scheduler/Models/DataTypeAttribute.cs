using System;
using System.ComponentModel.DataAnnotations;

namespace Employee_Project_Review_Scheduler.Models
{
    internal class DataTypeAttribute : Attribute
    {
        private DataType date;

        public DataTypeAttribute(DataType date)
        {
            this.date = date;
        }
    }
}