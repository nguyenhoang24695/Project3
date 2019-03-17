using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NgoProjectk3.DataContext;
using NgoProjectk3.Models;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using HttpResponse = BraintreeHttp.HttpResponse;

namespace NgoProjectk3.Controllers
{
    public class DonationsController : Controller
    {
        private NgoProjectk3Context db = new NgoProjectk3Context();

        // GET: Donations
        public ActionResult Index()
        {
            return View(db.Donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.DonorId = new SelectList(db.Accounts, "Id", "FullName");
            try
            {
                var id = int.Parse(Request.QueryString["donateProgramId"]);
                var donateProgram = db.DonatePrograms.SingleOrDefault(dp => dp.Id == id);
                if (donateProgram != null)
                {
                    ViewBag.DonateProgram = donateProgram;
                    return View();
                }
                
            }
            catch (Exception e)
            {
                return Redirect("/");
            }

            ;

            return Redirect("/");
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DonorId,ProgramId,Amount,Status,CreatedAt,UpdatedAt,DeletedAt")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                var currentProgram = db.DonatePrograms.Find(donation.ProgramId);
                currentProgram.DonatedMoney += (long)donation.Amount;
                db.DonatePrograms.AddOrUpdate(currentProgram);
                await db.SaveChangesAsync();
                return Redirect("/");
            }

            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonorId,ProgramId,Amount,Status,CreatedAt,UpdatedAt,DeletedAt")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


       
        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> PaypalResponse([Bind(Include = "OrderID")] Paypal paypal)
        {
            string username = "AcigcYMYURz24hIUQyQFMlO-mG93g4KpO-P1l2SZOYW3ZIH2CV-Hy20QjJz0YkLedaqO9VHL2ylh8p8Y";
            string password = "ECBwMwy6PMS9njelhXRAp2_ExRHDEJ0dr6qTMIrA43QCz1l3MpvDI20ZYWkf1Cz32Vl3-gidqf5e4jDk";
            // 1b. Point your server to the PayPal API
            var PAYPAL_OAUTH_API = "https://api.sandbox.paypal.com/v1/oauth2/token";
            var PAYPAL_ORDER_API = "https://api.sandbox.paypal.com/v2/checkout/orders/";
            var plainTextBytes = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(username + ":" + password));
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + plainTextBytes);
            var dict = new Dictionary<string, string>();
            dict.Add("grant_type", "client_credentials");
            //var req = new HttpRequestMessage(HttpMethod.Post, PAYPAL_OAUTH_API) { Content = new FormUrlEncodedContent(dict) };
            //var content = client.SendAsync(req).Result.Content.ReadAsStringAsync();
            var resultAuth = await client.PostAsync(PAYPAL_OAUTH_API, new FormUrlEncodedContent(dict));
            //JObject json = JObject.Parse(JsonConvert.SerializeObject(resultAuth.Content.));
            var paypalAccess = JsonConvert.DeserializeObject<PaypalAccess>(resultAuth.Content.ReadAsStringAsync().Result);
            //return Json(paypalAccess);
            //
            HttpClient clientOrder = new HttpClient();
            clientOrder.DefaultRequestHeaders.Add("Authorization", "Bearer " + paypalAccess.access_token);
            var OrderInfo = clientOrder.GetAsync(PAYPAL_ORDER_API + paypal.OrderID).Result.Content.ReadAsStringAsync().Result;
            var a = JObject.Parse(OrderInfo);
            if (a["status"].ToString() == "COMPLETED")
            {
                Response.StatusCode = (int) HttpStatusCode.OK;
                return Json("OK");
            }
            Response.StatusCode = (int) HttpStatusCode.Forbidden;
            return Json(a["status"].ToString());


            //////////////////////////////////////////////////////////////////
            ///// 

            ////return Json(paypal);

            //OrdersGetRequest request = new OrdersGetRequest(paypal.OrderID);
            //request.Headers.Add("prefer", "return=representation");

            ////3. Call PayPal to get the transaction
            ////var response = await PaypalClient.client().Execute(request);
            //var response = await (new PayPalHttpClient(new SandboxEnvironment("AcigcYMYURz24hIUQyQFMlO-mG93g4KpO-P1l2SZOYW3ZIH2CV-Hy20QjJz0YkLedaqO9VHL2ylh8p8Y",
            //    "ECBwMwy6PMS9njelhXRAp2_ExRHDEJ0dr6qTMIrA43QCz1l3MpvDI20ZYWkf1Cz32Vl3-gidqf5e4jDk"))).Execute(request);
            ////4. Save the transaction in your database. Implement logic to save transaction to your database for future reference.
            //var result = response.Result<Order>();
            ////Console.WriteLine("Retrieved Order Status");
            ////Console.WriteLine("Status: {0}", result.Status);
            ////Console.WriteLine("Order Id: {0}", result.Id);
            ////Console.WriteLine("Intent: {0}", result.Intent);
            ////Console.WriteLine("Links:");
            ////foreach (LinkDescription link in result.Links)
            ////{
            ////    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
            ////}
            ////AmountWithBreakdown amount = result.PurchaseUnits[0].Amount;
            ////Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);

            //return Json(result);
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
