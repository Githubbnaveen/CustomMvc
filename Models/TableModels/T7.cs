using System;
using System.Collections.Generic;
using CustomMvc.Models.DBCon;
using System.Web;

namespace CustomMvc.Models.TableModels
{
    public class T7
    {

        public string F8 { get; set; }
        public string F9 { get; set; }


        public string Save()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            DBConn Obj = new DBConn();
            try
            {
                
                    cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO FormTable  VALUES (@F8,@F9);select SCOPE_IDENTITY();", Obj.Con);
                
                cmd.Parameters.AddWithValue("@F8", this.F8);
                cmd.Parameters.AddWithValue("@F9", this.F9);
                
                    this.F8 = cmd.ExecuteScalar().ToString();
                
            }
            catch (System.Exception e) { this.F8 = null; e.ToString(); }
            finally { cmd.Dispose(); Obj.ConClose(Obj.Con); }
            return this.F8;
        }
        public List<T7> GetAll()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader SDR = null;
            List<T7> ListTmp = new List<T7>();
            T7 ObjTmp = null;
            DBConn Obj = new DBConn();
            try
            {
                string Query = "SELECT * FROM T7";
                cmd = new System.Data.SqlClient.SqlCommand(Query, Obj.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {

                    ObjTmp = new T7();
                    ObjTmp.F8 = SDR["F8"].ToString();
                    ObjTmp.F9 = SDR["F9"].ToString();
                    ListTmp.Add(ObjTmp);
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); SDR.Close(); Obj.Con.Close(); Obj.Con.Dispose(); Obj.Con = null; }
            return (ListTmp);
        }



    }
}