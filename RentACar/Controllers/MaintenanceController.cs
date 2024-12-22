using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;

namespace RentACar.Controllers
{
	public class MaintenanceController : Controller
	{
		private readonly ApplicationDbContext _db;

		public MaintenanceController(ApplicationDbContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			List<Maintenance> Maintenances = _db.Maintenances
				.Include(m => m.Car)
				.ToList();

			return View(Maintenances);
		}
		public ActionResult Add()
		{
			ViewBag.Cars = _db.Cars
				.Select(c => new SelectListItem
				{
					Value = c.Id.ToString(),
					Text = $"{c.Make} {c.Model} {c.ManufactureYear}"
				})
				.ToList();
			return View(new Maintenance());
		}
		[HttpPost]
		public ActionResult Add(Maintenance maintenance)
		{
			if (ModelState.IsValid)
			{
				_db.Maintenances.Add(maintenance);

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

			return View(maintenance);
		}
		public IActionResult Edit(int id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Maintenance? maintenance = _db.Maintenances
				.Include(m => m.Car)
				.FirstOrDefault(m => m.Id == id);

			if (maintenance == null)
			{
				return NotFound();
			}

			ViewBag.Car = maintenance.Car;

			return View(maintenance);
		}

		[HttpPost]
		public IActionResult Edit(Maintenance maintenance)
		{
			if (maintenance == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_db.Maintenances.Update(maintenance);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(maintenance);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Maintenance? maintenance = _db.Maintenances.Include(c => c.Car).FirstOrDefault(c => c.Id == id);

			if (maintenance == null)
			{
				return NotFound();
			}

			return View(maintenance);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Maintenance maintenance)
		{
			var maintenanceToDelete = _db.Maintenances
								 .Include(c => c.Car)
								 .FirstOrDefault(c => c.Id == maintenance.Id);

			if (maintenanceToDelete == null)
			{
				return NotFound();
			}

			if (maintenanceToDelete.Car != null)
			{
				maintenanceToDelete.Car.MaintenanceId = null;
			}


			_db.Maintenances.Remove(maintenanceToDelete);

			_db.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
