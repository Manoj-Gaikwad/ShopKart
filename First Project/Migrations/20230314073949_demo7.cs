using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class demo7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes");

            migrationBuilder.RenameTable(
                name: "Shoes",
                newName: "shoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shoes",
                table: "shoes",
                column: "pid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_shoes",
                table: "shoes");

            migrationBuilder.RenameTable(
                name: "shoes",
                newName: "Shoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes",
                column: "pid");
        }
    }
}
