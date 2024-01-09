﻿// <auto-generated />
using System;
using Database.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240109095228_Initial5")]
    partial class Initial5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.Models.AreaCalculation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Circumference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ResultId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("AreaCalculation");
                });

            modelBuilder.Entity("Database.Models.Calculator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FirstInput")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Operator")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ResultId")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondInput")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Calculator");
                });

            modelBuilder.Entity("Database.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("Database.Models.AreaCalculation", b =>
                {
                    b.HasOne("Database.Models.Result", null)
                        .WithMany("AreaCalculations")
                        .HasForeignKey("ResultId");
                });

            modelBuilder.Entity("Database.Models.Calculator", b =>
                {
                    b.HasOne("Database.Models.Result", null)
                        .WithMany("MathCalculations")
                        .HasForeignKey("ResultId");
                });

            modelBuilder.Entity("Database.Models.Result", b =>
                {
                    b.Navigation("AreaCalculations");

                    b.Navigation("MathCalculations");
                });
#pragma warning restore 612, 618
        }
    }
}
