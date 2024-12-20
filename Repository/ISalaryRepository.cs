using SalaryService.Model;

namespace SalaryService.Repository
{
    public interface ISalaryRepository
    {
        Task AddSalaryAsync(Salary salary);
        Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId);
    }
}
