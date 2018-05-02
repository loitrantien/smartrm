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
    public class FloorController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/Floor
        public IQueryable<tbl_floor> Gettbl_floor()
        {
            return db.tbl_floor;
        }

    }
}