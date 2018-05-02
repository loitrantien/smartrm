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

namespace SmartRmApi.Controllers.api
{
    public class InvoiceDetailController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/InvoiceDetail
        public IQueryable<tbl_invoiceDetail> Gettbl_invoiceDetail()
        {
            return db.tbl_invoiceDetail;
        }

        // PUT: api/InvoiceDetail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_invoiceDetail(Guid id, string name, tbl_invoiceDetail tbl_invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_invoiceDetail.invoice_id)
            {
                return BadRequest();
            }

            tbl_invoiceDetail temp = db.tbl_invoiceDetail.FirstOrDefault(e => e.invoice_id == id && e.name.Equals(name));
            if (tbl_invoiceDetail == null)
            {
                return NotFound();
            }
            temp.name = tbl_invoiceDetail.name;
            temp.price = tbl_invoiceDetail.price;
            temp.amount = tbl_invoiceDetail.amount;
            temp.tbl_invoice = null;

            db.Entry(temp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_invoiceDetailExists(id, tbl_invoiceDetail.name))
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

        // POST: api/InvoiceDetail
        [ResponseType(typeof(tbl_invoiceDetail))]
        public IHttpActionResult Posttbl_invoiceDetail(tbl_invoiceDetail tbl_invoiceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_invoiceDetail.Add(tbl_invoiceDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_invoiceDetailExists(tbl_invoiceDetail.invoice_id,tbl_invoiceDetail.name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_invoiceDetail.invoice_id }, tbl_invoiceDetail);
        }

        // DELETE: api/InvoiceDetail/5
        [ResponseType(typeof(tbl_invoiceDetail))]
        public IHttpActionResult Deletetbl_invoiceDetail(Guid id, string name)
        {
            tbl_invoiceDetail tbl_invoiceDetail = db.tbl_invoiceDetail.FirstOrDefault(e => e.invoice_id == id && e.name.Equals(name));
            if (tbl_invoiceDetail == null)
            {
                return NotFound();
            }
            tbl_invoiceDetail.tbl_invoice = null;
            db.tbl_invoiceDetail.Remove(tbl_invoiceDetail);
            db.SaveChanges();

            return Ok(tbl_invoiceDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_invoiceDetailExists(Guid id,string name)
        {
            return db.tbl_invoiceDetail.Count(e => e.invoice_id == id && e.name.Equals(name)) > 0;
        }
    }
}