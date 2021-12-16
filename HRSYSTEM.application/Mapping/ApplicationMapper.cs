using AutoMapper;
using HRSYSTEM.domain;

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

            #region JobCatalog
            CreateMap<JobCatalogEntity, JobCatalogDTO>();
            CreateMap<JobCatalogDTO, JobCatalogEntity>();
            #endregion

        }
    }
}
