using API.DTOs.Requests;
using API.DTOs.Responses;
using API.Entities;
using API.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var response = await employeesService.GetEmployees();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var response = await employeesService.GetEmployee(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] EmployeeRequest request)
        {
            var response = await employeesService.PostEmployee(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, [FromBody] EmployeeRequest request)
        {
            var response = await employeesService.UpdateEmployee(id, request);

            return Ok(response);
        }

        [HttpPut("{id}/salary")]
        public async Task<ActionResult<Employee>> UpdateEmployeeSalary(int id, [FromBody] EmployeeSalaryRequest request)
        {
            var response = await employeesService.UpdateEmployeeSalary(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var response = await employeesService.DeleteEmployee(id);

            return Ok(response);
        }

        [HttpGet("role/{roleId}")]
        public ActionResult<RoleResponse> GetEmployeeForRole(int roleId) 
        {
            var response = employeesService.GetEmployeeForRole(roleId);

            return Ok(response);
        }

        [HttpGet("boss/{bossId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByBoss(int bossId)
        {
            var response = await employeesService.GetEmployeeByBoss(bossId);

            return Ok(response);
        }
    }
}