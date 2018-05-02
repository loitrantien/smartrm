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
    public class TableController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: Table
        public ActionResult Index()
        {
            var tbl_table = db.tbl_table.Include(t => t.tbl_floor).Include(t => t.tbl_tableType);
            return View(tbl_table.ToList());
        }

        // GET: Table/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_table tbl_table = db.tbl_table.Find(id);
            if (tbl_table == null)
            {
                return HttpNotFound();
            }
            return View(tbl_table);
        }

        // GET: Table/Create
        public ActionResult Create()
        {
            ViewBag.floor_id = new SelectList(db.tbl_floor, "id", "name");
            ViewBag.type_id = new SelectList(db.tbl_tableType, "id", "name");
            return View();
        }

        // POST: Table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name,type_id,floor_id")] tbl_table tbl_table)
        {
            if (ModelState.IsValid)
            {
                tbl_table.id = Guid.NewGuid();
                db.tbl_table.Add(tbl_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.floor_id = new SelectList(db.tbl_floor, "id", "code", tbl_table.floor_id);
            ViewBag.type_id = new SelectList(db.tbl_tableType, "id", "code", tbl_table.type_id);
            return View(tbl_table);
        }

        // GET: Table/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_table tbl_table = db.tbl_table.Find(id);
            if (tbl_table == null)
            {
                return HttpNotFound();
            }
            ViewBag.floor_id = new SelectList(db.tbl_floor, "id", "code", tbl_table.floor_id);
            ViewBag.type_id = new SelectList(db.tbl_tableType, "id", "code", tbl_table.type_id);
            return View(tbl_table);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,type_id,floor_id")] tbl_table tbl_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.floor_id = new SelectList(db.tbl_floor, "id", "code", tbl_table.floor_id);
            ViewBag.type_id = new SelectList(db.tbl_tableType, "id", "code", tbl_table.type_id);
            return View(tbl_table);
        }

        // GET: Table/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_table tbl_table = db.tbl_table.Find(id);
            if (tbl_table == null)
            {
                return HttpNotFound();
            }
            return View(tbl_table);
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_table tbl_table = db.tbl_table.Find(id);
            db.tbl_table.Remove(tbl_table);
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
