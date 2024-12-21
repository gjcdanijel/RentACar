using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Phone { get; set; }
		[Required]
		public string Address { get; set; }
		
		[ForeignKey("Rental")]
		public int? RentalId { get; set; }
		// Navigation property
		public Rental? Rental { get; set; }
	}
}
