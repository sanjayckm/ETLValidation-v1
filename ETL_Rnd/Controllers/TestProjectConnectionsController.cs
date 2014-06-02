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
    public class TestProjectConnectionsController : ApiController
    {
        private ETL_ValidationEntities db = new ETL_ValidationEntities();

        // GET api/TestProjectConnections
        public IEnumerable<tb_etl_validation_TestProjectConnections> Gettb_etl_validation_TestProjectConnections()
        {
            return db.tb_etl_validation_TestProjectConnections.AsEnumerable();
        }

        // GET api/TestProjectConnections/5
        public tb_etl_validation_TestProjectConnections Gettb_etl_validation_TestProjectConnections(int id)
        {
            tb_etl_validation_TestProjectConnections tb_etl_validation_testprojectconnections = db.tb_etl_validation_TestProjectConnections.Find(id);
            if (tb_etl_validation_testprojectconnections == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tb_etl_validation_testprojectconnections;
        }

        // GET api/TestProjectConnections/5
        public IList<tb_etl_validation_TestProjectConnections> Gettb_etl_validation_TestProjectConnections(int id, bool isPrimary)
        {
            IList<tb_etl_validation_TestProjectConnections> testProjectConnections;
            testProjectConnections = db.tb_etl_validation_TestProjectConnections.Where(x => x.TestProjectID == id).ToList();

            if (testProjectConnections == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return testProjectConnections;
        }

        // PUT api/TestProjectConnections/5
        public HttpResponseMessage Puttb_etl_validation_TestProjectConnections(int id, tb_etl_validation_TestProjectConnections tb_etl_validation_testprojectconnections)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tb_etl_validation_testprojectconnections.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tb_etl_validation_testprojectconnections).State = EntityState.Modified;

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

        // POST api/TestProjectConnections
        public HttpResponseMessage Posttb_etl_validation_TestProjectConnections(tb_etl_validation_TestProjectConnections tb_etl_validation_testprojectconnections)
        {
            if (ModelState.IsValid)
            {
                db.tb_etl_validation_TestProjectConnections.Add(tb_etl_validation_testprojectconnections);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tb_etl_validation_testprojectconnections);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tb_etl_validation_testprojectconnections.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/TestProjectConnections/5
        public HttpResponseMessage Deletetb_etl_validation_TestProjectConnections(int id)
        {
            tb_etl_validation_TestProjectConnections tb_etl_validation_testprojectconnections = db.tb_etl_validation_TestProjectConnections.Find(id);
            if (tb_etl_validation_testprojectconnections == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.tb_etl_validation_TestProjectConnections.Remove(tb_etl_validation_testprojectconnections);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tb_etl_validation_testprojectconnections);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}