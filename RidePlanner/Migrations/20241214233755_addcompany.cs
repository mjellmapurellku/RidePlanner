using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RidePlanner.Migrations
{
    /// <inheritdoc />
    public partial class addcompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusReservations_BusSchedules_ScheduleId",
                table: "BusReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusReservations_Users_UserId",
                table: "BusReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_BusRoutes_RouteId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_Buses_BusId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxiBookings_TaxiCompanies_TaxiCompanyId",
                table: "TaxiBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxiBookings_Users_UserId",
                table: "TaxiBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxiReservations_TaxiCompanies_TaxiCompanyId",
                table: "TaxiReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxis_TaxiCompanies_TaxiCompanyId",
                table: "Taxis");

            migrationBuilder.DropTable(
                name: "BusRouteAssignments");

            migrationBuilder.AddForeignKey(
                name: "FK_BusReservations_BusSchedules_ScheduleId",
                table: "BusReservations",
                column: "ScheduleId",
                principalTable: "BusSchedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusReservations_Users_UserId",
                table: "BusReservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_BusRoutes_RouteId",
                table: "BusSchedules",
                column: "RouteId",
                principalTable: "BusRoutes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_Buses_BusId",
                table: "BusSchedules",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiBookings_TaxiCompanies_TaxiCompanyId",
                table: "TaxiBookings",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiBookings_Users_UserId",
                table: "TaxiBookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiReservations_TaxiCompanies_TaxiCompanyId",
                table: "TaxiReservations",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxis_TaxiCompanies_TaxiCompanyId",
                table: "Taxis",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusReservations_BusSchedules_ScheduleId",
                table: "BusReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusReservations_Users_UserId",
                table: "BusReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_BusRoutes_RouteId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_BusSchedules_Buses_BusId",
                table: "BusSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxiBookings_TaxiCompanies_TaxiCompanyId",
                table: "TaxiBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxiBookings_Users_UserId",
                table: "TaxiBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxiReservations_TaxiCompanies_TaxiCompanyId",
                table: "TaxiReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxis_TaxiCompanies_TaxiCompanyId",
                table: "Taxis");

            migrationBuilder.CreateTable(
                name: "BusRouteAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRouteAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_BusRouteAssignments_BusRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "BusRoutes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusRouteAssignments_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusRouteAssignments_BusId",
                table: "BusRouteAssignments",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusRouteAssignments_RouteId",
                table: "BusRouteAssignments",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusReservations_BusSchedules_ScheduleId",
                table: "BusReservations",
                column: "ScheduleId",
                principalTable: "BusSchedules",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusReservations_Users_UserId",
                table: "BusReservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_BusRoutes_RouteId",
                table: "BusSchedules",
                column: "RouteId",
                principalTable: "BusRoutes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusSchedules_Buses_BusId",
                table: "BusSchedules",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiBookings_TaxiCompanies_TaxiCompanyId",
                table: "TaxiBookings",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiBookings_Users_UserId",
                table: "TaxiBookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxiReservations_TaxiCompanies_TaxiCompanyId",
                table: "TaxiReservations",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxis_TaxiCompanies_TaxiCompanyId",
                table: "Taxis",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
