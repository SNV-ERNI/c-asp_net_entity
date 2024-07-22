using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealership.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsEntities",
                columns: table => new
                {
                    VIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsEntities", x => x.VIN);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEntities",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEntities", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderEntities",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderEntities", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderEntities_CarsEntities_VIN",
                        column: x => x.VIN,
                        principalTable: "CarsEntities",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderEntities_CustomerEntities_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CustomerEntities",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistoryEntities",
                columns: table => new
                {
                    TransID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryEntities", x => x.TransID);
                    table.ForeignKey(
                        name: "FK_TransactionHistoryEntities_PurchaseOrderEntities_OrderID",
                        column: x => x.OrderID,
                        principalTable: "PurchaseOrderEntities",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderEntities_CustomerID",
                table: "PurchaseOrderEntities",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderEntities_VIN",
                table: "PurchaseOrderEntities",
                column: "VIN");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryEntities_OrderID",
                table: "TransactionHistoryEntities",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionHistoryEntities");

            migrationBuilder.DropTable(
                name: "PurchaseOrderEntities");

            migrationBuilder.DropTable(
                name: "CarsEntities");

            migrationBuilder.DropTable(
                name: "CustomerEntities");
        }
    }
}
