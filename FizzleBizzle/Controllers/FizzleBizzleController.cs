using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzleBizzle.Controllers
{
    public class FizzleBizzleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new FizzleBizzleModel());
        }
        

        [HttpPost]
        public ActionResult FizzBuzzBazz(int start, int end, int fizz, int buzz, int? bazz, string type)
        {
            FizzleBizzleModel FizzBizz = new FizzleBizzleModel();
            FizzBizz.Fizz = fizz;
            FizzBizz.Buzz = buzz;
            if (ModelState.IsValid)
            {
                if (bazz != null)
                {
                    Predicate<int> pred = (x => x == 0);
                    switch (type)
                    {
                        case "gt":
                            pred = (x => x > bazz);
                            break;
                        case "lt":
                            pred = (x => x < bazz);
                            break;
                        case "eq":
                            pred = (x => x == bazz);
                            break;
                    }
                    ViewBag.Result = FizzBizz.FizzBuzzBazz(start, end, pred);
                }
                else
                {
                    Predicate<int> pred = null;
                    ViewBag.Result = FizzBizz.FizzBuzzBazz(start, end, pred);
                }
            }
            return PartialView("Results");
        }
    }
}