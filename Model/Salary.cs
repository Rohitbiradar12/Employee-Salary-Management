using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryService.Model
{
        public class Salary
        {
            public int Id { get; set; }
     
            [ForeignKey("Employee")]
            public int EmployeeId { get; set; }
            public decimal Basic { get; set; }
            public decimal Allowances { get; set; }
            public decimal Deductions { get; set; }
            public decimal Total => Basic + Allowances - Deductions;
        }
    



}
