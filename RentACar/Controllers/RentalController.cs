using RentACar.Models;
using RentACar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
			var rentals = _db.Rentals
		.Include(r => r.Car)
		.Include(r => r.Customer)
		.ToList();

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

			ViewBag.Customer = _db.Customers
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
				_db.Rentals.Add(rental);

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

			ViewBag.Customer = _db.Customers
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = $"{c.LastName} {c.FirstName} {c.Address} ({c.Phone})"
				})
				.ToList();

			return View(rental);
		}
		public IActionResult Edit(int id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Rental? rental = _db.Rentals
				.Include(r => r.Car)
				.Include(r => r.Customer)
				.FirstOrDefault(r => r.Id == id);

			if (rental == null || rental.Car == null || rental.Customer == null)
			{
				return NotFound();
			}

			ViewBag.Car = rental.Car;
			ViewBag.Customer = rental.Customer;

			return View(rental);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Rental? rental = _db.Rentals.Include(r => r.Car).Include(r => r.Customer).FirstOrDefault(r => r.Id == id);

			if (rental == null)
			{
				return NotFound();
			}

			return View(rental);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Rental rental)
		{
			var rentalToDelete = _db.Rentals
								 .Include(c => c.Car)
								 .Include(c => c.Customer)
								 .FirstOrDefault(c => c.Id == rental.Id);

			if (rentalToDelete == null)
			{
				return NotFound();
			}

			if (rentalToDelete.Car != null)
			{
				rentalToDelete.Car.isAvailable = true;
				rentalToDelete.Car.RentalId = null; ;
			}

			if (rentalToDelete.Customer != null)
			{
				rentalToDelete.Customer.RentalId = null; ;
			}

			_db.Rentals.Remove(rentalToDelete);

			_db.SaveChanges();

			return RedirectToAction("Index");

		}
	}
}
