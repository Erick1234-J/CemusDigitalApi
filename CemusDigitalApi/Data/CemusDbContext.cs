using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace CemusDigitalApi.Data
{
    public class CemusDbContext : DbContext
    {
        public CemusDbContext(DbContextOptions<CemusDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Documents> Documents { get; set; }

        public DbSet<Batch> Batchs { get; set; }

        public DbSet<DocVersion> Versions { get; set; }
    }
}
