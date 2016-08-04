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
    public class tstTicketStatusController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstTicketStatus
        public ActionResult Index()
        {
            return View(db.tstTicketStatus.ToList());
        }

        // GET: tstTicketStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicketStatu tstTicketStatu = db.tstTicketStatus.Find(id);
            if (tstTicketStatu == null)
            {
                return HttpNotFound();
            }
            return View(tstTicketStatu);
        }

        // GET: tstTicketStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tstTicketStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] tstTicketStatu tstTicketStatu)
        {
            if (ModelState.IsValid)
            {
                db.tstTicketStatus.Add(tstTicketStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tstTicketStatu);
        }

        // GET: tstTicketStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicketStatu tstTicketStatu = db.tstTicketStatus.Find(id);
            if (tstTicketStatu == null)
            {
                return HttpNotFound();
            }
            return View(tstTicketStatu);
        }

        // POST: tstTicketStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] tstTicketStatu tstTicketStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstTicketStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tstTicketStatu);
        }

        // GET: tstTicketStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicketStatu tstTicketStatu = db.tstTicketStatus.Find(id);
            if (tstTicketStatu == null)
            {
                return HttpNotFound();
            }
            return View(tstTicketStatu);
        }

        // POST: tstTicketStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstTicketStatu tstTicketStatu = db.tstTicketStatus.Find(id);
            db.tstTicketStatus.Remove(tstTicketStatu);
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
