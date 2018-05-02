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
    public class DishesController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: Dishes
        public ActionResult Index()
        {
            var tbl_dishes = db.tbl_dishes.Include(t => t.tbl_dishesType);
            return View(tbl_dishes.ToList());
        }

        // GET: Dishes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dishes tbl_dishes = db.tbl_dishes.Find(id);
            if (tbl_dishes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dishes);
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            ViewBag.type_id = new SelectList(db.tbl_dishesType, "id", "name");
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name,type_id,unit,price,description,image")] tbl_dishes tbl_dishes)
        {
            if (ModelState.IsValid)
            {
                tbl_dishes.id = Guid.NewGuid();
                db.tbl_dishes.Add(tbl_dishes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.type_id = new SelectList(db.tbl_dishesType, "id", "code", tbl_dishes.type_id);
            return View(tbl_dishes);
        }

        // GET: Dishes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dishes tbl_dishes = db.tbl_dishes.Find(id);
            if (tbl_dishes == null)
            {
                return HttpNotFound();
            }
            ViewBag.type_id = new SelectList(db.tbl_dishesType, "id", "code", tbl_dishes.type_id);
            return View(tbl_dishes);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,type_id,unit,price,description,image")] tbl_dishes tbl_dishes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_dishes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.type_id = new SelectList(db.tbl_dishesType, "id", "code", tbl_dishes.type_id);
            return View(tbl_dishes);
        }

        // GET: Dishes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_dishes tbl_dishes = db.tbl_dishes.Find(id);
            if (tbl_dishes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_dishes);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_dishes tbl_dishes = db.tbl_dishes.Find(id);
            db.tbl_dishes.Remove(tbl_dishes);
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
