using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NgoProjectk3.DataContext;
using NgoProjectk3.Models;

namespace NgoProjectk3.Controllers
{
    public class DonateProgramsController : Controller
    {
        private NgoProjectk3Context db = new NgoProjectk3Context();

        // GET: DonatePrograms
        public ActionResult Index()
        {
            var donatePrograms = db.DonatePrograms.Include(d => d.Category);
            return View(donatePrograms.ToList());
        }

        // GET: DonatePrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateProgram donateProgram = db.DonatePrograms.Find(id);
            if (donateProgram == null)
            {
                return HttpNotFound();
            }
            return View(donateProgram);
        }

        // GET: DonatePrograms/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: DonatePrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,Name,Content,StartedAt,EndedAt,CreatedAt,UpdatedAt,DeletedAt")] DonateProgram donateProgram)
        {
            if (ModelState.IsValid)
            {
                db.DonatePrograms.Add(donateProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", donateProgram.CategoryId);
            return View(donateProgram);
        }

        // GET: DonatePrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateProgram donateProgram = db.DonatePrograms.Find(id);
            if (donateProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", donateProgram.CategoryId);
            return View(donateProgram);
        }

        // POST: DonatePrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,Name,Content,StartedAt,EndedAt,CreatedAt,UpdatedAt,DeletedAt")] DonateProgram donateProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donateProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", donateProgram.CategoryId);
            return View(donateProgram);
        }

        // GET: DonatePrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateProgram donateProgram = db.DonatePrograms.Find(id);
            if (donateProgram == null)
            {
                return HttpNotFound();
            }
            return View(donateProgram);
        }

        // POST: DonatePrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonateProgram donateProgram = db.DonatePrograms.Find(id);
            db.DonatePrograms.Remove(donateProgram);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
