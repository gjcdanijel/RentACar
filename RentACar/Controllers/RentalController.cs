using RentACar.Models;
using RentACar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RentACar.Controllers
{
	public class RentalController : Controller
	{
		private readonly ApplicationDbContext _db;
		public RentalController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Rental> rentals = _db.Rental.ToList();
			return View(rentals);
		}
		public IActionResult Add()
		{
			ViewBag.Cars = _db.Cars
				.Where(c => c.isAvailable)
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = $"{c.Make} {c.Model} ({c.ManufactureYear})"
				})
				.ToList();

			ViewBag.Customer = _db.Customer
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = $"{c.LastName} {c.FirstName} {c.Address} ({c.Phone})"
				})
				.ToList();

			return View(new Rental()); // Mora se proslediti instanca modela u view
		}

		[HttpPost]
		public IActionResult Add(Rental rental)
		{
			if (ModelState.IsValid)
			{
				_db.Rental.Add(rental);

				var car = _db.Cars.Find(rental.CarId);
				if (car != null)
				{
					car.isAvailable = false; 
				}

				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.Cars = _db.Cars
				.Where(c => c.isAvailable)
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = $"{c.Make} {c.Model} ({c.ManufactureYear})"
				})
				.ToList();

			ViewBag.Customer = _db.Customer
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = $"{c.LastName} {c.FirstName} {c.Address} ({c.Phone})"
				})
				.ToList();

			return View(rental);
		}

	}
}
