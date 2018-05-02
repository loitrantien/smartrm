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
    public class MenuTypeController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/MenuType
        public IQueryable<tbl_menuType> Gettbl_menuType()
        {
            return db.tbl_menuType;
        }

        // GET: api/MenuType/5
        [ResponseType(typeof(tbl_menuType))]
        public IHttpActionResult Gettbl_menuType(Guid id)
        {
            tbl_menuType tbl_menuType = db.tbl_menuType.Find(id);
            if (tbl_menuType == null)
            {
                return NotFound();
            }

            return Ok(tbl_menuType);
        }



        private bool tbl_menuTypeExists(Guid id)
        {
            return db.tbl_menuType.Count(e => e.id == id) > 0;
        }
    }
}