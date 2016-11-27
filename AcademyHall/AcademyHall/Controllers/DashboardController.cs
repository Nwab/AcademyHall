using AcademyHall.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcademyHall.Controllers
{
    [RoleFilter]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
           ActiveLinkStatus("active");
            return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void ActiveLinkStatus(string activeDashboard)
        {
            ViewBag.StudentLink = string.Empty;
            ViewBag.ParentGuardianLink = string.Empty;
            ViewBag.ActiveBusinessInfo = string.Empty;
            ViewBag.DashboardLink = activeDashboard;
            ViewBag.ActiveBankRlsip = string.Empty;
            ViewBag.ActiveNextOfKin = string.Empty;
            ViewBag.ActivePreview = string.Empty;
        }
    }
}
