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
			List<Customer> Customers = _db.Customers.ToList();
			return View(Customers);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Customer obj)
		{
			_db.Customers.Add(obj);
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
			Customer? customer = _db.Customers.Find(id);

			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}
		[HttpPost]
		public IActionResult Edit(Customer customer)
		{
			if (customer == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				_db.Customers.Update(customer);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(customer);
		}
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == 0 || id == null)
			{
				return NotFound();
			}

			Customer? customer = _db.Customers.Include(c => c.Rental).FirstOrDefault(c => c.Id == id);

			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Customer customer)
		{
			var customerToDelete = _db.Customers
								 .Include(c => c.Rental)
								 .FirstOrDefault(c => c.Id == customer.Id);

			if (customerToDelete == null)
			{
				return NotFound();
			}

			if (customerToDelete.Rental != null)
			{
				_db.Rentals.Remove(customerToDelete.Rental);
			}


			_db.Customers.Remove(customerToDelete);

			_db.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}

