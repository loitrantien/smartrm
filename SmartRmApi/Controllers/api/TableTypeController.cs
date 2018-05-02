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
    public class TableTypeController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/TableType
        public IQueryable<tbl_tableType> Gettbl_tableType()
        {
            return db.tbl_tableType;
        }

        private bool tbl_tableTypeExists(Guid id)
        {
            return db.tbl_tableType.Count(e => e.id == id) > 0;
        }
    }
}