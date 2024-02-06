using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_core_api.Data
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext=employeeDbContext;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeeDbContext.Set<Employee>().AddAsync(employee);

            await _employeeDbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeDbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(int id, Employee model)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(id);

            if (employee==null)
            {
                throw new Exception("Employee not found");
            }
            employee.Name= model.Name;
            employee.Email= model.Email;
            employee.Phone= model.Phone;
            employee.Age= model.Age;
            employee.Salary= model.Salary;
            employee.Description= model.Description;
            await _employeeDbContext.SaveChangesAsync();
        }
        public async Task DeleteEmploeeAsync(int id)
        {
            var employee= await _employeeDbContext.Employees.FindAsync(id);
            if(employee==null)
            {
                throw new Exception("Employee not found");
            }
            _employeeDbContext.Employees.Remove(employee);
            await _employeeDbContext.SaveChangesAsync();
        }
    }
}
