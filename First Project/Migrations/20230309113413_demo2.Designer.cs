﻿// <auto-generated />
using System;
using First_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace First_Project.Migrations
{
    [DbContext(typeof(DBConnection))]
    [Migration("20230309113413_demo2")]
    partial class demo2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("First_Project.Data.CartData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("pcolor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pid")
                        .HasColumnType("int");

                    b.Property<string>("pimage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pprice")
                        .HasColumnType("int");

                    b.Property<int>("pquantity")
                        .HasColumnType("int");

                    b.Property<string>("psize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ptype")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("First_Project.Data.ClothsAllData", b =>
                {
                    b.Property<int>("pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("pcolor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pdes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pimage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pprice")
                        .HasColumnType("int");

                    b.Property<string>("ptype")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scimage1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scimage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scimage3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pid");

                    b.ToTable("subclothimages");
                });

            modelBuilder.Entity("First_Project.Data.ClothsData", b =>
                {
                    b.Property<int>("pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("pcolor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pdes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pimage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pprice")
                        .HasColumnType("int");

                    b.Property<string>("ptype")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pid");

                    b.ToTable("cloths");
                });

            modelBuilder.Entity("First_Project.Data.CompanyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("First_Project.Data.CosmeticsData", b =>
                {
                    b.Property<int>("pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("pcolor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pdes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pimage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pprice")
                        .HasColumnType("int");

                    b.Property<string>("ptype")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pid");

                    b.ToTable("cosmetic");
                });

            modelBuilder.Entity("First_Project.Data.CustomerData", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.HasKey("CId");

                    b.ToTable("customerdetails");
                });

            modelBuilder.Entity("First_Project.Data.DepartmentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("department");
                });

            modelBuilder.Entity("First_Project.Data.EmployeeDetails", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("employeeDetails");
                });

            modelBuilder.Entity("First_Project.Data.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("gender");
                });

            modelBuilder.Entity("First_Project.Data.PersonsData", b =>
                {
                    b.Property<int>("personID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("personID");

                    b.ToTable("persons");
                });
#pragma warning restore 612, 618
        }
    }
}
