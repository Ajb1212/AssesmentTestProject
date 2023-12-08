using Microsoft.EntityFrameworkCore;

namespace AssesmentTestProject.Models
{
    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HierarchyModel> Hierarcies { get; set; }
    }
}
