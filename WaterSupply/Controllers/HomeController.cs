using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WaterSupply.Models;

namespace WaterSupply.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WaterSupplyContext db;

        public HomeController(ILogger<HomeController> logger, WaterSupplyContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Payment()
        {
            var col = from org in db.Organizations
                      join counter in db.Counters on org.Id equals counter.OrganizationId
                      select new
                      {
                          OrganizationName = org.Name,
                          CounterId = counter.Id
                      };

            var inds = from item in col
                       join ind in db.Indicators on item.CounterId equals ind.TargetId
                       select new
                       {
                           item.OrganizationName,
                           ind.SetupDate,
                           ind.Rate,
                           ind.Value
                       };
            var data = inds.Where(x =>
                (x.SetupDate.Year == DateTime.Now.Year)
                && (x.SetupDate.Month == DateTime.Now.Month)
            );

            var groupd = data.Select(x => x.OrganizationName).Distinct();

            List<PaymentVM> result = new();
            foreach (var item in groupd)
            {
                result.Add(new PaymentVM()
                {
                    OrgName = item,
                    Value = data.Where(x => x.OrganizationName == item)
                                .Select(x => x.Rate * x.Value)
                                .Sum()
                });
            }

            return View(result);
        }

        public IActionResult OrgExpense(ExpenseVM expense)
        {
            var curDate = DateTime.Now;

            var org = db.Organizations.FirstOrDefault(x => x.Name == expense.Org);
            if (org != null)
            {
                var counters = db.Counters.Where(x => x.OrganizationId == org.Id).ToList();
                var indicators = db.Indicators.ToList().Where(x => (x.SetupDate.Year == curDate.Year)
                            && counters.Any(z => z.Id == x.TargetId)).ToList();
                expense.Value = indicators.Sum(x => x.Value * x.Rate);
                return View(expense);
            }
            return RedirectToAction("Index");
        }

        public IActionResult InputExpense()
        {
            return View();
        }

        public IActionResult InputAccounting()
        {
            return View();
        }

        public IActionResult Accounting()
        {
            return View(SelectCounters(db.Counters));
        }

        public IActionResult Counter(CounterVM counter)
        {
            if (db.Counters.Any(x => x.Id == counter.Id))
            {
                var x = db.Counters.First(c => c.Id == counter.Id);
                var vm = new CounterVM()
                {
                    Id = x.Id,
                    Mark = db.CounterMarks.First(mark => mark.Id == x.MarkId).Name,
                    Organization = db.Organizations.First(org => org.Id == x.OrganizationId).Name,
                    SetupDate = x.SetupDate,
                    SetupPlace = x.SetupPlace
                };
                if (db.Indicators.Any(x => x.TargetId == counter.Id))
                {
                    vm.LastCheck = db.Indicators.Where(x => x.TargetId == counter.Id).Max(x => x.SetupDate);
                }
                else
                {
                    vm.LastCheck = DateTime.MinValue;
                }


                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public IEnumerable<CounterVM> SelectCounters(IEnumerable<Counter> source)
        {
            var vm = source.Select(x => new CounterVM()
            {
                Id = x.Id,
                Mark = db.CounterMarks.First(mark => mark.Id == x.MarkId).Name,
                Organization = db.Organizations.First(org => org.Id == x.OrganizationId).Name,
                SetupDate = x.SetupDate,
                SetupPlace = x.SetupPlace
            }).ToList();
            for (int i = 0; i < vm.Count; i++)
            {
                if (db.Indicators.Any(x => x.TargetId == vm[i].Id))
                {
                    vm[i].LastCheck = db.Indicators.Where(x => x.TargetId == vm[i].Id).Max(x => x.SetupDate);
                }
                else
                {
                    vm[i].LastCheck = DateTime.MinValue;
                }
            }
            return vm;
        }

        public IActionResult AccountingChoose()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var curDate = DateTime.Now;

            var orgs = db.Organizations;
            var counters = orgs.Select(x => new
            {
                OrgName = x.Name,
                Counters = db.Counters.Where(z => z.OrganizationId == x.Id).ToList()
            }).ToList();

            var values = counters.Select(x => new
            {
                x.OrgName,
                Indicators = db.Indicators.ToList().Where(z => x.Counters.Any(t => t.Id == z.TargetId)).ToList()
            }).ToList();

            List<ExpenseVM> result = new();
            foreach (var item in values)
            {
                if (item.Indicators.Count() > 1)
                {
                    DateTime start = item.Indicators.Min(x => x.SetupDate);
                    DateTime end = item.Indicators.Max(x => x.SetupDate);

                    decimal value = item.Indicators.Sum(x => x.Rate * x.Value);

                    var months = (end - start).TotalDays / 30;

                    if (months >= 1)
                    {
                        value /= (decimal)months;
                    }
                    result.Add(new ExpenseVM()
                    {
                        Org = item.OrgName,
                        Value = value
                    });
                }
                else
                {
                    result.Add(new ExpenseVM()
                    {
                        Org = item.OrgName,
                        Value = item.Indicators.Sum(x => x.Rate * x.Value)
                    });
                }
            }

            return View(result);
        }

        public IActionResult InputCompanyName()
        {
            return View();
        }

        public IActionResult ExpensesChoose()
        {
            return View();
        }

        public IActionResult OrgPayment(PaymentVM payment)
        {
            if (db.Organizations.Any(x => x.Name.ToLower().Contains(payment.OrgName.ToLower())))
            {
                var org = db.Organizations.First(x => x.Name.ToLower().Contains(payment.OrgName.ToLower()));
                var counters = db.Counters.Where(x => x.OrganizationId == org.Id);

                var data = counters.Where(x =>
                (x.SetupDate.Year == DateTime.Now.Year)
                && (x.SetupDate.Month == DateTime.Now.Month));

                var inds = from item in counters
                           join ind in db.Indicators on item.Id equals ind.TargetId
                           select new
                           {
                               ind.Rate,
                               ind.Value
                           };
                payment.Value = inds.Sum(x => x.Value * x.Rate);
                return View(payment);
            }

            return RedirectToAction("Index");
        }

        public IActionResult SelectMode()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
