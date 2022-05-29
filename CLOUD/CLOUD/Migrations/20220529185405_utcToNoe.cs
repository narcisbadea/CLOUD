using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class utcToNoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medici_Users_UserId",
                table: "Medici");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicPacienti_Medici_MedicId",
                table: "MedicPacienti");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicId",
                table: "MedicPacienti",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Medici",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Medici_Users_UserId",
                table: "Medici",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicPacienti_Medici_MedicId",
                table: "MedicPacienti",
                column: "MedicId",
                principalTable: "Medici",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medici_Users_UserId",
                table: "Medici");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicPacienti_Medici_MedicId",
                table: "MedicPacienti");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicId",
                table: "MedicPacienti",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Medici",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medici_Users_UserId",
                table: "Medici",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicPacienti_Medici_MedicId",
                table: "MedicPacienti",
                column: "MedicId",
                principalTable: "Medici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
