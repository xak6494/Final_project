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
    public class tstDepartmentsController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstDepartments
        public ActionResult Index()
        {
            return View(db.tstDepartments.ToList());
        }

        // GET: tstDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstDepartment tstDepartment = db.tstDepartments.Find(id);
            if (tstDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tstDepartment);
        }

        // GET: tstDepartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tstDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,ISActive")] tstDepartment tstDepartment)
        {
            if (ModelState.IsValid)
            {
                db.tstDepartments.Add(tstDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tstDepartment);
        }

        // GET: tstDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstDepartment tstDepartment = db.tstDepartments.Find(id);
            if (tstDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tstDepartment);
        }

        // POST: tstDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,ISActive")] tstDepartment tstDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tstDepartment);
        }

        // GET: tstDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstDepartment tstDepartment = db.tstDepartments.Find(id);
            if (tstDepartment == null)
            {
                return HttpNotFound();
            }
            return View(tstDepartment);
        }

        // POST: tstDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstDepartment tstDepartment = db.tstDepartments.Find(id);
            db.tstDepartments.Remove(tstDepartment);
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
