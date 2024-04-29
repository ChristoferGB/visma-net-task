using API.Data;
using API.DTOs.Requests;
using API.Entities;
using API.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var response = await employeesService.DeleteEmployee(id);

            return Ok(response);
        }
    }
}