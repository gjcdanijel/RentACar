using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			List<Maintenance> Maintenances = _db.Maintenance.ToList();
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
				_db.Maintenance.Add(maintenance);

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
	}
}
