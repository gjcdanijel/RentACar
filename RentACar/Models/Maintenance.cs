using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
	public class Maintenance
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Car")]
		public int CarId { get; set; }
		public Car Car { get; set; }

		[Required]
		public string Type { get; set; }
		public string Description { get; set; }
		[Required]
		public float Cost { get; set; } = 0f;
		public DateOnly MaitenanceDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
	}
}
