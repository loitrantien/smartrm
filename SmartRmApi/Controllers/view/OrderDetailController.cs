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
    public class OrderDetailController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: OrderDetail
        public ActionResult Index()
        {
            var tbl_orderDetail = db.tbl_orderDetail.Include(t => t.tbl_order);
            return View(tbl_orderDetail.ToList());
        }

        // GET: OrderDetail/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_orderDetail tbl_orderDetail = db.tbl_orderDetail.Find(id);
            if (tbl_orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_orderDetail);
        }

        // GET: OrderDetail/Create
        public ActionResult Create()
        {
            ViewBag.order_id = new SelectList(db.tbl_order, "id", "create_date");
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,name,amout,price")] tbl_orderDetail tbl_orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.tbl_orderDetail.Add(tbl_orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.order_id = new SelectList(db.tbl_order, "id", "create_date", tbl_orderDetail.order_id);
            return View(tbl_orderDetail);
        }

        // GET: OrderDetail/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_orderDetail tbl_orderDetail = db.tbl_orderDetail.Find(id);
            if (tbl_orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_id = new SelectList(db.tbl_order, "id", "create_date", tbl_orderDetail.order_id);
            return View(tbl_orderDetail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,name,amout,price")] tbl_orderDetail tbl_orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.order_id = new SelectList(db.tbl_order, "id", "create_date", tbl_orderDetail.order_id);
            return View(tbl_orderDetail);
        }

        // GET: OrderDetail/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_orderDetail tbl_orderDetail = db.tbl_orderDetail.Find(id);
            if (tbl_orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_orderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_orderDetail tbl_orderDetail = db.tbl_orderDetail.Find(id);
            db.tbl_orderDetail.Remove(tbl_orderDetail);
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
