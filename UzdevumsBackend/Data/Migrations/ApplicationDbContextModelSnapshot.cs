﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UzdevumsBackend.Context;

#nullable disable

namespace UzdevumsBackend.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UzdevumsBackend.Models.Dats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("BottDepthM")
                        .HasColumnType("double precision")
                        .HasColumnName("Bott Depth M");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DateTime");

                    b.Property<int>("Individuals")
                        .HasColumnType("integer")
                        .HasColumnName("Individuals");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("Latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("Longitude");

                    b.Property<string>("Parameter")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Parameter");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Project");

                    b.Property<string>("Quality")
                        .HasColumnType("text")
                        .HasColumnName("Quality");

                    b.Property<int>("SampleId")
                        .HasColumnType("integer")
                        .HasColumnName("Sample ID");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Species");

                    b.Property<string>("Station")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Station");

                    b.Property<string>("Tissue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Tissue");

                    b.Property<string>("Trip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Trip");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Units");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("Dati");
                });
#pragma warning restore 612, 618
        }
    }
}
