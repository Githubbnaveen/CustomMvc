using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Collections;
using CustomMvc.Models.DBCon;

namespace CustomMvc.Models.CustomMvcClass
{
    public class FormTable
    {
      

        public int TableNameID { get;  set; }
        public string FormName { get;  set; }
        public string FormType { get;  set; }

        public string FormJavaScript { get;  set; }

        public string Rights { get; set; }
         
        public FormTable()
        {
            FormJavaScript = "";
            Rights = "";
        }
        public int Save()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            DBConn Obj = new DBConn();
            try
            {
                if (this.TableNameID==0)
                    cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO FormTable  VALUES (@FormName,@Type,@JavaScript,@Rights);select SCOPE_IDENTITY();", Obj.Con);
                else
                {
                    cmd = new System.Data.SqlClient.SqlCommand("UPDATE FormTable SET FormName=@FormName,Type=@Type,JavaScript=@JavaScript,Rights=@Rights where TableId=@TableId", Obj.Con);
                    cmd.Parameters.AddWithValue("@TableId", this.TableNameID);
                }

                cmd.Parameters.AddWithValue("@FormName", this.FormName);
                cmd.Parameters.AddWithValue("@Type", this.FormType);
                if (String.IsNullOrEmpty(this.FormJavaScript))
                {
                    cmd.Parameters.AddWithValue("@JavaScript", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@JavaScript", this.FormJavaScript);
                }
                if (String.IsNullOrEmpty(this.Rights))
                {
                    cmd.Parameters.AddWithValue("@Rights", DBNull.Value);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@Rights", this.Rights);
                }
                if (this.TableNameID ==0)
                    this.TableNameID =int.Parse(cmd.ExecuteScalar().ToString());
                else
                {
                    if (cmd.ExecuteNonQuery() <= 0)
                        this.TableNameID = 0;
                }
            }
            catch (System.Exception e) { this.TableNameID = 0; e.ToString(); }
            finally { cmd.Dispose(); Obj.ConClose(Obj.Con); }
            return this.TableNameID;
        }

        public List<FormTable> TableList()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader SDR = null;
            List<FormTable> ListTmp = new List<FormTable>();
            FormTable ObjTmp = null;
            DBConn Obj = new DBConn();
            try
            {
                string Query = "SELECT * FROM FormTable ORDER BY TableId DESC";
                cmd = new System.Data.SqlClient.SqlCommand(Query, Obj.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    ObjTmp = new FormTable();
                    ObjTmp.TableNameID =int.Parse(SDR["TableId"].ToString());
                    ObjTmp.FormName = SDR["FormName"].ToString();
                    ObjTmp.FormType = SDR["Type"].ToString();
                    ObjTmp.FormJavaScript = SDR["JavaScript"].ToString();
                    ObjTmp.Rights = SDR["Rights"].ToString();
                    ListTmp.Add(ObjTmp);
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); SDR.Close(); Obj.Con.Close(); Obj.Con.Dispose(); Obj.Con = null; }
            return (ListTmp);
        }


        public int CreateTable()
        {
            int TableNameId = 0;
            string TablePrefix = System.Configuration.ConfigurationManager.AppSettings["TablePrefix"].ToString();
            System.Data.SqlClient.SqlCommand cmd = null;
            DBConn Conn = new DBConn();

            try
            {
                cmd = new System.Data.SqlClient.SqlCommand("Create Table " + TablePrefix + this.TableNameID.ToString(),Conn.Con);
                TableNameId = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (System.Exception e) { TableNameId = 0; e.ToString(); }
            finally { cmd.Dispose(); Conn.ConClose(Conn.Con); }

            return TableNameId;
        }
    }







}
