using Microsoft.EntityFrameworkCore;
using MVC_webapi.Models.Entities;
namespace MVC_webapi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Birds> Birds { get; set; }
        public DbSet<Cages> Cages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cages>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasMany<Birds>(b => b.Birds).WithOne().HasForeignKey(c => c.CageId).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Birds>(e =>
            {
                e.HasKey(b => b.Id);
                e.Property(b => b.Name).IsRequired();
            });
                
                
        }
    }
}
