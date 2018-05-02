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
    public class DishesController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/Dishes
        public IQueryable<tbl_dishes> Gettbl_dishes()
        {
            return db.tbl_dishes;
        }
    }
}