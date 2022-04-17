using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class strada20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Strade",
                table: "Pacienti",
                newName: "Strada");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Strada",
                table: "Pacienti",
                newName: "Strade");
        }
    }
}
