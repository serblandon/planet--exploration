﻿using Microsoft.EntityFrameworkCore;
using PlanetExploration.PlanetExploration.Core.Models;

namespace PlanetExploration.PlanetExploration.Dal.Data
{
    public class PlanetExplorationContext : DbContext
    {
        public DbSet<HumanCaptain> HumanCaptains { get; set; } = null;
        public DbSet<Planet> Planets { get; set; } = null;
        public DbSet<Robot> Robots { get; set; } = null;
        public DbSet<Team> Teams { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlanetExplorationDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HumanCaptain>()
                .HasOne(hc => hc.Team)
                .WithOne(t => t.HumanCaptain)
                .HasForeignKey<HumanCaptain>(hc => hc.TeamId);
        }

    }
}
