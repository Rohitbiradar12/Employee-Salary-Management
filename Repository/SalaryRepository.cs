using Microsoft.EntityFrameworkCore;
using SalaryService.Context;
using SalaryService.Model;

namespace SalaryService.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly SalaryDbContext _context;

        public SalaryRepository(SalaryDbContext context)
        {
            _context = context;
        }

        public async Task AddSalaryAsync(Salary salary)
        {
            await _context.Salaries.AddAsync(salary);
            await _context.SaveChangesAsync();
        }

        public async Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId)
        {
            return await _context.Salaries.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);
        }
    }
}
