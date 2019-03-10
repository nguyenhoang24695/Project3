using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NgoProjectk3.DataContext;

namespace NgoProjectk3.Controllers
{
    public class HomeController : Controller
    {
        private NgoProjectk3Context db = new NgoProjectk3Context();
        // GET: Home
        public ActionResult Index()
        {
            var donatePrograms = db.DonatePrograms;
            return View(donatePrograms.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}