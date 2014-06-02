using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ETL_Rnd.Models;

namespace ETL_Rnd.Controllers
{
    public class UsersController : ApiController
    {
        private ETL_ValidationEntities db = new ETL_ValidationEntities();

        // GET api/Users
        public IEnumerable<tb_etl_valid_user> Gettb_etl_valid_user()
        {
            return db.tb_etl_valid_user.AsEnumerable();
        }

        // GET api/Users/5
        public tb_etl_valid_user Gettb_etl_valid_user(int id)
        {
            tb_etl_valid_user tb_etl_valid_user = db.tb_etl_valid_user.Find(id);
            if (tb_etl_valid_user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tb_etl_valid_user;
        }

        // PUT api/Users/5
        public HttpResponseMessage Puttb_etl_valid_user(int id, tb_etl_valid_user tb_etl_valid_user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tb_etl_valid_user.UserId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tb_etl_valid_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Users
        public HttpResponseMessage Posttb_etl_valid_user(tb_etl_valid_user tb_etl_valid_user)
        {
            if (ModelState.IsValid)
            {
                db.tb_etl_valid_user.Add(tb_etl_valid_user);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tb_etl_valid_user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tb_etl_valid_user.UserId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Users/5
        public HttpResponseMessage Deletetb_etl_valid_user(int id)
        {
            tb_etl_valid_user tb_etl_valid_user = db.tb_etl_valid_user.Find(id);
            if (tb_etl_valid_user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tb_etl_valid_user.Remove(tb_etl_valid_user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tb_etl_valid_user);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}