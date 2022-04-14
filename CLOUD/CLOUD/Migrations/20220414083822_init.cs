using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Judete",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Jud = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medici",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TipMedic = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medici_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacienti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nume = table.Column<string>(type: "text", nullable: false),
                    Prenume = table.Column<string>(type: "text", nullable: false),
                    Varsta = table.Column<short>(type: "smallint", nullable: false),
                    CNP = table.Column<string>(type: "text", nullable: false),
                    JudetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Localitate = table.Column<string>(type: "text", nullable: false),
                    Numar = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Profestie = table.Column<string>(type: "text", nullable: false),
                    LocDeMunca = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacienti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacienti_Judete_JudetId",
                        column: x => x.JudetId,
                        principalTable: "Judete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacienti_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateMedicale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    IstoricMedical = table.Column<string>(type: "text", nullable: false),
                    Alergii = table.Column<List<string>>(type: "text[]", nullable: false),
                    ConsulatatiiCardiologice = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMedicale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateMedicale_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ecg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valori = table.Column<List<float>>(type: "real[]", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecg_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicPacienti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicPacienti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicPacienti_Medici_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicPacienti_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valoare = table.Column<float>(type: "real", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Puls_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperatura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valoare = table.Column<int>(type: "integer", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatura_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Umiditate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valoare = table.Column<float>(type: "real", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umiditate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Umiditate_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValoriNormaleSenzori",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PacientId = table.Column<Guid>(type: "uuid", nullable: false),
                    TemperaturaMinima = table.Column<int>(type: "integer", nullable: false),
                    TemperaturaMaxima = table.Column<int>(type: "integer", nullable: false),
                    UmiditateMinima = table.Column<int>(type: "integer", nullable: false),
                    UmiditateMaxima = table.Column<int>(type: "integer", nullable: false),
                    PulsMinim = table.Column<int>(type: "integer", nullable: false),
                    PulsMaxim = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoriNormaleSenzori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValoriNormaleSenzori_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateMedicale_PacientId",
                table: "DateMedicale",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecg_PacientId",
                table: "Ecg",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medici_UserId",
                table: "Medici",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicPacienti_MedicId",
                table: "MedicPacienti",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicPacienti_PacientId",
                table: "MedicPacienti",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_JudetId",
                table: "Pacienti",
                column: "JudetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_UserId",
                table: "Pacienti",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Puls_PacientId",
                table: "Puls",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatura_PacientId",
                table: "Temperatura",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Umiditate_PacientId",
                table: "Umiditate",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValoriNormaleSenzori_PacientId",
                table: "ValoriNormaleSenzori",
                column: "PacientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateMedicale");

            migrationBuilder.DropTable(
                name: "Ecg");

            migrationBuilder.DropTable(
                name: "MedicPacienti");

            migrationBuilder.DropTable(
                name: "Puls");

            migrationBuilder.DropTable(
                name: "Temperatura");

            migrationBuilder.DropTable(
                name: "Umiditate");

            migrationBuilder.DropTable(
                name: "ValoriNormaleSenzori");

            migrationBuilder.DropTable(
                name: "Medici");

            migrationBuilder.DropTable(
                name: "Pacienti");

            migrationBuilder.DropTable(
                name: "Judete");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
