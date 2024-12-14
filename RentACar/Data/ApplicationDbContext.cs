using Microsoft.EntityFrameworkCore;
using RentACar.Models;

namespace RentACar.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Car> Cars { get; set; }
	}
}
