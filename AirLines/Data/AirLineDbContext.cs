using AirLines.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLines.Data
{
    public class AirLineDbContext:DbContext
    {
        public DbSet<User>? user { get; set; }
        public DbSet<Role>? role { get; set; }
        public AirLineDbContext(DbContextOptions options):base(options){}

        public AirLineDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasIndex(u=>u.Email).IsUnique();
            builder.Entity<Role>().HasIndex(r=>r.Name).IsUnique();
           
        }

        public DbSet<AirLines.Models.AirlineViewModel>? AirlineViewModel { get; set; }
    }
}
