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
    public class TableController : ApiController
    {
        private QLNHDBContext db = new QLNHDBContext();

        // GET: api/Table
        public IQueryable<tbl_table> Gettbl_table()
        {
            return db.tbl_table;
        }

        // GET: api/Table/5
        [ResponseType(typeof(tbl_table))]
        public IHttpActionResult Gettbl_table(Guid id)
        {
            tbl_table tbl_table = db.tbl_table.Find(id);
            if (tbl_table == null)
            {
                return NotFound();
            }

            return Ok(tbl_table);
        }

        // PUT: api/Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_table(Guid id, tbl_table tbl_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_table.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_tableExists(id))
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

        // POST: api/Table
        [ResponseType(typeof(tbl_table))]
        public IHttpActionResult Posttbl_table(tbl_table tbl_table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_table.Add(tbl_table);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_tableExists(tbl_table.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_table.id }, tbl_table);
        }

        // DELETE: api/Table/5
        [ResponseType(typeof(tbl_table))]
        public IHttpActionResult Deletetbl_table(Guid id)
        {
            tbl_table tbl_table = db.tbl_table.Find(id);
            if (tbl_table == null)
            {
                return NotFound();
            }

            db.tbl_table.Remove(tbl_table);
            db.SaveChanges();

            return Ok(tbl_table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_tableExists(Guid id)
        {
            return db.tbl_table.Count(e => e.id == id) > 0;
        }
    }
}