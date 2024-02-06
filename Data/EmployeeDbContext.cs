using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_core_api.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set;}
    }
}
