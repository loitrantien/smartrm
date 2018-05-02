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
    public class InvoiceController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/Invoice
        public IQueryable<tbl_invoice> Gettbl_invoice()
        {
            return db.tbl_invoice;
        }

        // GET: api/Invoice/5
        [ResponseType(typeof(tbl_invoice))]
        public IHttpActionResult Gettbl_invoice(Guid id)
        {
            tbl_invoice tbl_invoice = db.tbl_invoice.Find(id);
            if (tbl_invoice == null)
            {
                return NotFound();
            }

            return Ok(tbl_invoice);
        }

        // PUT: api/Invoice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_invoice(Guid id, tbl_invoice tbl_invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_invoice.id)
            {
                return BadRequest();
            }
            ICollection<tbl_invoiceDetail> newDetails = tbl_invoice.tbl_invoiceDetail;
            tbl_invoice.tbl_invoiceDetail = null;
            tbl_invoice.tbl_table = null;
            tbl_invoice.tbl_user = null;

            db.Entry(tbl_invoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_invoiceExists(id))
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
                ICollection<tbl_invoiceDetail> oldDetails = db.tbl_invoiceDetail.Where(e => e.tbl_invoice.id == id).ToList();


                foreach (var oldDetail in oldDetails)
                {
                    if (!(newDetails.Count(e => e.invoice_id == oldDetail.invoice_id && e.name.Equals(oldDetail.name)) > 0))
                    {
                        if (oldDetail != null)
                        {
                            oldDetail.tbl_invoice = null;
                            db.tbl_invoiceDetail.Remove(oldDetail);
                            db.SaveChanges();
                        }
                    }
                }

                foreach (var item in newDetails)
                {
                    tbl_invoiceDetail temp = db.tbl_invoiceDetail.FirstOrDefault(e => e.invoice_id == item.invoice_id && e.name.Equals(item.name));

                    if (temp == null)
                    {
                        item.tbl_invoice = null;
                        db.tbl_invoiceDetail.Add(item);
                    }
                    else
                    {
                        temp.name = item.name;
                        temp.price = item.price;
                        temp.amount = item.amount;
                        temp.tbl_invoice = null;
                        db.Entry(temp).State = EntityState.Modified;
                    }

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!(db.tbl_invoiceDetail.Count(e => e.invoice_id == item.invoice_id && e.name.Equals(item.name)) > 0))
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

        // POST: api/Invoice
        [ResponseType(typeof(tbl_invoice))]
        public IHttpActionResult Posttbl_invoice(tbl_invoice tbl_invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ICollection<tbl_invoiceDetail> details = tbl_invoice.tbl_invoiceDetail;
            tbl_invoice.tbl_invoiceDetail = null;
            tbl_invoice.tbl_table = null;
            tbl_invoice.tbl_user = null;
            db.tbl_invoice.Add(tbl_invoice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_invoiceExists(tbl_invoice.id))
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
                        item.tbl_invoice = null;
                        db.tbl_invoiceDetail.Add(item);
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        if (db.tbl_invoiceDetail.Count(e => e.invoice_id == item.invoice_id && e.name.Equals(item.name)) > 0)
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
            

            return CreatedAtRoute("DefaultApi", new { id = tbl_invoice.id }, tbl_invoice);
        }

        private bool tbl_invoiceExists(Guid id)
        {
            return db.tbl_invoice.Count(e => e.id == id) > 0;
        }
    }
}