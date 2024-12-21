using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RentACar.Models;
using System.Reflection.Emit;

namespace RentACar.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Car> Cars { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Rental> Rentals { get; set; }
		public DbSet<Maintenance> Maintenances { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			FKOnDelete(modelBuilder);

			// Mock data za Car
			modelBuilder.Entity<Car>().HasData(
				new Car { Id = 1, Model = "A4", Make = "Audi", ManufactureYear = 2020, Fuel = "Gasoline", isAvailable = true },
				new Car { Id = 2, Model = "3 Series", Make = "BMW", ManufactureYear = 2019, Fuel = "Diesel", isAvailable = true },
				new Car { Id = 3, Model = "C-Class", Make = "Mercedes-Benz", ManufactureYear = 2021, Fuel = "Hybrid", isAvailable = false }
			);

			// Mock data za Customer sa stranim imenima
			modelBuilder.Entity<Customer>().HasData(
				new Customer { Id = 1, LastName = "Smith", FirstName = "John", Email = "john.smith@example.com", Phone = "061-123-4567", Address = "123 Main Street, London", RentalId = null },
				new Customer { Id = 2, LastName = "Dupont", FirstName = "Marie", Email = "marie.dupont@example.com", Phone = "064-987-6543", Address = "12 Rue de Paris, Paris", RentalId = null },
				new Customer { Id = 3, LastName = "Garcia", FirstName = "Carlos", Email = "carlos.garcia@example.com", Phone = "062-555-5555", Address = "45 Avenida de Madrid, Madrid", RentalId = null }
			);

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.ConfigureWarnings(warnings =>
				warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
		}
		private void FKOnDelete(ModelBuilder modelBuilder)
		{
			// Null za Rentals povezane sa Car
			modelBuilder.Entity<Car>()
				.HasOne(c => c.Maintenance)
				.WithOne(m => m.Car)
				.HasForeignKey<Maintenance>(m => m.CarId)
				.OnDelete(DeleteBehavior.SetNull);

			// Null za Rental povezane sa Car
			modelBuilder.Entity<Car>()
				.HasOne(c => c.Rental)
				.WithOne(r => r.Car)
				.HasForeignKey<Rental>(r => r.CarId)
				.OnDelete(DeleteBehavior.SetNull);

			//Null za Rental povezan sa Customer
			modelBuilder.Entity<Customer>()
				.HasOne(c => c.Rental)
				.WithOne(r => r.Customer)
				.HasForeignKey<Rental>(r => r.CustomerId)
				.OnDelete(DeleteBehavior.SetNull);

			//Null za Customer poveza sa Rentalom
			modelBuilder.Entity<Rental>()
				.HasOne(r => r.Customer)
				.WithOne(c => c.Rental)
				.HasForeignKey<Rental>(r => r.CustomerId)
				.OnDelete(DeleteBehavior.SetNull);

			// Null za Car povezan sa Maintenance
			modelBuilder.Entity<Maintenance>()
				.HasOne(m => m.Car)
				.WithOne(c => c.Maintenance)
				.HasForeignKey<Maintenance>(m => m.CarId)
				.OnDelete(DeleteBehavior.SetNull);

		}
	}
}
