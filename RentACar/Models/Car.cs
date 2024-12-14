using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
	public class Car
	{
		public int Id { get; set; }
		[Required]
		public string Model { get; set; }
		[Required]
		public string Make { get; set; }
		[Required]
		public string ManufactureYear { get; set; }
		[Required]
		public string Fuel { get; set; }
		public bool isAvailable { get; set; } = true;
	}
}
