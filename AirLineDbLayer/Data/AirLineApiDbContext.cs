using AirLineDbLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineDbLayer.Data
{
    public class AirLineApiDbContext:DbContext
    {
        public DbSet<AirLineApiModel> AirLine { set; get; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AirLineApiDbContext(DbContextOptions<AirLineApiDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AirLineApiModel>().HasIndex(Airline => Airline.Name).IsUnique();


        }
    }
}
