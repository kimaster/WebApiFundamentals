using CityInfo.Api.Entities;
using CityInfo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.DbContexts
{
    public class CityInforContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        protected CityInforContext()
        {
        }

        public CityInforContext(DbContextOptions<CityInforContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<City>()
                .HasData(
                new("Algiers")
                {
                    Id = 1,
                },
                new("New York")
                {
                    Id = 2,
                },
                new("Paris")
                {
                    Id = 3,
                },
                new City("Antwerp")
                {
                    Id = 4,
                });
            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Central Park")
                {
                    Id=1,
                    CityId = 1,
                    Description = " best centra park ever:) "
                ,
                },
                new PointOfInterest("Empire State building")
                {
                    Id = 2,
                    CityId = 1,
                    Description = " best State building"
                ,
                },
                   new PointOfInterest("Notre dame de Paris")
                   {
                       Id = 3,
                       CityId = 2,
                       Description = "Algeria"
                ,
                   },
                   new PointOfInterest("Makame Chahid")
                   {
                       Id = 4,
                       CityId = 2,
                       Description = "Makame"
                ,
                   }


                );
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionString");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
