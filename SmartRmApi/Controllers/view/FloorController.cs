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
    public class FloorController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: Floor
        public ActionResult Index()
        {
            return View(db.tbl_floor.ToList());
        }

        // GET: Floor/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_floor tbl_floor = db.tbl_floor.Find(id);
            if (tbl_floor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_floor);
        }

        // GET: Floor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Floor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name")] tbl_floor tbl_floor)
        {
            if (ModelState.IsValid)
            {
                tbl_floor.id = Guid.NewGuid();
                db.tbl_floor.Add(tbl_floor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_floor);
        }

        // GET: Floor/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_floor tbl_floor = db.tbl_floor.Find(id);
            if (tbl_floor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_floor);
        }

        // POST: Floor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name")] tbl_floor tbl_floor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_floor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_floor);
        }

        // GET: Floor/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_floor tbl_floor = db.tbl_floor.Find(id);
            if (tbl_floor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_floor);
        }

        // POST: Floor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_floor tbl_floor = db.tbl_floor.Find(id);
            db.tbl_floor.Remove(tbl_floor);
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
