using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecgs_Users_UserId",
                table: "Ecgs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pulss_Users_UserId",
                table: "Pulss");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperaturi_Users_UserId",
                table: "Temperaturi");

            migrationBuilder.DropForeignKey(
                name: "FK_Umiditates_Users_UserId",
                table: "Umiditates");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Umiditates",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_Umiditates_UserId",
                table: "Umiditates",
                newName: "IX_Umiditates_PacientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Temperaturi",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_Temperaturi_UserId",
                table: "Temperaturi",
                newName: "IX_Temperaturi_PacientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pulss",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_Pulss_UserId",
                table: "Pulss",
                newName: "IX_Pulss_PacientId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ecgs",
                newName: "PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_Ecgs_UserId",
                table: "Ecgs",
                newName: "IX_Ecgs_PacientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecgs_Pacienti_PacientId",
                table: "Ecgs",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pulss_Pacienti_PacientId",
                table: "Pulss",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperaturi_Pacienti_PacientId",
                table: "Temperaturi",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Umiditates_Pacienti_PacientId",
                table: "Umiditates",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecgs_Pacienti_PacientId",
                table: "Ecgs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pulss_Pacienti_PacientId",
                table: "Pulss");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperaturi_Pacienti_PacientId",
                table: "Temperaturi");

            migrationBuilder.DropForeignKey(
                name: "FK_Umiditates_Pacienti_PacientId",
                table: "Umiditates");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "Umiditates",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Umiditates_PacientId",
                table: "Umiditates",
                newName: "IX_Umiditates_UserId");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "Temperaturi",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Temperaturi_PacientId",
                table: "Temperaturi",
                newName: "IX_Temperaturi_UserId");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "Pulss",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pulss_PacientId",
                table: "Pulss",
                newName: "IX_Pulss_UserId");

            migrationBuilder.RenameColumn(
                name: "PacientId",
                table: "Ecgs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ecgs_PacientId",
                table: "Ecgs",
                newName: "IX_Ecgs_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ecgs_Users_UserId",
                table: "Ecgs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pulss_Users_UserId",
                table: "Pulss",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperaturi_Users_UserId",
                table: "Temperaturi",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Umiditates_Users_UserId",
                table: "Umiditates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
