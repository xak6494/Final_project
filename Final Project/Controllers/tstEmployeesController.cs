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
    public class tstEmployeesController : Controller
    {
        private TSTEntities db = new TSTEntities();

        // GET: tstEmployees
        public ActionResult Index()
        {
            var tstEmployees = db.tstEmployees.Include(t => t.tstDepartment).Include(t => t.tstEmployeeStatu);
            return View(tstEmployees.ToList());
        }

        // GET: tstEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstEmployee tstEmployee = db.tstEmployees.Find(id);
            if (tstEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tstEmployee);
        }

        // GET: tstEmployees/Create
        public ActionResult Create()
        {
            ViewBag.DepID = new SelectList(db.tstDepartments, "ID", "Name");
            ViewBag.StatusID = new SelectList(db.tstEmployeeStatus, "ID", "Name");
            return View();
        }

        // POST: tstEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Lname,Hiredate,UserID,StatusID,Jobtitle,Adress,Adress2,City,State,Zip,Email,Phone,DepID,ImmageURL,Notes,Dateofbirth,separationDate")] tstEmployee tstEmployee)
        {
            if (ModelState.IsValid)
            {
                db.tstEmployees.Add(tstEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepID = new SelectList(db.tstDepartments, "ID", "Name", tstEmployee.DepID);
            ViewBag.StatusID = new SelectList(db.tstEmployeeStatus, "ID", "Name", tstEmployee.StatusID);
            return View(tstEmployee);
        }

        // GET: tstEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstEmployee tstEmployee = db.tstEmployees.Find(id);
            if (tstEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepID = new SelectList(db.tstDepartments, "ID", "Name", tstEmployee.DepID);
            ViewBag.StatusID = new SelectList(db.tstEmployeeStatus, "ID", "Name", tstEmployee.StatusID);
            return View(tstEmployee);
        }

        // POST: tstEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Lname,Hiredate,UserID,StatusID,Jobtitle,Adress,Adress2,City,State,Zip,Email,Phone,DepID,ImmageURL,Notes,Dateofbirth,separationDate")] tstEmployee tstEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepID = new SelectList(db.tstDepartments, "ID", "Name", tstEmployee.DepID);
            ViewBag.StatusID = new SelectList(db.tstEmployeeStatus, "ID", "Name", tstEmployee.StatusID);
            return View(tstEmployee);
        }

        // GET: tstEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstEmployee tstEmployee = db.tstEmployees.Find(id);
            if (tstEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tstEmployee);
        }

        // POST: tstEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tstEmployee tstEmployee = db.tstEmployees.Find(id);
            db.tstEmployees.Remove(tstEmployee);
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
