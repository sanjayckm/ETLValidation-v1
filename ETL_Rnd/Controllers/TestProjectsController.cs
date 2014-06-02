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
    public class TestProjectsController : ApiController
    {
        private ETL_ValidationEntities db = new ETL_ValidationEntities();

        // GET api/TestProjects
        public IEnumerable<tb_etl_validation_TestProjects> Gettb_etl_validation_TestProjects()
        {
            return db.tb_etl_validation_TestProjects.AsEnumerable();
        }

        // GET api/TestProjects/5
        public tb_etl_validation_TestProjects Gettb_etl_validation_TestProjects(int id)
        {
            tb_etl_validation_TestProjects tb_etl_validation_testprojects = db.tb_etl_validation_TestProjects.Find(id);
            if (tb_etl_validation_testprojects == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tb_etl_validation_testprojects;
        }

        // PUT api/TestProjects/5
        public HttpResponseMessage Puttb_etl_validation_TestProjects(int id, tb_etl_validation_TestProjects tb_etl_validation_testprojects)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tb_etl_validation_testprojects.TestProjectID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tb_etl_validation_testprojects).State = EntityState.Modified;

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

        // POST api/TestProjects
        public HttpResponseMessage Posttb_etl_validation_TestProjects(tb_etl_validation_TestProjects tb_etl_validation_testprojects)
        {
            if (ModelState.IsValid)
            {
                db.tb_etl_validation_TestProjects.Add(tb_etl_validation_testprojects);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tb_etl_validation_testprojects);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tb_etl_validation_testprojects.TestProjectID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/TestProjects/5
        public HttpResponseMessage Deletetb_etl_validation_TestProjects(int id)
        {
            tb_etl_validation_TestProjects tb_etl_validation_testprojects = db.tb_etl_validation_TestProjects.Find(id);
            if (tb_etl_validation_testprojects == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tb_etl_validation_TestProjects.Remove(tb_etl_validation_testprojects);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tb_etl_validation_testprojects);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}