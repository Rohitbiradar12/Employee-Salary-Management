
using EmployeeService.Model;
using EmployeeService.Model.DTO;
using EmployeeService.Repository;
using Newtonsoft.Json;
using System.Net.Http;


namespace EmployeeService.Service
{
    public class EmployeeGetService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly HttpClient httpClient;

        public EmployeeGetService(IEmployeeRepository employeeRepository, HttpClient httpClient)
        {
            this.employeeRepository = employeeRepository;
            this.httpClient = httpClient;
        }

         async Task<IEnumerable<Employee>> IEmployeeService.GetEmployeesAsync(EmployeeFilterDTO employeeFilterDTO)
        {
            var employees = await employeeRepository.GetAllAsync();

            
            if (!string.IsNullOrEmpty(employeeFilterDTO.City) || employeeFilterDTO.Age.HasValue)
            {
                employees = await employeeRepository.FilterEmployeesAsync(employeeFilterDTO.City, employeeFilterDTO.Age);
            }

           
            if (!string.IsNullOrEmpty(employeeFilterDTO.SortBy) && !string.IsNullOrEmpty(employeeFilterDTO.SortOrder))
            {
                employees = await employeeRepository.SortEmployeesAsync(employees, employeeFilterDTO.SortBy, employeeFilterDTO.SortOrder);
            }

            return employees;
        }


         async Task<Employee> IEmployeeService.AddEmployeesAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Employee cannot be null");
            }

            await employeeRepository.AddEmployeeAsync(employee);

            var salary = new SalaryDTO
            {
                EmployeeId = employee.Id,
                Basic = 30000, 
                Allowances = 5000,
                Deductions = 2000
            };

            var response = await httpClient.PostAsJsonAsync("http://localhost:5283/api/Salary", salary);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to notify the Salary Service about the new employee.");
            }

            return employee;
        }
    }
    
}
