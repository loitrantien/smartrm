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
    public class OrderController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/Order
        public IQueryable<tbl_order> Gettbl_order()
        {
            return db.tbl_order;
        }

        // GET: api/Order/5
        [ResponseType(typeof(tbl_order))]
        public IHttpActionResult Gettbl_order(Guid id)
        {
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return NotFound();
            }

            return Ok(tbl_order);
        }

        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_order(Guid id, tbl_order tbl_order)
        {
            tbl_order cache = tbl_order;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_order.id)
            {
                return BadRequest();
            }
            tbl_order.tbl_table = null;
            ICollection<tbl_orderDetail> newDetails = tbl_order.tbl_orderDetail;
            tbl_order.tbl_orderDetail = null;

            db.Entry(tbl_order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_orderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (newDetails != null)
            {
                ICollection<tbl_orderDetail> oldDetails = db.tbl_orderDetail.Where(e => e.order_id == id).ToList();


                foreach (var oldDetail in oldDetails)
                {
                    if (!(newDetails.Count(e => e.order_id == oldDetail.order_id && e.name.Equals(oldDetail.name)) > 0))
                    {
                        if (oldDetail != null)
                        {
                            oldDetail.tbl_order = null;
                            db.tbl_orderDetail.Remove(oldDetail);
                            db.SaveChanges();
                        }
                    }
                }

                foreach (var item in newDetails)
                {
                    tbl_orderDetail temp = db.tbl_orderDetail.FirstOrDefault(e => e.order_id == item.order_id && e.name.Equals(item.name));

                    if (temp == null)
                    {
                        item.tbl_order = null;
                        db.tbl_orderDetail.Add(item);
                    }
                    else
                    {
                        temp.name = item.name;
                        temp.price = item.price;
                        temp.amout = item.amout;
                        temp.tbl_order = null;
                        db.Entry(temp).State = EntityState.Modified;
                    }

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!(db.tbl_orderDetail.Count(e => e.order_id == item.order_id && e.name.Equals(item.name)) > 0))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Order
        [ResponseType(typeof(tbl_order))]
        public IHttpActionResult Posttbl_order(tbl_order tbl_order)
        {
            tbl_order temp = tbl_order;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ICollection<tbl_orderDetail> details = tbl_order.tbl_orderDetail;
            tbl_order.tbl_orderDetail = null;
            tbl_order.tbl_table = null;

            db.tbl_order.Add(tbl_order);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_orderExists(tbl_order.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            if (details != null)
            {
                foreach (var item in details)
                {

                    try
                    {
                        item.tbl_order = null;
                        db.tbl_orderDetail.Add(item);
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        if (db.tbl_orderDetail.Count(e => e.order_id == item.order_id && e.name.Equals(item.name)) > 0)
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }


            return CreatedAtRoute("DefaultApi", new { id = tbl_order.id }, tbl_order);
        }

        // DELETE: api/Order/5
        [ResponseType(typeof(tbl_order))]
        public IHttpActionResult Deletetbl_order(Guid id)
        {
            tbl_order tbl_order = db.tbl_order.Find(id);
            if (tbl_order == null)
            {
                return NotFound();
            }
            tbl_order.tbl_orderDetail = null;
            tbl_order.tbl_table = null;

            db.tbl_order.Remove(tbl_order);
            db.SaveChanges();

            return Ok(tbl_order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_orderExists(Guid id)
        {
            return db.tbl_order.Count(e => e.id == id) > 0;
        }
    }
}