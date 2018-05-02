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
    public class TableController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/Table
        public IQueryable<tbl_table> Gettbl_table()
        {
            return db.tbl_table;
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

        private bool tbl_tableExists(Guid id)
        {
            return db.tbl_table.Count(e => e.id == id) > 0;
        }
    }
}