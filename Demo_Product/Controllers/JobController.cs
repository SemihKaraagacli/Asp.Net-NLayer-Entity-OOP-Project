using BussinessLayer.Concrete;
using BussinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var values = jobManager.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(Job job)
        {

            jobManager.TInsert(job);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var byId = jobManager.GetById(id);
            jobManager.TDelete(byId);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = jobManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Job job)
        {
            jobManager.TUpdate(job);
            return RedirectToAction("Index");
        }
    }
}
