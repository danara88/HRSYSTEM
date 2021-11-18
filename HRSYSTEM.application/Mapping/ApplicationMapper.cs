using AutoMapper;
using HRSYSTEM.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSYSTEM.application.Mapping
{
    /// <summary>
    /// This is the auto mapper of DTOs - Entities
    /// </summary>
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            #region Employee
            CreateMap<EmployeeEntity, GetEmployeesDTO>();
            CreateMap<GetEmployeesDTO, EmployeeEntity>();
            CreateMap<EmployeeEntity, CreateEmployeeDTO>();
            CreateMap<CreateEmployeeDTO, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeDTO>();
            CreateMap<EmployeeDTO, EmployeeEntity>();
            #endregion Employee

        }
    }
}
