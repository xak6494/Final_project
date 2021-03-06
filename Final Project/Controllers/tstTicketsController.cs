﻿using System;
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
    public class tstTicketsController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstTickets
        public ActionResult Index()
        {
            var tstTickets = db.tstTickets.Include(t => t.tstEmployee).Include(t => t.tstEmployee1).Include(t => t.tstTicketPriorty).Include(t => t.tstTicketStatu);
            return View(tstTickets.ToList());
        }

        // GET: tstTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicket tstTicket = db.tstTickets.Find(id);
            if (tstTicket == null)
            {
                return HttpNotFound();
            }
            return View(tstTicket);
        }

        // GET: tstTickets/Create
        public ActionResult Create()
        {
            ViewBag.SubmitbyID = new SelectList(db.tstEmployees, "ID", "Name");
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name");
            ViewBag.PriorityID = new SelectList(db.tstTicketPriorties, "ID", "Name");
            ViewBag.StatusID = new SelectList(db.tstTicketStatus, "ID", "Name");
            return View();
        }

        // POST: tstTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubmitbyID,TechID,CreatedDate,ResoloutionDate,TroubleDescription,Screenshot,StatusID,PriorityID,Subject")] tstTicket tstTicket)
        {
            if (ModelState.IsValid)
            {
                db.tstTickets.Add(tstTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubmitbyID = new SelectList(db.tstEmployees, "ID", "Name", tstTicket.SubmitbyID);
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name", tstTicket.TechID);
            ViewBag.PriorityID = new SelectList(db.tstTicketPriorties, "ID", "Name", tstTicket.PriorityID);
            ViewBag.StatusID = new SelectList(db.tstTicketStatus, "ID", "Name", tstTicket.StatusID);
            return View(tstTicket);
        }

        // GET: tstTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicket tstTicket = db.tstTickets.Find(id);
            if (tstTicket == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubmitbyID = new SelectList(db.tstEmployees, "ID", "Name", tstTicket.SubmitbyID);
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name", tstTicket.TechID);
            ViewBag.PriorityID = new SelectList(db.tstTicketPriorties, "ID", "Name", tstTicket.PriorityID);
            ViewBag.StatusID = new SelectList(db.tstTicketStatus, "ID", "Name", tstTicket.StatusID);
            return View(tstTicket);
        }

        // POST: tstTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubmitbyID,TechID,CreatedDate,ResoloutionDate,TroubleDescription,Screenshot,StatusID,PriorityID,Subject")] tstTicket tstTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubmitbyID = new SelectList(db.tstEmployees, "ID", "Name", tstTicket.SubmitbyID);
            ViewBag.TechID = new SelectList(db.tstEmployees, "ID", "Name", tstTicket.TechID);
            ViewBag.PriorityID = new SelectList(db.tstTicketPriorties, "ID", "Name", tstTicket.PriorityID);
            ViewBag.StatusID = new SelectList(db.tstTicketStatus, "ID", "Name", tstTicket.StatusID);
            return View(tstTicket);
        }

        // GET: tstTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstTicket tstTicket = db.tstTickets.Find(id);
            if (tstTicket == null)
            {
                return HttpNotFound();
            }
            return View(tstTicket);
        }

        // POST: tstTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstTicket tstTicket = db.tstTickets.Find(id);
            db.tstTickets.Remove(tstTicket);
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
