using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.Data;
using RentACar.Models;
using System.Runtime.Remoting;
namespace RentACar.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CustomerController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Customer> Customers = _db.Customer.ToList();
			return View(Customers);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Customer obj)
		{
			_db.Customer.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
