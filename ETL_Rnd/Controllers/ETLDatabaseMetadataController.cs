using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETL_Rnd.Models;

namespace ETL_Rnd.Controllers
{
    public class ETLDatabaseMetadataController : ApiController
    {
        // GET api/etldatabasemetadata
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/etldatabasemetadata/5
        public string Get(int id)
        {
            return "value";
        }

        public IEnumerable<string> Get(string ServerIP, string UserID, string Password)
        {
            ETLDatabaseMetadataModel etlDBMetadata = new ETLDatabaseMetadataModel(ServerIP, UserID, Password);
            return etlDBMetadata.getDatabaseList();
        }

        // POST api/etldatabasemetadata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/etldatabasemetadata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/etldatabasemetadata/5
        public void Delete(int id)
        {
        }
    }
}
