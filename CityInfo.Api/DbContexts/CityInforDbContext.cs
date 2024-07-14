using CityInfo.Api.Entities;
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

       public CityInforContext(DbContextOptions<CityInforContext> options): base(options) { 
        
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionString");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
