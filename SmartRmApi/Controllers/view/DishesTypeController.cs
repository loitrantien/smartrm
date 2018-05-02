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
    public class DishesTypeController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: DishesType
        public ActionResult Index()
        {
            return View(db.tbl_dishesType.ToList());
        }

        // GET: DishesType/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dishesType tbl_dishesType = db.tbl_dishesType.Find(id);
            if (tbl_dishesType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dishesType);
        }

        // GET: DishesType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishesType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name")] tbl_dishesType tbl_dishesType)
        {
            if (ModelState.IsValid)
            {
                tbl_dishesType.id = Guid.NewGuid();
                db.tbl_dishesType.Add(tbl_dishesType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_dishesType);
        }

        // GET: DishesType/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dishesType tbl_dishesType = db.tbl_dishesType.Find(id);
            if (tbl_dishesType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dishesType);
        }

        // POST: DishesType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name")] tbl_dishesType tbl_dishesType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_dishesType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_dishesType);
        }

        // GET: DishesType/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dishesType tbl_dishesType = db.tbl_dishesType.Find(id);
            if (tbl_dishesType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dishesType);
        }

        // POST: DishesType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_dishesType tbl_dishesType = db.tbl_dishesType.Find(id);
            db.tbl_dishesType.Remove(tbl_dishesType);
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
