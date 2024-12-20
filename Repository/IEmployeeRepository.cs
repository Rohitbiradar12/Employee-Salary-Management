using EmployeeService.Model;

namespace EmployeeService.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> FilterEmployeesAsync(string? city, int? age);
        Task<IEnumerable<Employee>> SortEmployeesAsync(IEnumerable<Employee> employees,string sortBy,string sortOrder);
        Task AddEmployeeAsync(Employee employee);
    }
}
