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
    public class OrderController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: Order
        public ActionResult Index()
        {
            var tbl_order = db.tbl_order.Include(t => t.tbl_table);
            return View(tbl_order.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,create_date,update_date,note,table_id,state,total")] tbl_order tbl_order)
        {
            if (ModelState.IsValid)
            {
                tbl_order.id = Guid.NewGuid();
                db.tbl_order.Add(tbl_order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code", tbl_order.table_id);
            return View(tbl_order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return HttpNotFound();
            }
            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code", tbl_order.table_id);
            return View(tbl_order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,create_date,update_date,note,table_id,state,total")] tbl_order tbl_order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code", tbl_order.table_id);
            return View(tbl_order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_order tbl_order = db.tbl_order.Find(id);
            db.tbl_order.Remove(tbl_order);
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
