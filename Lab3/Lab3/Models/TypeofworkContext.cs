using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class TypeofworkContext : DbContext
    {
        public TypeofworkContext(DbContextOptions<TypeofworkContext> options) : base(options)
        {
        }
        public DbSet<Typeofwork> Typeofworks { get; set; } = null!;
        public DbSet<Workcatalog> Workcatalogs { get; set; } = null!;
    }
}
