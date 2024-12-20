using SalaryService.Model;
using SalaryService.Repository;

namespace SalaryService.Service
{
    public class SalaryServices : ISalaryService
    {
        private readonly ISalaryRepository _repository;

        public SalaryServices(ISalaryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddSalaryAsync(Salary salary)
        {
            if (salary == null || salary.EmployeeId <= 0)
            {
                throw new ArgumentException("Invalid salary details");
            }

            await _repository.AddSalaryAsync(salary);
        }

        public async Task<Salary> GetSalaryByEmployeeIdAsync(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException("Invalid employee ID");
            }

            var salary = await _repository.GetSalaryByEmployeeIdAsync(employeeId);
            if (salary == null)
            {
                throw new Exception($"No salary found for EmployeeId {employeeId}");
            }

            return salary;
        }
    }
}
