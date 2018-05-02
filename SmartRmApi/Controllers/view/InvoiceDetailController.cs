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
    public class InvoiceDetailController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: InvoiceDetail
        public ActionResult Index()
        {
            var tbl_invoiceDetail = db.tbl_invoiceDetail.Include(t => t.tbl_invoice);
            return View(tbl_invoiceDetail.ToList());
        }

        // GET: InvoiceDetail/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_invoiceDetail tbl_invoiceDetail = db.tbl_invoiceDetail.Find(id);
            if (tbl_invoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_invoiceDetail);
        }

        // GET: InvoiceDetail/Create
        public ActionResult Create()
        {
            ViewBag.invoice_id = new SelectList(db.tbl_invoice, "id", "code");
            return View();
        }

        // POST: InvoiceDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "invoice_id,name,amount,price")] tbl_invoiceDetail tbl_invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.tbl_invoiceDetail.Add(tbl_invoiceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.invoice_id = new SelectList(db.tbl_invoice, "id", "code", tbl_invoiceDetail.invoice_id);
            return View(tbl_invoiceDetail);
        }

        // GET: InvoiceDetail/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_invoiceDetail tbl_invoiceDetail = db.tbl_invoiceDetail.Find(id);
            if (tbl_invoiceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.invoice_id = new SelectList(db.tbl_invoice, "id", "code", tbl_invoiceDetail.invoice_id);
            return View(tbl_invoiceDetail);
        }

        // POST: InvoiceDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "invoice_id,name,amount,price")] tbl_invoiceDetail tbl_invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_invoiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.invoice_id = new SelectList(db.tbl_invoice, "id", "code", tbl_invoiceDetail.invoice_id);
            return View(tbl_invoiceDetail);
        }

        // GET: InvoiceDetail/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_invoiceDetail tbl_invoiceDetail = db.tbl_invoiceDetail.Find(id);
            if (tbl_invoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_invoiceDetail);
        }

        // POST: InvoiceDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_invoiceDetail tbl_invoiceDetail = db.tbl_invoiceDetail.Find(id);
            db.tbl_invoiceDetail.Remove(tbl_invoiceDetail);
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
