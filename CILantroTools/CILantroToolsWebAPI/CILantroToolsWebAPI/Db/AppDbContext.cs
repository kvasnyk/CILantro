using CILantroToolsWebAPI.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CILantroToolsWebAPI.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasKey(t => t.Id);
        }
    }
}