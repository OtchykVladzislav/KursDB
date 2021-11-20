using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WaterSupply.Models;

namespace WaterSupply.Controllers
{
    public class CheckController : Controller
    {
        private readonly WaterSupplyContext db;

        public CheckController(WaterSupplyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.IndicatorChecks.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(IndicatorCheck item)
        {
            if (ModelState.IsValid && CheckIndicator(item))
            {
                try
                {
                    db.IndicatorChecks.Update(item);
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
        public IActionResult Delete(IndicatorCheck item)
        {
            if (ModelState.IsValid && CheckIndicator(item))
            {
                db.IndicatorChecks.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.IndicatorChecks.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search != null && DateTime.TryParse(search, out DateTime res))
            {

                var list = db.IndicatorChecks.ToList()
                    .Where(x => x.Date == res);
                return View(list);
            }
            return View(db.IndicatorChecks.ToList());
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.IndicatorChecks.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IndicatorCheck item)
        {
            if (ModelState.IsValid && CheckIndicator(item))
            {
                try
                {
                    db.IndicatorChecks.Add(item);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Index", "Check");
        }

        public bool CheckIndicator(IndicatorCheck item)
        {
            if (db.Indicators.Any(x => x.Id == item.IndicatorId))
            {
                return true;
            }
            return false;
        }
    }
}
