using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MunicipalityTaxes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    MunicipalityTitle = table.Column<string>(type: "TEXT", nullable: false),
                    TaxFrom = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TaxUp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tax = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalityTaxes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MunicipalityTaxes");
        }
    }
}
