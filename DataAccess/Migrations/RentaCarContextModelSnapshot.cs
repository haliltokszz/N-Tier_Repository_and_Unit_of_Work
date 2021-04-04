﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.Migrations
{
    [DbContext(typeof(RentaCarContext))]
    partial class RentaCarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Entities.Abstract.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Concrete.Cars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KMCurrent")
                        .HasColumnType("int");

                    b.Property<int>("KMLimitDaily")
                        .HasColumnType("int");

                    b.Property<byte>("LimitMinAge")
                        .HasColumnType("tinyint");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("RequiredDriveExperience")
                        .HasColumnType("tinyint");

                    b.Property<byte>("SeatsNumber")
                        .HasColumnType("tinyint");

                    b.Property<int>("TrunkCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Entities.Concrete.Companies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Entities.Concrete.Rentals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("KMCurrent")
                        .HasColumnType("int");

                    b.Property<int>("KMDelivery")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Entities.Concrete.Customers", b =>
                {
                    b.HasBaseType("Entities.Abstract.Users");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.Concrete.Employees", b =>
                {
                    b.HasBaseType("Entities.Abstract.Users");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entities.Concrete.Cars", b =>
                {
                    b.HasOne("Entities.Concrete.Companies", "Company")
                        .WithMany("Cars")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.Concrete.Rentals", b =>
                {
                    b.HasOne("Entities.Concrete.Cars", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Companies", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Entities.Concrete.Customers", b =>
                {
                    b.HasOne("Entities.Abstract.Users", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Customers", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Concrete.Employees", b =>
                {
                    b.HasOne("Entities.Concrete.Companies", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Abstract.Users", null)
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Employees", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Entities.Concrete.Companies", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}