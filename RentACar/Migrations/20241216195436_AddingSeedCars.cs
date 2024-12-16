using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACar.Migrations
{
    /// <inheritdoc />
    public partial class AddingSeedCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenance_Cars_CarId",
                table: "Maintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Cars_CarId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_Rental_Customer_CustomerId",
                table: "Rental");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MaintenanceId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rental",
                table: "Rental");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maintenance",
                table: "Maintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Rental",
                newName: "Rentals");

            migrationBuilder.RenameTable(
                name: "Maintenance",
                newName: "Maintenances");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Rental_CustomerId",
                table: "Rentals",
                newName: "IX_Rentals_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rental_CarId",
                table: "Rentals",
                newName: "IX_Rentals_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenance_CarId",
                table: "Maintenances",
                newName: "IX_Maintenances_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_RentalId",
                table: "Customers",
                newName: "IX_Customers_RentalId");

            migrationBuilder.AlterColumn<int>(
                name: "ManufactureYear",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maintenances",
                table: "Maintenances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Fuel", "MaintenanceId", "Make", "ManufactureYear", "Model", "RentalId", "isAvailable" },
                values: new object[,]
                {
                    { 1, "Diesel", 0, "Audi", 2015, "A4", 0, true },
                    { 2, "Diesel", 0, "BMW", 2018, "X5", 0, true }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "Phone", "RentalId" },
                values: new object[,]
                {
                    { 1, "123 Main Street", "johnjones@email.com", "John", "Jones", "123-456-7890", 0 },
                    { 2, "124 Main Street", "danawhite@email.com", "Dana", "White", "123-456-7891", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MaintenanceId",
                table: "Cars",
                column: "MaintenanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Maintenances_MaintenanceId",
                table: "Cars",
                column: "MaintenanceId",
                principalTable: "Maintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Rentals_RentalId",
                table: "Cars",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Rentals_RentalId",
                table: "Customers",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Cars_CarId",
                table: "Maintenances",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Maintenances_MaintenanceId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Rentals_RentalId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Rentals_RentalId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Cars_CarId",
                table: "Maintenances");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Cars_CarId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Cars_MaintenanceId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maintenances",
                table: "Maintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Rentals",
                newName: "Rental");

            migrationBuilder.RenameTable(
                name: "Maintenances",
                newName: "Maintenance");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rental",
                newName: "IX_Rental_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_CarId",
                table: "Rental",
                newName: "IX_Rental_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Maintenances_CarId",
                table: "Maintenance",
                newName: "IX_Maintenance_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_RentalId",
                table: "Customer",
                newName: "IX_Customer_RentalId");

            migrationBuilder.AlterColumn<string>(
                name: "ManufactureYear",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rental",
                table: "Rental",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maintenance",
                table: "Maintenance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_MaintenanceId",
                table: "Cars",
                column: "MaintenanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Maintenance_MaintenanceId",
                table: "Cars",
                column: "MaintenanceId",
                principalTable: "Maintenance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Rental_RentalId",
                table: "Cars",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Rental_RentalId",
                table: "Customer",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenance_Cars_CarId",
                table: "Maintenance",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Cars_CarId",
                table: "Rental",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_Customer_CustomerId",
                table: "Rental",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
