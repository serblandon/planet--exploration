using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Dal.Data
{
    public class PlanetExplorationContext : DbContext
    {
        public DbSet<HumanCaptain> HumanCaptains { get; set; } = null;
        public DbSet<Planet> Planets { get; set; } = null;
        public DbSet<Robot> Robots { get; set; } = null;

        public PlanetExplorationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PlanetExplorationDDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HumanCaptain>()
                .HasIndex(h => h.Name)
                .IsUnique();

            modelBuilder.Entity<Robot>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<Planet>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Robot>()
                .HasMany<Planet>()
                .WithMany(r => r.Robots);

            modelBuilder.Entity<HumanCaptain>()
                .HasMany<Planet>()
                .WithOne(h => h.HumanCaptain);

            modelBuilder.Entity<Planet>()
                .Property(p => p.Description)
                .HasDefaultValue("This planet has not been visited yet.");

            modelBuilder
                .Entity<Planet>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }

    }
}
