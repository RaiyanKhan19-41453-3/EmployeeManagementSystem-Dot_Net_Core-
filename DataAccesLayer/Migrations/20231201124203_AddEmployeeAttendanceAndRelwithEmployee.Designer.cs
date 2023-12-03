﻿// <auto-generated />
using System;
using DataAccesLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231201124203_AddEmployeeAttendanceAndRelwithEmployee")]
    partial class AddEmployeeAttendanceAndRelwithEmployee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccesLayer.EF.Models.tblEmployee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employeeId"));

                    b.Property<string>("employeeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeSalary")
                        .HasColumnType("int");

                    b.Property<int>("supervisorId")
                        .HasColumnType("int");

                    b.HasKey("employeeId");

                    b.ToTable("tblEmployees");
                });

            modelBuilder.Entity("DataAccesLayer.EF.Models.tblEmployeeAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("attendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<int>("isAbsent")
                        .HasColumnType("int");

                    b.Property<int>("isOffday")
                        .HasColumnType("int");

                    b.Property<int>("isPresent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("employeeId");

                    b.ToTable("tblEmpAttendances");
                });

            modelBuilder.Entity("DataAccesLayer.EF.Models.tblEmployeeAttendance", b =>
                {
                    b.HasOne("DataAccesLayer.EF.Models.tblEmployee", "Employee")
                        .WithMany("employeeAttendances")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DataAccesLayer.EF.Models.tblEmployee", b =>
                {
                    b.Navigation("employeeAttendances");
                });
#pragma warning restore 612, 618
        }
    }
}
