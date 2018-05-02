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
    public class LoginController : ApiController
    {
        private SmartRmDBModel db = new SmartRmDBModel();

        // POST: api/Login
        [ResponseType(typeof(tbl_user))]
        public IHttpActionResult Posttbl_user(tbl_user u)
        {
            tbl_user tbl_user = db.tbl_user.FirstOrDefault(e => e.user_name.Equals(u.user_name) && e.password.Equals(u.password));
            if (tbl_user == null)
            {
                return NotFound();
            }

            return Ok(tbl_user);
        }
    }
}