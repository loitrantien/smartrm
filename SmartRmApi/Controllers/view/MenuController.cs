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
    public class MenuController : Controller
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: Menu
        public ActionResult Index()
        {
            var tbl_menu = db.tbl_menu.Include(t => t.tbl_dishes).Include(t => t.tbl_menuType);
            return View(tbl_menu.ToList());
        }

        // GET: Menu/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_menu tbl_menu = db.tbl_menu.Find(id);
            if (tbl_menu == null)
            {
                return HttpNotFound();
            }
            return View(tbl_menu);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            ViewBag.dishes_id = new SelectList(db.tbl_dishes, "id", "name");
            ViewBag.type_id = new SelectList(db.tbl_menuType, "id", "name");
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "type_id,dishes_id,is_active")] tbl_menu tbl_menu)
        {
            if (ModelState.IsValid)
            {
                db.tbl_menu.Add(tbl_menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dishes_id = new SelectList(db.tbl_dishes, "id", "code", tbl_menu.dishes_id);
            ViewBag.type_id = new SelectList(db.tbl_menuType, "id", "name", tbl_menu.type_id);
            return View(tbl_menu);
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_menu tbl_menu = db.tbl_menu.Find(id);
            if (tbl_menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.dishes_id = new SelectList(db.tbl_dishes, "id", "code", tbl_menu.dishes_id);
            ViewBag.type_id = new SelectList(db.tbl_menuType, "id", "name", tbl_menu.type_id);
            return View(tbl_menu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "type_id,dishes_id,is_active")] tbl_menu tbl_menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dishes_id = new SelectList(db.tbl_dishes, "id", "code", tbl_menu.dishes_id);
            ViewBag.type_id = new SelectList(db.tbl_menuType, "id", "name", tbl_menu.type_id);
            return View(tbl_menu);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_menu tbl_menu = db.tbl_menu.Find(id);
            if (tbl_menu == null)
            {
                return HttpNotFound();
            }
            return View(tbl_menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            tbl_menu tbl_menu = db.tbl_menu.Find(id);
            db.tbl_menu.Remove(tbl_menu);
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
