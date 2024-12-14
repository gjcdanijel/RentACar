using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
	public class Rental
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public DateOnly EndDate { get; set; }
		public float PricePerDay { get; set; }
		public float TotalPrice { get; set; }

		[ForeignKey("Car")]
		public int CarId { get; set; }
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		//Navigation properties
		public Car Car { get; set; }
		public Customer Customer { get; set; }

	}
}
