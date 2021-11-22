using HRSYSTEM.domain;

namespace HRSYSTEM.persistance.Repositories.Employee
{
    /// <summary>
    /// Employee Repository DI
    /// </summary>
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployee(int id);
        Task CreateEmployee(EmployeeEntity employee);
        Task<bool> UpdateEmployee(EmployeeEntity employee);
        Task<bool> DeleteEmployee(int id);
    }
}
