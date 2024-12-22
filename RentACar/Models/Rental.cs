using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
	public class Rental
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		//[Range(typeof(DateTime), "2023-12-22", "2050-12-31", ErrorMessage = "Invalid start date")]
		public DateTime StartDate { get; set; } = DateTime.Now;
		//[Range(typeof(DateTime), "2023-12-22", "2050-12-31", ErrorMessage = "Invalid end date")]
		public DateTime EndDate { get; set; }
		[Range(0, double.MaxValue, ErrorMessage = "The price must be a positive number.")]
		public float PricePerDay { get; set; }
		public float TotalPrice { get; set; }

		[ForeignKey("Car")]
		public int? CarId { get; set; }
		[ForeignKey("Customer")]
		public int? CustomerId { get; set; }

		//Navigation properties
		public Car? Car { get; set; }
		public Customer? Customer { get; set; }

	}
}
