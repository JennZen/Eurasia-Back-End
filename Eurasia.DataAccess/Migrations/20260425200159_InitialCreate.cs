using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eurasia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FlagUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GeographicalSize = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryContinents",
                columns: table => new
                {
                    ContinentsId = table.Column<int>(type: "int", nullable: false),
                    CountriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryContinents", x => new { x.ContinentsId, x.CountriesId });
                    table.ForeignKey(
                        name: "FK_CountryContinents_Continents_ContinentsId",
                        column: x => x.ContinentsId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryContinents_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLanguages",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLanguages", x => new { x.CountriesId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_CountryLanguages_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryLanguages_Language_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegions",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    RegionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegions", x => new { x.CountriesId, x.RegionsId });
                    table.ForeignKey(
                        name: "FK_CountryRegions_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRegions_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Continents_Name",
                table: "Continents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryContinents_CountriesId",
                table: "CountryContinents",
                column: "CountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguages_LanguagesId",
                table: "CountryLanguages",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegions_RegionsId",
                table: "CountryRegions",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_Name",
                table: "Language",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Name",
                table: "Regions",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryContinents");

            migrationBuilder.DropTable(
                name: "CountryLanguages");

            migrationBuilder.DropTable(
                name: "CountryRegions");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
