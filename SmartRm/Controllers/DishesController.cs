using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartRm.Models.databases.entity;

namespace SmartRm.Controllers
{
    public class DishesController : ApiController
    {
        private QLNHDBContext db = new QLNHDBContext();

        // GET: api/Dishes
        public IQueryable<tbl_dishes> Gettbl_dishes()
        {
            return db.tbl_dishes;
        }

        // GET: api/Dishes/5
        [ResponseType(typeof(tbl_dishes))]
        public IHttpActionResult Gettbl_dishes(Guid id)
        {
            tbl_dishes tbl_dishes = db.tbl_dishes.Find(id);
            if (tbl_dishes == null)
            {
                return NotFound();
            }

            return Ok(tbl_dishes);
        }

        // PUT: api/Dishes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_dishes(Guid id, tbl_dishes tbl_dishes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_dishes.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_dishes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_dishesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Dishes
        [ResponseType(typeof(tbl_dishes))]
        public IHttpActionResult Posttbl_dishes(tbl_dishes tbl_dishes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_dishes.Add(tbl_dishes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_dishesExists(tbl_dishes.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_dishes.id }, tbl_dishes);
        }

        // DELETE: api/Dishes/5
        [ResponseType(typeof(tbl_dishes))]
        public IHttpActionResult Deletetbl_dishes(Guid id)
        {
            tbl_dishes tbl_dishes = db.tbl_dishes.Find(id);
            if (tbl_dishes == null)
            {
                return NotFound();
            }

            db.tbl_dishes.Remove(tbl_dishes);
            db.SaveChanges();

            return Ok(tbl_dishes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_dishesExists(Guid id)
        {
            return db.tbl_dishes.Count(e => e.id == id) > 0;
        }
    }
}