using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IstoricMedicals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProblemaMedicala = table.Column<string>(type: "text", nullable: false),
                    Tratament = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IstoricMedicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateMedicale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IstoricMedicalId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsulatatiiCardiologice = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMedicale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateMedicale_IstoricMedicals_IstoricMedicalId",
                        column: x => x.IstoricMedicalId,
                        principalTable: "IstoricMedicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alergii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipAlergie = table.Column<string>(type: "text", nullable: false),
                    Simptome = table.Column<string>(type: "text", nullable: false),
                    DateMedicaleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergii_DateMedicale_DateMedicaleId",
                        column: x => x.DateMedicaleId,
                        principalTable: "DateMedicale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergii_DateMedicaleId",
                table: "Alergii",
                column: "DateMedicaleId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMedicale_IstoricMedicalId",
                table: "DateMedicale",
                column: "IstoricMedicalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergii");

            migrationBuilder.DropTable(
                name: "DateMedicale");

            migrationBuilder.DropTable(
                name: "IstoricMedicals");
        }
    }
}
