using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Catalog> Catalogs { get; set; } = null!;
    }
}
