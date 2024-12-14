using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Migrations
{
	public partial class Tabels : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Cars",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ManufactureYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
					isAvailable = table.Column<bool>(type: "bit", nullable: false),
					RentalId = table.Column<int>(type: "int", nullable: false),
					MaintenanceId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Cars", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Maintenance",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CarId = table.Column<int>(type: "int", nullable: false),
					Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Cost = table.Column<float>(type: "real", nullable: false),
					MaitenanceDate = table.Column<DateOnly>(type: "date", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Maintenance", x => x.Id);
					table.ForeignKey(
						name: "FK_Maintenance_Cars_CarId",
						column: x => x.CarId,
						principalTable: "Cars",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict); // Promenjeno sa Cascade na Restrict
				});

			migrationBuilder.CreateTable(
				name: "Customer",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
					RentalId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Customer", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Rental",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StartDate = table.Column<DateOnly>(type: "date", nullable: false),
					EndDate = table.Column<DateOnly>(type: "date", nullable: false),
					PricePerDay = table.Column<float>(type: "real", nullable: false),
					TotalPrice = table.Column<float>(type: "real", nullable: false),
					CarId = table.Column<int>(type: "int", nullable: false),
					CustomerId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Rental", x => x.Id);
					table.ForeignKey(
						name: "FK_Rental_Cars_CarId",
						column: x => x.CarId,
						principalTable: "Cars",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict); // Promenjeno sa Cascade na Restrict
					table.ForeignKey(
						name: "FK_Rental_Customer_CustomerId",
						column: x => x.CustomerId,
						principalTable: "Customer",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict); // Promenjeno sa Cascade na Restrict
				});

			migrationBuilder.CreateIndex(
				name: "IX_Cars_MaintenanceId",
				table: "Cars",
				column: "MaintenanceId");

			migrationBuilder.CreateIndex(
				name: "IX_Cars_RentalId",
				table: "Cars",
				column: "RentalId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Customer_RentalId",
				table: "Customer",
				column: "RentalId");

			migrationBuilder.CreateIndex(
				name: "IX_Maintenance_CarId",
				table: "Maintenance",
				column: "CarId");

			migrationBuilder.CreateIndex(
				name: "IX_Rental_CarId",
				table: "Rental",
				column: "CarId");

			migrationBuilder.CreateIndex(
				name: "IX_Rental_CustomerId",
				table: "Rental",
				column: "CustomerId");

			migrationBuilder.AddForeignKey(
				name: "FK_Cars_Maintenance_MaintenanceId",
				table: "Cars",
				column: "MaintenanceId",
				principalTable: "Maintenance",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict); // Promenjeno sa Cascade na Restrict

			migrationBuilder.AddForeignKey(
				name: "FK_Cars_Rental_RentalId",
				table: "Cars",
				column: "RentalId",
				principalTable: "Rental",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict); // Promenjeno sa Cascade na Restrict

			migrationBuilder.AddForeignKey(
				name: "FK_Customer_Rental_RentalId",
				table: "Customer",
				column: "RentalId",
				principalTable: "Rental",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict); // Promenjeno sa Cascade na Restrict
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Cars_Maintenance_MaintenanceId",
				table: "Cars");

			migrationBuilder.DropForeignKey(
				name: "FK_Cars_Rental_RentalId",
				table: "Cars");

			migrationBuilder.DropForeignKey(
				name: "FK_Customer_Rental_RentalId",
				table: "Customer");

			migrationBuilder.DropTable(
				name: "Maintenance");

			migrationBuilder.DropTable(
				name: "Rental");

			migrationBuilder.DropTable(
				name: "Cars");

			migrationBuilder.DropTable(
				name: "Customer");
		}
	}
}
