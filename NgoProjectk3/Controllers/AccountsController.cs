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
using SecurityHandle;

namespace NgoProjectk3.Controllers
{
    public class AccountsController : Controller
    {
        private NgoProjectk3Context db = new NgoProjectk3Context();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,FullName,Gender,Address,BirthDay,Email,Phone")] Account account)
        {
            account.Salt = PasswordHandle.GetInstance().GenerateSalt();
            account.Password = PasswordHandle.GetInstance().EncryptPassword(account.Password, account.Salt);
            //return Json(account);
            if (ModelState.IsValid)
            {
                //return Json(account);
                db.Accounts.Add(account);
                //return Json(account);
                db.SaveChanges();
                return RedirectToAction("/");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,Salt,Role,Status,FullName,Gender,Address,BirthDay,Email,Phone,CreatedAt,UpdatedAt,DeletedAt")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserName,Password")] Account account)
        {
            
            var existAccount = db.Accounts.FirstOrDefault(a => a.UserName == account.UserName);
            if (existAccount != null)
            {
                account.Password = SecurityHandle.PasswordHandle.GetInstance()
                    .EncryptPassword(account.Password, existAccount.Salt);
                if (existAccount.Password == account.Password)
                {
                    var cr = new Credential();
                    cr.AccessToken = SecurityHandle.TokenHandle.GetInstance().GenerateToken();
                    cr.OwnerId = existAccount.Id;
                    db.Credentials.Add(cr);
                    db.SaveChanges();
                    
                    return Json(cr);
                }
                return Json("Wrong Password");
            }
            return Json("Tài khoản không tồn tại");
            
            if (ModelState.IsValid)
            {
                //return Json(account);
                db.Accounts.Add(account);
                //return Json(account);
                db.SaveChanges();
                return RedirectToAction("/Home");
            }

            return View(account);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CheckLogin([Bind(Include = "AccessToken")] Credential cr)
        {
            var currenCr = db.Credentials.SingleOrDefault(c => c.AccessToken == cr.AccessToken);
            var currentAccount = db.Accounts.SingleOrDefault(a => a.Id == currenCr.OwnerId);
            if (currentAccount != null)
            {
                Response.StatusCode = (int) HttpStatusCode.OK;
                return Json(currentAccount);
            }

            return HttpNotFound();
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
