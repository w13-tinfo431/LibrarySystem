using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.DAL;
using LibrarySystem.Models;

namespace LibrarySystem.Controllers
{
    public class ConsumerController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Consumer
        public ActionResult Index()
        {
            return View(db.Consumers.ToList());
        }

        // GET: Consumer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // GET: Consumer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consumer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsumerID,FirstName,LastName")] Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                db.Consumers.Add(consumer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consumer);
        }

        // GET: Consumer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // POST: Consumer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsumerID,FirstName,LastName")] Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consumer);
        }

        // GET: Consumer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        // POST: Consumer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumer consumer = db.Consumers.Find(id);
            db.Consumers.Remove(consumer);
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
