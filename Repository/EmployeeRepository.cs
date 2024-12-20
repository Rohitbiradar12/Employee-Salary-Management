using System.Runtime.CompilerServices;
using EmployeeService.Context;
using EmployeeService.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }
    
        public async Task<IEnumerable<Employee>> FilterEmployeesAsync(string? city, int? age)
        {
            var query  = employeeDbContext.Employees.AsQueryable();
            if(!string.IsNullOrEmpty(city))
            {
                query = query.Where(x => x.City == city);
            }
            if(age.HasValue)
            {
                query = query.Where(e => e.Age == age);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SortEmployeesAsync(IEnumerable<Employee> employees, string sortBy, string sortOrder)
        {
            var query = employeeDbContext.Employees.AsQueryable();

            sortBy = sortBy?.ToLower();
            sortOrder = sortOrder?.ToLower();

            query = sortBy switch
            {
                "name" => sortOrder == "desc" ? query.OrderByDescending(e => e.Name) : query.OrderBy(e => e.Name),
                "age" => sortOrder == "desc" ? query.OrderByDescending(e => e.Age) : query.OrderBy(e => e.Age),
                _ => query.OrderBy(e => e.Id) // Default sorting
            };

            return await query.ToListAsync();

        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            }

            
            await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
        }
    }
}
