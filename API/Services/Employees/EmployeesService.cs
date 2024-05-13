using API.Data;
using API.DTOs.Requests;
using API.DTOs.Responses;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public EmployeesService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> PostEmployee(EmployeeRequest request)
        {
            var employee = mapper.Map<Employee>(request);

            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(int id, EmployeeRequest request)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
                return null;

            var updatedEmployee = mapper.Map<Employee>(request);

            context.Entry(employee).CurrentValues.SetValues(updatedEmployee);
            await context.SaveChangesAsync();

            return updatedEmployee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = context.Employees.Find(id);

            if (employee == null)
                return false;

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();

            return true;
        }

        public RoleResponse GetEmployeeForRole(int roleId)
        {
            var employeeByRole = context.Employees.Where(x => ((int)x.Role) == roleId);

            var count = employeeByRole.Count();
            var averageSalary = employeeByRole.Average(x => x.Salary);

            return new RoleResponse {
                Role = roleId,
                Description = Enum.GetName(typeof(RoleEnum), roleId),
                AverageSalary = averageSalary,
                Count = count
            };
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByBoss(int bossId)
        {
            return await context.Employees.Where(x => x.BossId == bossId).ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeSalary(int id, EmployeeSalaryRequest request)
        {
            var employee = context.Employees.Find(id);
            var updatedEmployee = employee;

            if (employee == null)
                return null;

            updatedEmployee.SetSalary(request.Salary);

            context.Entry(employee).CurrentValues.SetValues(updatedEmployee);
            await context.SaveChangesAsync();

            return updatedEmployee;
        }
    }
}