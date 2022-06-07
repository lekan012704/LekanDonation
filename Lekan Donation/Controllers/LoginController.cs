using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lekan_Donation.Models;

namespace Lekan_Donation.Controllers
{
    public class LoginController : Controller
    {
        private Lekan_DonationEntities2 db = new Lekan_DonationEntities2();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.LogIns.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Pass")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                db.LogIns.Add(logIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logIn);
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Pass")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logIn);
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogIn logIn = db.LogIns.Find(id);
            db.LogIns.Remove(logIn);
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
