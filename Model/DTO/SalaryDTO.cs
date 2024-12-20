

namespace EmployeeService.Model.DTO
{
   
        public class SalaryDTO
        {
            public decimal Basic { get; set; }
            public decimal Allowances { get; set; }
            public decimal Deductions { get; set; }
            public int EmployeeId { get; set; }
        }
   

}
