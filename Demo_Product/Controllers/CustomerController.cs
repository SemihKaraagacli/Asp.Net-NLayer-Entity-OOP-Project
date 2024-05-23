using BussinessLayer.Concrete;
using BussinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
	public class CustomerController : Controller
	{
		CustomerManager customer = new CustomerManager(new EfCustomerDal());
		public IActionResult Index()
		{
			var value = customer.GetAll();
			return View(value);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Customer c)
		{
			CustomerValidator customerValitator = new CustomerValidator();
			ValidationResult result = customerValitator.Validate(c);
			if (result.IsValid)
			{
				customer.TInsert(c);
				return RedirectToAction("Index");
			}
			else
			{
                foreach (var item in result.Errors)
                {
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();

		}
		public IActionResult Delete(int Id)
		{
			var value=customer.GetById(Id);
			customer.TDelete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Update(int Id)
		{
			var value=customer.GetById(Id);
			return View(value);
		}
		[HttpPost]
		public IActionResult Update(Customer c)
		{
			customer.TUpdate(c);
			return RedirectToAction("Index");
		}
	}
}
