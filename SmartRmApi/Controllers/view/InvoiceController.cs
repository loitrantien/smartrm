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
    public class InvoiceController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: Invoice
        public ActionResult Index()
        {
            var tbl_invoice = db.tbl_invoice.Include(t => t.tbl_table).Include(t => t.tbl_user);
            return View(tbl_invoice.ToList());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_invoice tbl_invoice = db.tbl_invoice.Find(id);
            if (tbl_invoice == null)
            {
                return HttpNotFound();
            }
            return View(tbl_invoice);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code");
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "user_name");
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,table_id,user_id,time_in,time_out,date,total")] tbl_invoice tbl_invoice)
        {
            if (ModelState.IsValid)
            {
                tbl_invoice.id = Guid.NewGuid();
                db.tbl_invoice.Add(tbl_invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code", tbl_invoice.table_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "user_name", tbl_invoice.user_id);
            return View(tbl_invoice);
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_invoice tbl_invoice = db.tbl_invoice.Find(id);
            if (tbl_invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code", tbl_invoice.table_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "user_name", tbl_invoice.user_id);
            return View(tbl_invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,table_id,user_id,time_in,time_out,date,total")] tbl_invoice tbl_invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.table_id = new SelectList(db.tbl_table, "id", "code", tbl_invoice.table_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "id", "user_name", tbl_invoice.user_id);
            return View(tbl_invoice);
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_invoice tbl_invoice = db.tbl_invoice.Find(id);
            if (tbl_invoice == null)
            {
                return HttpNotFound();
            }
            return View(tbl_invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_invoice tbl_invoice = db.tbl_invoice.Find(id);
            db.tbl_invoice.Remove(tbl_invoice);
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
