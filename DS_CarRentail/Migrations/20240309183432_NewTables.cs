using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS_CarRentail.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationCar",
                columns: table => new
                {
                    LocationCarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    CarPriceForDay = table.Column<decimal>(type: "TEXT", nullable: false),
                    InDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OutDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCar", x => x.LocationCarId);
                    table.ForeignKey(
                        name: "FK_LocationCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationCar_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationCarId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationOrigin = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationDestination = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    From = table.Column<DateTime>(type: "TEXT", nullable: false),
                    To = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_LocationCar_LocationCarId",
                        column: x => x.LocationCarId,
                        principalTable: "LocationCar",
                        principalColumn: "LocationCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationCar_CarId",
                table: "LocationCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationCar_LocationId",
                table: "LocationCar",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocationCarId",
                table: "Reservation",
                column: "LocationCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "LocationCar");
        }
    }
}
