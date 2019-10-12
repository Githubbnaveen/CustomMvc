using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace CustomMvc.Models.DBCon
{
    public class DBConn
    {
        public SqlConnection Con;
        public DBConn()
        {
            
        Con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConFFT"].ToString());
            Con.Open();
        }
        public void ConClose(SqlConnection conn)
        {
            conn.Close();
            conn.Dispose();
        }
    }
}