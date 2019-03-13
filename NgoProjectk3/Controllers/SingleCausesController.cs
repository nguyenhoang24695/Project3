using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgoProjectk3.Controllers
{
    public class SingleCausesController : Controller
    {
        // GET: SingleCauses
        public ActionResult Index()
        {
            return View();
        }

        // GET: SingleCauses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SingleCauses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingleCauses/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SingleCauses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SingleCauses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SingleCauses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SingleCauses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
