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
    public class DishesTypeController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // GET: api/DishesType
        public IQueryable<tbl_dishesType> Gettbl_dishesType()
        {
            return db.tbl_dishesType;
        }
    }
}