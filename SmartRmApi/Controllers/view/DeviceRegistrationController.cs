using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartRmApi.Models;

namespace SmartRmApi.Controllers.view
{
    public class DeviceRegistrationController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: DeviceRegistration
        public ActionResult Index()
        {
            return View(db.tbl_deviceRegistration.ToList());
        }

        // GET: DeviceRegistration/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_deviceRegistration tbl_deviceRegistration = db.tbl_deviceRegistration.Find(id);
            if (tbl_deviceRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_deviceRegistration);
        }

        // GET: DeviceRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,gcm_regId,device_name,device_id")] tbl_deviceRegistration tbl_deviceRegistration)
        {
            if (ModelState.IsValid)
            {
                tbl_deviceRegistration.id = Guid.NewGuid();
                db.tbl_deviceRegistration.Add(tbl_deviceRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_deviceRegistration);
        }

        // GET: DeviceRegistration/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_deviceRegistration tbl_deviceRegistration = db.tbl_deviceRegistration.Find(id);
            if (tbl_deviceRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_deviceRegistration);
        }

        // POST: DeviceRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,gcm_regId,device_name,device_id")] tbl_deviceRegistration tbl_deviceRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_deviceRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_deviceRegistration);
        }

        // GET: DeviceRegistration/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_deviceRegistration tbl_deviceRegistration = db.tbl_deviceRegistration.Find(id);
            if (tbl_deviceRegistration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_deviceRegistration);
        }

        // POST: DeviceRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_deviceRegistration tbl_deviceRegistration = db.tbl_deviceRegistration.Find(id);
            db.tbl_deviceRegistration.Remove(tbl_deviceRegistration);
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
