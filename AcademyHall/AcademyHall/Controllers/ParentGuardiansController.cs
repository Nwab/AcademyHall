using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademyHall.DataLink;
using AcademyHall.Models;

namespace AcademyHall.Controllers
{
    public class ParentGuardiansController : Controller
    {
        private AcademyHallDbContext db = new AcademyHallDbContext();

        // GET: ParentGuardians
        public ActionResult Index()
        {
            var parentGuardians = db.ParentGuardians.Include(p => p.AcademyGuardianUser);
            return View(parentGuardians.ToList());
        }

        // GET: ParentGuardians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentGuardian parentGuardian = db.ParentGuardians.Find(id);
            if (parentGuardian == null)
            {
                return HttpNotFound();
            }
            return View(parentGuardian);
        }

        // GET: ParentGuardians/Create
        public ActionResult Create()
        {
            //ViewBag.AcademyUserId = new SelectList(db.AcademyUsers, "Id", "studentID");
            return View();
        }

        // POST: ParentGuardians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,PhoneNumber,ContactAddress,HouseAddress,AcademyUserId")] ParentGuardian parentGuardian)
        {
            if (ModelState.IsValid)
            {
                db.ParentGuardians.Add(parentGuardian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.AcademyUserId = new SelectList(db.AcademyUsers, "Id", "studentID", parentGuardian.AcademyUserId);
            return View(parentGuardian);
        }

        // GET: ParentGuardians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentGuardian parentGuardian = db.ParentGuardians.Find(id);
            if (parentGuardian == null)
            {
                return HttpNotFound();
            }
           // ViewBag.AcademyUserId = new SelectList(db.AcademyUsers, "Id", "studentID", parentGuardian.AcademyUserId);
            return View(parentGuardian);
        }

        // POST: ParentGuardians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,PhoneNumber,ContactAddress,HouseAddress,AcademyUserId")] ParentGuardian parentGuardian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentGuardian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         //   ViewBag.AcademyUserId = new SelectList(db.AcademyUsers, "Id", "studentID", parentGuardian.AcademyUserId);
            return View(parentGuardian);
        }

        // GET: ParentGuardians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentGuardian parentGuardian = db.ParentGuardians.Find(id);
            if (parentGuardian == null)
            {
                return HttpNotFound();
            }
            return View(parentGuardian);
        }

        // POST: ParentGuardians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentGuardian parentGuardian = db.ParentGuardians.Find(id);
            db.ParentGuardians.Remove(parentGuardian);
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
