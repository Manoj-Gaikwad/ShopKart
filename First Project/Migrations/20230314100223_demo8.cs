using Microsoft.EntityFrameworkCore.Migrations;

namespace First_Project.Migrations
{
    public partial class demo8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subShoesData",
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
                    ssimage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ssimage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ssimage3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subShoesData", x => x.pid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subShoesData");
        }
    }
}
