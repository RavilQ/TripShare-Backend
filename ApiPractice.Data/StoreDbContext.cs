using ApiPractice.Core.Entities;
using ApiPractice.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiPractice.Data
{
    public class StoreDbContext:IdentityDbContext<AppUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<PickupLocations> PickupLocations { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripPickups> TripPickups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
