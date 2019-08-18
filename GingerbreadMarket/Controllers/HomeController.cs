using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GingerbreadMarket.Models;
using System.Threading;
using System.Globalization;

namespace GingerbreadMarket.Controllers
{
    public class HomeController : Controller
    {
        OrdersRepository repository = new OrdersRepository();
        public IActionResult Index()
        {
            return View(repository.GetDb());
        }

        public IActionResult Add(Order item)
        {
            if (ModelState.IsValid)
            {
                repository.Add(item);
                return RedirectToAction("Index");
            }
            else return View("Index");
        }

        public ActionResult Update(Order item)
        {
            if (ModelState.IsValid && repository.Update(item))
                return RedirectToAction("Index");
            else return View("Index");
        }

        public ActionResult RemoveDeals()
        {
            if (ModelState.IsValid)
            {
                repository.RemoveDeals();
                return RedirectToAction("Index");
            }
            else return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
