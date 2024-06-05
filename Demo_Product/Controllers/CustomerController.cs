using BussinessLayer.Concrete;
using BussinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Product.Controllers
{
	public class CustomerController : Controller
	{
		CustomerManager customer = new CustomerManager(new EfCustomerDal());
		JobManager jobManager = new JobManager(new EfJobDal());
		public IActionResult Index()
		{
			var value = customer.GetCustomerWithJobList();
			return View(value);
		}
		[HttpGet]
		public IActionResult Add()
		{
			
			List<SelectListItem> Values = (from x in jobManager.GetAll() select new SelectListItem { Text=x.Name, Value=x.JobId.ToString() }).ToList();
			ViewBag.v=Values;
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
			List<SelectListItem> Values = (from x in jobManager.GetAll() select new SelectListItem { Text = x.Name, Value = x.JobId.ToString() }).ToList();
			ViewBag.v = Values;
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
