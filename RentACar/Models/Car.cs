using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
	public class Car
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public string Make { get; set; }
		[Required]
		public int ManufactureYear { get; set; }
		[Required]
		public string Fuel { get; set; }
		public bool isAvailable { get; set; } = true;

		// FK
		[ForeignKey("Rental")]
		public int RentalId;
		[ForeignKey("Maintenance")]
		public int MaintenanceId;

		// Navigation Properties
		public Rental Rental { get; set; }
		public Maintenance Maintenance { get; set; }

	}
}
