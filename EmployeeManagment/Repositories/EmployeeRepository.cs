using EmployeeManagment.Data;
using EmployeeManagment.models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
        // DELETE
        public async Task DeleteEmployeeAsync(int id)
        {
            var employeeInDb = await _context.Employees.FindAsync(id);
            if (employeeInDb == null)
            {
                throw new KeyNotFoundException($"Employee with {id} was not found");
            }

            _context.Employees.Remove(employeeInDb);
            await _context.SaveChangesAsync();
        }
        // READ
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        // UPDATE
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
