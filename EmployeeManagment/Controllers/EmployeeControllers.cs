using EmployeeManagment.models;
using EmployeeManagment.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controller
{
    [Route("api[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeControllers(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return Created();
        }
    }
}
