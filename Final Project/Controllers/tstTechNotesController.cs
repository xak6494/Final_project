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
    public class tstTechNotesController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstTechNotes
        public ActionResult Index()
        {
            var tstTechNotes = db.tstTechNotes.Include(t => t.tstEmployee).Include(t => t.tstTicket);
            return View(tstTechNotes.ToList());
        }

        // GET: tstTechNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTechNote tstTechNote = db.tstTechNotes.Find(id);
            if (tstTechNote == null)
            {
                return HttpNotFound();
            }
            return View(tstTechNote);
        }

        // GET: tstTechNotes/Create
        public ActionResult Create()
        {
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name");
            ViewBag.TicketID = new SelectList(db.tstTickets, "ID", "TroubleDescription");
            return View();
        }

        // POST: tstTechNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TechID,TicketID,Notation,NotationDate")] tstTechNote tstTechNote)
        {
            if (ModelState.IsValid)
            {
                db.tstTechNotes.Add(tstTechNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name", tstTechNote.TechID);
            ViewBag.TicketID = new SelectList(db.tstTickets, "ID", "TroubleDescription", tstTechNote.TicketID);
            return View(tstTechNote);
        }

        // GET: tstTechNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTechNote tstTechNote = db.tstTechNotes.Find(id);
            if (tstTechNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name", tstTechNote.TechID);
            ViewBag.TicketID = new SelectList(db.tstTickets, "ID", "TroubleDescription", tstTechNote.TicketID);
            return View(tstTechNote);
        }

        // POST: tstTechNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TechID,TicketID,Notation,NotationDate")] tstTechNote tstTechNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstTechNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name", tstTechNote.TechID);
            ViewBag.TicketID = new SelectList(db.tstTickets, "ID", "TroubleDescription", tstTechNote.TicketID);
            return View(tstTechNote);
        }

        // GET: tstTechNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTechNote tstTechNote = db.tstTechNotes.Find(id);
            if (tstTechNote == null)
            {
                return HttpNotFound();
            }
            return View(tstTechNote);
        }

        // POST: tstTechNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstTechNote tstTechNote = db.tstTechNotes.Find(id);
            db.tstTechNotes.Remove(tstTechNote);
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
