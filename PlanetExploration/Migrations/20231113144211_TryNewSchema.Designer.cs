﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanetExploration.PlanetExploration.Dal.Data;

#nullable disable

namespace PlanetExploration.Migrations
{
    [DbContext(typeof(PlanetExplorationContext))]
    [Migration("20231113144211_TryNewSchema")]
    partial class TryNewSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

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
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Robot", b =>
                {
                    b.HasOne("PlanetExploration.PlanetExploration.Core.Models.Team", "Team")
                        .WithMany("Robots")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
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
                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}