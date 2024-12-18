using RentACar.Models;
using RentACar.Data;
using Microsoft.AspNetCore.Mvc;

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

			_db.Cars.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
