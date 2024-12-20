using SalaryService.Model;

namespace SalaryService.Service
{
    
        public interface ISalaryService
        {
            Task AddSalaryAsync(Salary salary);
            Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId);
        }
    

}
