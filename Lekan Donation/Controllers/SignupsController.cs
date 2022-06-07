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
    public class SignupsController : Controller
    {
        private Lekan_DonationEntities2 db = new Lekan_DonationEntities2();

        // GET: Signups
        public ActionResult Index()
        {
            return View(db.Signups.ToList());
        }

        // GET: Signups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signup signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // GET: Signups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Signups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_name,Last_name,Age,Gender,E_mail,phone_no,Address,DOB,Nationality")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Signups.Add(signup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(signup);
        }

        // GET: Signups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signup signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: Signups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_name,Last_name,Age,Gender,E_mail,phone_no,Address,DOB,Nationality")] Signup signup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(signup);
        }

        // GET: Signups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Signup signup = db.Signups.Find(id);
            if (signup == null)
            {
                return HttpNotFound();
            }
            return View(signup);
        }

        // POST: Signups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Signup signup = db.Signups.Find(id);
            db.Signups.Remove(signup);
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
