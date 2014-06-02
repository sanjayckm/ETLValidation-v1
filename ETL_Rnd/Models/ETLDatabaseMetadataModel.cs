using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ETL_Rnd.Models
{
    public enum ServerTypes
    {
        SQLServer,
        Oracle
    }
    public class ETLDatabaseMetadataModel
    {
        private SqlConnectionStringBuilder SqlConStringBuilder;

        public ServerTypes ServerType { get; set; }
        public string ServerIP { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }

        public ETLDatabaseMetadataModel() {
        }

        public ETLDatabaseMetadataModel(string ServerIP, string UserID, string Password)
        {
            this.ServerIP = ServerIP;
            this.UserID = UserID;
            this.Password = Password;
        }

        public IEnumerable<string> getDatabaseList()
        {
            DataTable databaseList;
            List<string> dbList = new List<string>();

            SqlConStringBuilder = new SqlConnectionStringBuilder();
            SqlConStringBuilder.DataSource = ServerIP;
            SqlConStringBuilder.UserID = UserID;
            SqlConStringBuilder.Password = Password;

            using (SqlConnection con = new SqlConnection(SqlConStringBuilder.ConnectionString))
            {
                con.Open();
                //SqlCommand cmd = new SqlCommand("sp_databases", con);
                databaseList = con.GetSchema("Databases");
                con.Close();
            }
            foreach(DataRow row in databaseList.Rows) {
                dbList.Add(row["database_name"].ToString());
            }
            return dbList;
        }
    }
}