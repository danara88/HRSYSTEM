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
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var currentEmployee = await GetEmployee(id);
            _context.Employees.Remove(currentEmployee);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<EmployeeEntity> GetEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeID == id);
            return employee;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
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
