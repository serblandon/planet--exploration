using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Dal.Data
{
    public class PlanetExplorationContext : DbContext
    {
        public DbSet<HumanCaptain> HumanCaptains { get; set; } = null;
        public DbSet<Planet> Planets { get; set; } = null;
        public DbSet<Robot> Robots { get; set; } = null;
        public DbSet<Team> Teams { get; set; } = null;

        public PlanetExplorationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PlanetExplorationDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .EnableSensitiveDataLogging();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Team>()
        //        .HasOne(hc => hc.HumanCaptain)
        //        .WithOne(t => t.Team)
        //        .HasForeignKey<HumanCaptain>(hc => hc.TeamId);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HumanCaptain>()
                .HasIndex(h => h.Name)
                .IsUnique();

            modelBuilder.Entity<Robot>()
                .HasIndex(r => r.Name)
                .IsUnique();
        }

    }
}
