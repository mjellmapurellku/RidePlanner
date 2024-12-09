using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RidePlanner.Migrations
{
    /// <inheritdoc />
    public partial class TaxiBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxi_TaxiCompanies_TaxiCompanyId",
                table: "Taxi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taxi",
                table: "Taxi");

            migrationBuilder.RenameTable(
                name: "Taxi",
                newName: "Taxis");

            migrationBuilder.RenameIndex(
                name: "IX_Taxi_TaxiCompanyId",
                table: "Taxis",
                newName: "IX_Taxis_TaxiCompanyId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Taxis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taxis",
                table: "Taxis",
                column: "TaxiId");

            migrationBuilder.CreateTable(
                name: "TaxiBookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxiCompanyId = table.Column<int>(type: "int", nullable: false),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropoffLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PassengerCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TaxiId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiBookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_TaxiBookings_TaxiCompanies_TaxiCompanyId",
                        column: x => x.TaxiCompanyId,
                        principalTable: "TaxiCompanies",
                        principalColumn: "TaxiCompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxiBookings_Taxis_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "Taxis",
                        principalColumn: "TaxiId");
                    table.ForeignKey(
                        name: "FK_TaxiBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxiReservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxiId = table.Column<int>(type: "int", nullable: false),
                    TaxiCompanyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PickupLocation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DropoffLocation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerCount = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiReservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_TaxiReservations_TaxiCompanies_TaxiCompanyId",
                        column: x => x.TaxiCompanyId,
                        principalTable: "TaxiCompanies",
                        principalColumn: "TaxiCompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxiReservations_Taxis_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "Taxis",
                        principalColumn: "TaxiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxiReservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    TaxiBookingBookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_TaxiBookings_TaxiBookingBookingId",
                        column: x => x.TaxiBookingBookingId,
                        principalTable: "TaxiBookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TaxiBookingBookingId",
                table: "Notifications",
                column: "TaxiBookingBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiBookings_TaxiCompanyId",
                table: "TaxiBookings",
                column: "TaxiCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiBookings_TaxiId",
                table: "TaxiBookings",
                column: "TaxiId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiBookings_UserId",
                table: "TaxiBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiReservations_TaxiCompanyId",
                table: "TaxiReservations",
                column: "TaxiCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiReservations_TaxiId",
                table: "TaxiReservations",
                column: "TaxiId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxiReservations_UserId",
                table: "TaxiReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxis_TaxiCompanies_TaxiCompanyId",
                table: "Taxis",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxis_TaxiCompanies_TaxiCompanyId",
                table: "Taxis");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "TaxiReservations");

            migrationBuilder.DropTable(
                name: "TaxiBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Taxis",
                table: "Taxis");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Taxis");

            migrationBuilder.RenameTable(
                name: "Taxis",
                newName: "Taxi");

            migrationBuilder.RenameIndex(
                name: "IX_Taxis_TaxiCompanyId",
                table: "Taxi",
                newName: "IX_Taxi_TaxiCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taxi",
                table: "Taxi",
                column: "TaxiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxi_TaxiCompanies_TaxiCompanyId",
                table: "Taxi",
                column: "TaxiCompanyId",
                principalTable: "TaxiCompanies",
                principalColumn: "TaxiCompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
