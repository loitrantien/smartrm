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
    public class TableTypeController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: TableType
        public ActionResult Index()
        {
            return View(db.tbl_tableType.ToList());
        }

        // GET: TableType/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tableType tbl_tableType = db.tbl_tableType.Find(id);
            if (tbl_tableType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tableType);
        }

        // GET: TableType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name")] tbl_tableType tbl_tableType)
        {
            if (ModelState.IsValid)
            {
                tbl_tableType.id = Guid.NewGuid();
                db.tbl_tableType.Add(tbl_tableType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tableType);
        }

        // GET: TableType/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tableType tbl_tableType = db.tbl_tableType.Find(id);
            if (tbl_tableType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tableType);
        }

        // POST: TableType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name")] tbl_tableType tbl_tableType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tableType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tableType);
        }

        // GET: TableType/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tableType tbl_tableType = db.tbl_tableType.Find(id);
            if (tbl_tableType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tableType);
        }

        // POST: TableType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_tableType tbl_tableType = db.tbl_tableType.Find(id);
            db.tbl_tableType.Remove(tbl_tableType);
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
