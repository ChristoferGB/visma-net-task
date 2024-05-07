using API.DTOs.Requests;
using API.DTOs.Responses;
using API.Entities;

namespace API.Services.Employees
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> PostEmployee(EmployeeRequest request);
        Task<Employee> UpdateEmployee(int id, EmployeeRequest request);
        Task<bool> DeleteEmployee(int id);
        RoleResponse GetEmployeeForRole(int roleId);
    }
}