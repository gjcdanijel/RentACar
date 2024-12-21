using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RentACar.Models;

namespace RentACar.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Car> Cars { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Rental> Rental { get; set; }
		public DbSet<Maintenance> Maintenance { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Starting data for Cars
			modelBuilder.Entity<Car>().HasData(
				new Car
				{
					Id = 1,
					Make = "Audi",
					Model = "A4",
					ManufactureYear = 2015,
					Fuel = "Diesel"
				},
				new Car
				{
					Id = 2,
					Make = "BMW",
					Model = "X5",
					ManufactureYear = 2018,
					Fuel = "Diesel"
				}
				);

			//Starting data for Customers
			modelBuilder.Entity<Customer>().HasData(
				new Customer
				{
					Id = 1,
					FirstName = "John",
					LastName = "Jones",
					Email = "johnjones@email.com",
					Address = "123 Main Street",
					Phone = "123-456-7890"
				},
				new Customer
				{
					Id = 2,
					FirstName = "Dana",
					LastName = "White",
					Email = "danawhite@email.com",
					Address = "124 Main Street",
					Phone = "123-456-7891"
				}
				);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.ConfigureWarnings(warnings =>
				warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
		}
	}
}
