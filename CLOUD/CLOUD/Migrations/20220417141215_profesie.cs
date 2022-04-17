using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class profesie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profestie",
                table: "Pacienti",
                newName: "Profesie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profesie",
                table: "Pacienti",
                newName: "Profestie");
        }
    }
}
