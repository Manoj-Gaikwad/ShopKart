using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class demo9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ssimage3",
                table: "subShoesData",
                newName: "scimage3");

            migrationBuilder.RenameColumn(
                name: "ssimage2",
                table: "subShoesData",
                newName: "scimage2");

            migrationBuilder.RenameColumn(
                name: "ssimage1",
                table: "subShoesData",
                newName: "scimage1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "scimage3",
                table: "subShoesData",
                newName: "ssimage3");

            migrationBuilder.RenameColumn(
                name: "scimage2",
                table: "subShoesData",
                newName: "ssimage2");

            migrationBuilder.RenameColumn(
                name: "scimage1",
                table: "subShoesData",
                newName: "ssimage1");
        }
    }
}
