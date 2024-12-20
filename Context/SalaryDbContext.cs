using Microsoft.EntityFrameworkCore;
using SalaryService.Model;

namespace SalaryService.Context
{
    public class SalaryDbContext : DbContext
    {
        public SalaryDbContext(DbContextOptions<SalaryDbContext> options) : base(options) { }   

        public DbSet<Salary> Salaries { get; set; }
    }
}
