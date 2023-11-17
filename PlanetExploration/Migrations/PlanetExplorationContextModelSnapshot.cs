﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanetExploration.PlanetExploration.Dal.Data;

#nullable disable

namespace PlanetExploration.Migrations
{
    [DbContext(typeof(PlanetExplorationContext))]
    partial class PlanetExplorationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.HumanCaptain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("HumanCaptains");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HumanCaptainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HumanCaptainId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Planet", b =>
                {
                    b.HasOne("PlanetExploration.PlanetExploration.Core.Models.Team", "Team")
                        .WithMany("Planets")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Robot", b =>
                {
                    b.HasOne("PlanetExploration.PlanetExploration.Core.Models.Team", null)
                        .WithMany("Robots")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Team", b =>
                {
                    b.HasOne("PlanetExploration.PlanetExploration.Core.Models.HumanCaptain", "HumanCaptain")
                        .WithMany()
                        .HasForeignKey("HumanCaptainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HumanCaptain");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Team", b =>
                {
                    b.Navigation("Planets");

                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}
