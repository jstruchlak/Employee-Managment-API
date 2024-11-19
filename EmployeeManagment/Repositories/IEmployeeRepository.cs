using EmployeeManagment.models;

namespace EmployeeManagment.Repositories
{
    public interface IEmployeeRepository
    {
        // READ
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        // CREATE
        Task AddEmployeeAsync(Employee employee);
        // UPDATE
        Task UpdateEmployeeAsync(Employee employee);
        // DELETE
        Task DeleteEmployeeAsync(int id);
    }
}
