using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WaterSupply.Models;

namespace WaterSupply.Controllers
{
    public class MarkController : Controller
    {
        private readonly WaterSupplyContext db;

        public MarkController(WaterSupplyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var mark = db.CounterMarks.First(x => x.Id == id);

            return View(mark);
        }

        [HttpPost]
        public IActionResult Update(CounterMark mark)
        {
            if (ModelState.IsValid && mark.ServiceLife > 0)
            {
                try
                {
                    db.CounterMarks.Update(mark);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(CounterMark organization)
        {
            if (ModelState.IsValid)
            {
                db.CounterMarks.Remove(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.CounterMarks.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(db.CounterMarks.ToList());
            }
            var list = db.CounterMarks.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            return View(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.CounterMarks.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CounterMark mark)
        {
            if (ModelState.IsValid && mark.ServiceLife > 0)
            {
                try
                {
                    db.CounterMarks.Add(mark);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Index", "Mark");
        }
    }
}
