using RentACar.Models;
using RentACar.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace RentACar.Controllers
{
	public class CarController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CarController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Car> objCars = _db.Cars.ToList();
			return View(objCars);
		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Car obj)
		{
			obj.isAvailable = true;

			_db.Cars.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			Car? car = _db.Cars.Find(id);

			if (car == null) {
				return NotFound();
			}

			return View(car);
		}
		[HttpPost]
		public IActionResult Edit(Car car)
		{
			if (car== null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{ 
				_db.Cars.Update(car);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(car);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Car? car = _db.Cars.Include(c => c.Maintenance).Include(c => c.Rental).FirstOrDefault(c => c.Id == id);

			if (car == null)
			{
				return NotFound();
			}

			return View(car);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Car car)
		{
			var carToDelete = _db.Cars
								 .Include(c => c.Maintenance)
								 .Include(c => c.Rental)
								 .FirstOrDefault(c => c.Id == car.Id);

			if (carToDelete == null)
			{
				return NotFound();
			}

			if (carToDelete.Rental != null)
			{
				carToDelete.Rental.CarId = null;;
			}

			if (carToDelete.Maintenance != null)
			{
				carToDelete.Maintenance.CarId = null; ;
			}

			_db.Cars.Remove(carToDelete);

			_db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}
