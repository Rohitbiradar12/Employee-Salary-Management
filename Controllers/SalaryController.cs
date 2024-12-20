using Microsoft.AspNetCore.Mvc;
using SalaryService.Model;
using SalaryService.Service;

namespace SalaryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _service;

        public SalaryController(ISalaryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(Salary salary)
        {
            try
            {
                await _service.AddSalaryAsync(salary);
                return CreatedAtAction(nameof(GetSalary), new { employeeId = salary.EmployeeId }, salary);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetSalary(int employeeId)
        {
            try
            {
                var salary = await _service.GetSalaryByEmployeeIdAsync(employeeId);
                return Ok(salary);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
            }
        }
    }
}
