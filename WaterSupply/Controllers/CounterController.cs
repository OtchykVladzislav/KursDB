using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WaterSupply.Models;

namespace WaterSupply.Controllers
{
    public class CounterController : Controller
    {
        private readonly WaterSupplyContext db;

        public CounterController(WaterSupplyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = db.Counters.First(x => x.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Counter item)
        {
            if (ModelState.IsValid && CheckCounter(item))
            {
                try
                {
                    db.Counters.Update(item);
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
        public IActionResult Delete(Counter item)
        {
            if (ModelState.IsValid && CheckCounter(item))
            {
                db.Counters.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mark = db.Counters.First(org => org.Id == id);
            return View(mark);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(SelectCounters(db.Counters.ToList()));
            }
            var list = SelectCounters(db.Counters.ToList())
                .Where(x => x.Mark.ToLower().Contains(search.ToLower()));
            return View(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(SelectCounters(db.Counters.ToList()));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Counter item)
        {
            if (ModelState.IsValid && CheckCounter(item))
            {
                try
                {
                    db.Counters.Add(item);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Index", "Counter");
        }

        public IEnumerable<CounterVM> SelectCounters(IEnumerable<Counter> source)
        {
            return source.Select(x => new CounterVM()
            {
                Id = x.Id,
                Mark = db.CounterMarks.First(mark => mark.Id == x.MarkId).Name,
                Organization = db.Organizations.First(org => org.Id == x.OrganizationId).Name,
                SetupDate = x.SetupDate,
                SetupPlace = x.SetupPlace
            });
        }

        public bool CheckCounter(Counter item)
        {
            if (db.Organizations.Any(x => x.Id == item.OrganizationId) && db.CounterMarks.Any(x => x.Id == item.MarkId))
            {
                return true;
            }
            return false;
        }
    }
}
