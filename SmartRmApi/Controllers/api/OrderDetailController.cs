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
using SmartRmApi.Models;
using Newtonsoft.Json;

namespace SmartRmApi.Controllers.api
{
    public class OrderDetailController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();


        // PUT: api/OrderDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_orderDetail(Guid id, string name, tbl_orderDetail tbl_orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_orderDetail.order_id)
            {
                return BadRequest();
            }

            tbl_orderDetail temp = db.tbl_orderDetail.FirstOrDefault(e => e.order_id == id && e.name.Equals(name));

            if (temp == null)
            {
                return NotFound();
            }

            temp.name = tbl_orderDetail.name;
            temp.price = tbl_orderDetail.price;
            temp.amout = tbl_orderDetail.amout;
            temp.tbl_order = null;

            db.Entry(temp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_orderDetailExists(id,tbl_orderDetail.name))
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

        // POST: api/OrderDetail
        [ResponseType(typeof(tbl_orderDetail))]
        public IHttpActionResult Posttbl_orderDetail(tbl_orderDetail tbl_orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tbl_orderDetail.tbl_order = null;
            db.tbl_orderDetail.Add(tbl_orderDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_orderDetailExists(tbl_orderDetail.order_id,tbl_orderDetail.name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_orderDetail.order_id }, tbl_orderDetail);
        }


        // DELETE: api/OrderDetail/5
        [ResponseType(typeof(tbl_orderDetail))]
        public IHttpActionResult Deletetbl_orderDetail(Guid id,string name)
        {
            tbl_orderDetail tbl_orderDetail = db.tbl_orderDetail.FirstOrDefault(e => e.order_id == id && e.name.Equals(name));
            if (tbl_orderDetail == null)
            {
                return NotFound();
            }

            tbl_orderDetail.tbl_order = null;
            db.tbl_orderDetail.Remove(tbl_orderDetail);
            db.SaveChanges();

            return Ok(tbl_orderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_orderDetailExists(Guid id,string name)
        {
            return db.tbl_orderDetail.Count(e => e.order_id == id && e.name.Equals(name)) > 0;
        }
    }
}