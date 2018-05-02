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
    public class MenuTypeController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: MenuType
        public ActionResult Index()
        {
            return View(db.tbl_menuType.ToList());
        }

        // GET: MenuType/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_menuType tbl_menuType = db.tbl_menuType.Find(id);
            if (tbl_menuType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_menuType);
        }

        // GET: MenuType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] tbl_menuType tbl_menuType)
        {
            if (ModelState.IsValid)
            {
                tbl_menuType.id = Guid.NewGuid();
                db.tbl_menuType.Add(tbl_menuType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_menuType);
        }

        // GET: MenuType/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_menuType tbl_menuType = db.tbl_menuType.Find(id);
            if (tbl_menuType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_menuType);
        }

        // POST: MenuType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] tbl_menuType tbl_menuType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_menuType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_menuType);
        }

        // GET: MenuType/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_menuType tbl_menuType = db.tbl_menuType.Find(id);
            if (tbl_menuType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_menuType);
        }

        // POST: MenuType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_menuType tbl_menuType = db.tbl_menuType.Find(id);
            db.tbl_menuType.Remove(tbl_menuType);
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
