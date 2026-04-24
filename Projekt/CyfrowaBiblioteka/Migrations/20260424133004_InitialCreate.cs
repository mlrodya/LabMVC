using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyfrowaBiblioteka.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tytul = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RokWydania = table.Column<int>(type: "INTEGER", nullable: false),
                    Gatunek = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    AutorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ksiazka_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OsobaWypozyczajaca = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataWypozyczenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataZwrotu = table.Column<DateTime>(type: "TEXT", nullable: true),
                    KsiazkaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wypozyczenie_Ksiazka_KsiazkaId",
                        column: x => x.KsiazkaId,
                        principalTable: "Ksiazka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_AutorId",
                table: "Ksiazka",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenie_KsiazkaId",
                table: "Wypozyczenie",
                column: "KsiazkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wypozyczenie");

            migrationBuilder.DropTable(
                name: "Ksiazka");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
