using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Project_Review_Scheduler.Models
{
    public class MapConfig
    {
        public static void Mapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<LoginViewModel, AccountDetails>().ForMember(dest=>dest.Role,opt=>opt.MapFrom(src=>"Admin"));
                config.CreateMap<EmployeeViewModel, Employee>();
                config.CreateMap<Employee, EmployeeViewModel>();
        });
        }
    }
}


