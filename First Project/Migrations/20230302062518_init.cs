using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pid = table.Column<int>(type: "int", nullable: false),
                    ptype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    psize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pcolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pquantity = table.Column<int>(type: "int", nullable: false),
                    pprice = table.Column<int>(type: "int", nullable: false),
                    pimage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cloths",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ptype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pprice = table.Column<int>(type: "int", nullable: false),
                    pcolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pdes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pimage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cloths", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cosmetic",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ptype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pprice = table.Column<int>(type: "int", nullable: false),
                    pcolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pdes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pimage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cosmetic", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "customerdetails",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerdetails", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employeeDetails",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDetails", x => x.EmpId);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    personID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.personID);
                });

            migrationBuilder.CreateTable(
                name: "subclothimages",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ptype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pprice = table.Column<int>(type: "int", nullable: false),
                    pcolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pdes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pimage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scimage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scimage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scimage3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subclothimages", x => x.pid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "cloths");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "cosmetic");

            migrationBuilder.DropTable(
                name: "customerdetails");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "employeeDetails");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "subclothimages");
        }
    }
}
