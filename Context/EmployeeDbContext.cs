using EmployeeService.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }  
    }
}
