using HRSYSTEM.domain;
using HRSYSTEM.persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace HRSYSTEM.persistance.Repositories.Employee
{
    /// <summary>
    /// Pattern Repository for employees
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateEmployee(EmployeeEntity employee)
        {
            employee.CreatedOn = DateTime.Now;
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateStatusEmployee(EmployeeEntity employee, int status)
        {
            var currentEmployee = await GetEmployee(employee.EmployeeID);

            if (status == StatusEmployeeEnum.Terminated.GetHashCode())
            {
                currentEmployee.Status = StatusEmployeeEnum.Terminated;
            }
            if (status == StatusEmployeeEnum.Inactive.GetHashCode())
            {
                currentEmployee.Status = StatusEmployeeEnum.Inactive;
            }
            if (status == StatusEmployeeEnum.Active.GetHashCode())
            {
                currentEmployee.Status = StatusEmployeeEnum.Active;
            }

            currentEmployee.UpdatedOn = DateTime.Now;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            var employee = await _context.Employees.Include(x => x.JobCatalog).FirstOrDefaultAsync(x => x.EmployeeID == id);
            return employee;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            var employees = await _context.Employees.Include(x => x.JobCatalog).ToListAsync();
            return employees;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployeesByStatus (int status)
        {
            var employees = await _context.Employees.ToListAsync();
            var employeesFilter = employees.Where(x => x.Status.GetHashCode() == status).AsEnumerable<EmployeeEntity>();
            return employeesFilter;
        }

        public async Task<bool> UpdateEmployee(EmployeeEntity employee)
        {
            var currentEmployee = await GetEmployee(employee.EmployeeID);

            currentEmployee.FirstName = employee.FirstName;
            currentEmployee.LastName = employee.LastName;
            currentEmployee.MiddleName = employee.MiddleName;
            currentEmployee.WorkEmail = employee.WorkEmail;
            currentEmployee.Telephone = employee.Telephone;
            currentEmployee.Status = employee.Status;
            currentEmployee.UpdatedOn = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;

        }
    }
}
