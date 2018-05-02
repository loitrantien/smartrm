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
    public class DeviceRegistrationController : ApiController
    {
        private QLNHDBContext db = new QLNHDBContext();

        // GET: api/DeviceRegistration
        public IQueryable<tbl_deviceRegistration> Gettbl_deviceRegistration()
        {
            return db.tbl_deviceRegistration;
        }

        // GET: api/DeviceRegistration/5
        [ResponseType(typeof(tbl_deviceRegistration))]
        public IHttpActionResult Gettbl_deviceRegistration(Guid id)
        {
            tbl_deviceRegistration tbl_deviceRegistration = db.tbl_deviceRegistration.Find(id);
            if (tbl_deviceRegistration == null)
            {
                return NotFound();
            }

            return Ok(tbl_deviceRegistration);
        }

        // PUT: api/DeviceRegistration/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_deviceRegistration(Guid id, tbl_deviceRegistration tbl_deviceRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_deviceRegistration.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_deviceRegistration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_deviceRegistrationExists(id))
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

        // POST: api/DeviceRegistration
        [ResponseType(typeof(tbl_deviceRegistration))]
        public IHttpActionResult Posttbl_deviceRegistration(tbl_deviceRegistration tbl_deviceRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_deviceRegistration.Add(tbl_deviceRegistration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_deviceRegistrationExists(tbl_deviceRegistration.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_deviceRegistration.id }, tbl_deviceRegistration);
        }

        // DELETE: api/DeviceRegistration/5
        [ResponseType(typeof(tbl_deviceRegistration))]
        public IHttpActionResult Deletetbl_deviceRegistration(Guid id)
        {
            tbl_deviceRegistration tbl_deviceRegistration = db.tbl_deviceRegistration.Find(id);
            if (tbl_deviceRegistration == null)
            {
                return NotFound();
            }

            db.tbl_deviceRegistration.Remove(tbl_deviceRegistration);
            db.SaveChanges();

            return Ok(tbl_deviceRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_deviceRegistrationExists(Guid id)
        {
            return db.tbl_deviceRegistration.Count(e => e.id == id) > 0;
        }
    }
}