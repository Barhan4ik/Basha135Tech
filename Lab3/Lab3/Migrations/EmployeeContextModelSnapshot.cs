﻿// <auto-generated />
using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab3.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Work_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("Lab3.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<int>("Identity_number")
                        .HasColumnType("int");

                    b.Property<int>("Job_id")
                        .HasColumnType("int");

                    b.Property<string>("Post")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("catalogId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("catalogId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Lab3.Models.Employee", b =>
                {
                    b.HasOne("Lab3.Models.Catalog", "catalog")
                        .WithMany()
                        .HasForeignKey("catalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("catalog");
                });
#pragma warning restore 612, 618
        }
    }
}
