using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Truck_Loading_Application.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TruckDriver",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckDriver", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "CargoRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TransportationNeeds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoRequest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_CargoRequest_ApplicationUser_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ApplicationUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    TruckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AxleLoad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmptyWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLoadWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceStatus = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.TruckId);
                    table.ForeignKey(
                        name: "FK_Truck_TruckDriver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "TruckDriver",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Fragility = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HazardousMaterial = table.Column<bool>(type: "bit", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    CargoRequestRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoItem", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CargoItem_CargoRequest_CargoRequestRequestId",
                        column: x => x.CargoRequestRequestId,
                        principalTable: "CargoRequest",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckAssignments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckUtilization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TruckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TruckRoute",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckId = table.Column<int>(type: "int", nullable: false),
                    TravelRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedTravelTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckRoute", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_TruckRoute_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TruckRouteRouteId = table.Column<int>(type: "int", nullable: false),
                    CargoRequestRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trip_CargoRequest_CargoRequestRequestId",
                        column: x => x.CargoRequestRequestId,
                        principalTable: "CargoRequest",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_TruckRoute_TruckRouteRouteId",
                        column: x => x.TruckRouteRouteId,
                        principalTable: "TruckRoute",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "TruckId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoItem_CargoRequestRequestId",
                table: "CargoItem",
                column: "CargoRequestRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoRequest_ClientId",
                table: "CargoRequest",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_TruckId",
                table: "Report",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_CargoRequestRequestId",
                table: "Trip",
                column: "CargoRequestRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TruckId",
                table: "Trip",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TruckRouteRouteId",
                table: "Trip",
                column: "TruckRouteRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Truck_DriverId",
                table: "Truck",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckRoute_TruckId",
                table: "TruckRoute",
                column: "TruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoItem");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "CargoRequest");

            migrationBuilder.DropTable(
                name: "TruckRoute");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "TruckDriver");
        }
    }
}
