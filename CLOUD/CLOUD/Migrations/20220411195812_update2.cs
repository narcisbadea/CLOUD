using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PacientId",
                table: "DateMedicale",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DateMedicale_PacientId",
                table: "DateMedicale",
                column: "PacientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateMedicale_Pacienti_PacientId",
                table: "DateMedicale",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateMedicale_Pacienti_PacientId",
                table: "DateMedicale");

            migrationBuilder.DropIndex(
                name: "IX_DateMedicale_PacientId",
                table: "DateMedicale");

            migrationBuilder.DropColumn(
                name: "PacientId",
                table: "DateMedicale");
        }
    }
}
