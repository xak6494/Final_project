using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Final_Project.Controllers
{
    public class tstTicketPriortiesController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstTicketPriorties
        public ActionResult Index()
        {
            return View(db.tstTicketPriorties.ToList());
        }

        // GET: tstTicketPriorties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicketPriorty tstTicketPriorty = db.tstTicketPriorties.Find(id);
            if (tstTicketPriorty == null)
            {
                return HttpNotFound();
            }
            return View(tstTicketPriorty);
        }

        // GET: tstTicketPriorties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tstTicketPriorties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] tstTicketPriorty tstTicketPriorty)
        {
            if (ModelState.IsValid)
            {
                db.tstTicketPriorties.Add(tstTicketPriorty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tstTicketPriorty);
        }

        // GET: tstTicketPriorties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicketPriorty tstTicketPriorty = db.tstTicketPriorties.Find(id);
            if (tstTicketPriorty == null)
            {
                return HttpNotFound();
            }
            return View(tstTicketPriorty);
        }

        // POST: tstTicketPriorties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] tstTicketPriorty tstTicketPriorty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstTicketPriorty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tstTicketPriorty);
        }

        // GET: tstTicketPriorties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicketPriorty tstTicketPriorty = db.tstTicketPriorties.Find(id);
            if (tstTicketPriorty == null)
            {
                return HttpNotFound();
            }
            return View(tstTicketPriorty);
        }

        // POST: tstTicketPriorties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstTicketPriorty tstTicketPriorty = db.tstTicketPriorties.Find(id);
            db.tstTicketPriorties.Remove(tstTicketPriorty);
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
