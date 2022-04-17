using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class strada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Strade",
                table: "Pacienti",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Strade",
                table: "Pacienti");
        }
    }
}
