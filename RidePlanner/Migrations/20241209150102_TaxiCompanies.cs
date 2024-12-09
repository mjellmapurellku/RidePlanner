using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RidePlanner.Migrations
{
    /// <inheritdoc />
    public partial class TaxiCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxiCompanies",
                columns: table => new
                {
                    TaxiCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiCompanies", x => x.TaxiCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    TaxiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxiCompanyId = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxi", x => x.TaxiId);
                    table.ForeignKey(
                        name: "FK_Taxi_TaxiCompanies_TaxiCompanyId",
                        column: x => x.TaxiCompanyId,
                        principalTable: "TaxiCompanies",
                        principalColumn: "TaxiCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxi_TaxiCompanyId",
                table: "Taxi",
                column: "TaxiCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxi");

            migrationBuilder.DropTable(
                name: "TaxiCompanies");
        }
    }
}
