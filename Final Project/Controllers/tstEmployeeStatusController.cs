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
    public class tstEmployeeStatusController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstEmployeeStatus
        public ActionResult Index()
        {
            return View(db.tstEmployeeStatus.ToList());
        }

        // GET: tstEmployeeStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstEmployeeStatu tstEmployeeStatu = db.tstEmployeeStatus.Find(id);
            if (tstEmployeeStatu == null)
            {
                return HttpNotFound();
            }
            return View(tstEmployeeStatu);
        }

        // GET: tstEmployeeStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tstEmployeeStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] tstEmployeeStatu tstEmployeeStatu)
        {
            if (ModelState.IsValid)
            {
                db.tstEmployeeStatus.Add(tstEmployeeStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tstEmployeeStatu);
        }

        // GET: tstEmployeeStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstEmployeeStatu tstEmployeeStatu = db.tstEmployeeStatus.Find(id);
            if (tstEmployeeStatu == null)
            {
                return HttpNotFound();
            }
            return View(tstEmployeeStatu);
        }

        // POST: tstEmployeeStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] tstEmployeeStatu tstEmployeeStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstEmployeeStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tstEmployeeStatu);
        }

        // GET: tstEmployeeStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstEmployeeStatu tstEmployeeStatu = db.tstEmployeeStatus.Find(id);
            if (tstEmployeeStatu == null)
            {
                return HttpNotFound();
            }
            return View(tstEmployeeStatu);
        }

        // POST: tstEmployeeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstEmployeeStatu tstEmployeeStatu = db.tstEmployeeStatus.Find(id);
            db.tstEmployeeStatus.Remove(tstEmployeeStatu);
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
