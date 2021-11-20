using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WaterSupply.Models;

namespace WaterSupply.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly WaterSupplyContext db;

        public OrganizationController(WaterSupplyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var org = db.Organizations.First(x => x.Id == id);

            return View(org);
        }

        [HttpPost]
        public IActionResult Update(Organization organization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Organizations.Update(organization);
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
        public IActionResult Delete(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Organizations.Remove(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var organization = db.Organizations.First(org => org.Id == id);
            return View(organization);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            if (search == null)
            {
                return View(db.Organizations.ToList());
            }
            var list = db.Organizations.Where(x => x.Name.ToLower().Contains(search.ToLower()));
            return View(list);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Organizations.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Organizations.Add(organization);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
            }

            return RedirectToAction("Index", "Organization");
        }
    }
}
