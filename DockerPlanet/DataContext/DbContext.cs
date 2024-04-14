using DockerPlanet.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerPlanet.DataContext
{
    public class AppDbContext : DbContext //Retirar o DbContext para o Identity
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }

        //Retirando quando subistituiu o DbContext pelo IdentityDbContext
        #region Comment
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Planet>().HasData(
                new Planet
                {
                    Id = 1,
                    Name = "Earth",
                    Mass = 5.972,
                    Radius =100,
                    Gravity = 6371000
                }, 
                new Planet
                {
                    Id = 2,
                    Name = "Mars",
                    Mass = 4.972,
                    Radius = 130,
                    Gravity = 6781000
                }
                );
        }

        #endregion
    }
}