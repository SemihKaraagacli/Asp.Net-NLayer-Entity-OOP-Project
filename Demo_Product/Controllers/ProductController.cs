using BussinessLayer.Concrete;
using BussinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var values = productManager.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult validationResult = validationRules.Validate(product);
            if (validationResult.IsValid)
            {
                productManager.TInsert(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var byId = productManager.GetById(id);
            productManager.TDelete(byId);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value=productManager.GetById(id);
            return View(value);
        }
		[HttpPost]
		public IActionResult Update(Product product)
		{
			productManager.TUpdate(product);
			return RedirectToAction("Index");
		}

	}
}
