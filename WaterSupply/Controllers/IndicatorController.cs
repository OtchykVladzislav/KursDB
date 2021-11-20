using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WaterSupply.Models;

namespace WaterSupply.Controllers
{
    public class IndicatorController : Controller
    {
        private readonly WaterSupplyContext db;

        public IndicatorController(WaterSupplyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.Indicators.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Indicator item)
        {
            if (ModelState.IsValid && CheckIndicator(item))
            {
                try
                {
                    db.Indicators.Update(item);
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
        public IActionResult Delete(Indicator item)
        {
            if (ModelState.IsValid && CheckIndicator(item))
            {
                db.Indicators.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.Indicators.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search != null && int.TryParse(search, out int res))
            {

                var list = db.Indicators.ToList()
                    .Where(x => x.Value >= res);
                return View(list);
            }
            return View(db.Indicators.ToList());
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Indicators.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Indicator item)
        {
            if (ModelState.IsValid && CheckIndicator(item))
            {
                try
                {
                    db.Indicators.Add(item);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Index", "Indicator");
        }

        public bool CheckIndicator(Indicator item)
        {
            if (db.Counters.Any(x => x.Id == item.TargetId))
            {
                return true;
            }
            return false;
        }
    }
}
