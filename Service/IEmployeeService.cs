using EmployeeService.Model;
using EmployeeService.Model.DTO;

namespace EmployeeService.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(EmployeeFilterDTO employeeFilterDTO);
        Task<Employee> AddEmployeesAsync(Employee employee);
    }
}
