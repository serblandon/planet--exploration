﻿// <auto-generated />
using System;
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
    [Migration("20231120183213_Nullabel2")]
    partial class Nullabel2
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PlanetId")
                        .IsUnique()
                        .HasFilter("[PlanetId] IS NOT NULL");

                    b.ToTable("HumanCaptains");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("This planet has not been visited yet.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<int?>("PlanetId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PlanetId");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.HumanCaptain", b =>
                {
                    b.HasOne("PlanetExploration.PlanetExploration.Core.Models.Planet", "Planet")
                        .WithOne("HumanCaptain")
                        .HasForeignKey("PlanetExploration.PlanetExploration.Core.Models.HumanCaptain", "PlanetId");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Robot", b =>
                {
                    b.HasOne("PlanetExploration.PlanetExploration.Core.Models.Planet", "Planet")
                        .WithMany("Robots")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("PlanetExploration.PlanetExploration.Core.Models.Planet", b =>
                {
                    b.Navigation("HumanCaptain");

                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}
