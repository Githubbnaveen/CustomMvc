using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using CustomMvc.Models.DBCon;

namespace CustomMvc.Models.CustomMvcClass
{
    public class FormPropertyTable
    {
      
        public int TableFieldId { get; set; }
        public int FormTableId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldValue { get; set; }
        public string DefualValue { get;  set; }
        public int FormFieldOrder { get;  set; }
        public string FieldColSpan { get; set; }
        public string FiledClass { get;  set; }
        public bool DisplayInDataTable { get;  set; }
        public string Format { get;  set; }
        public string JavaScript { get;  set; }

        public string CheckRights { get;  set; }


        public int Save()
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            DBConn Obj = new DBConn();
            try
            {
                
                if (this.TableFieldId == 0)
                    cmd = new System.Data.SqlClient.SqlCommand("INSERT INTO FormTableProperty  VALUES (@FormTableId,@FormFieldName,@FieldType,@FieldValue,@DefaultValue,@FormFieldOrder,@FieldColSpan,@Class,@Format,@JavaScript,@CheckRights,@DisplayInDataTable);select SCOPE_IDENTITY();", Obj.Con);
                else
                {
                    cmd = new System.Data.SqlClient.SqlCommand("UPDATE FormTableProperty SET FormTableId=@FormTableId,FormFieldName=@FormFieldName,FieldType=@FieldType,FieldValue=@FieldValue,DefaultValue=@DefaultValue,FormFieldOrder=@FormFieldOrder,FieldColSpan=@FieldColSpan,Class=@Class,Format=@Format,JavaScript=@JavaScript,CheckRights=@CheckRights,DisplayInDataTable=@DisplayInDataTable where TableFieldId=@TableFieldId", Obj.Con);
                    cmd.Parameters.AddWithValue("@TableFieldId", this.TableFieldId);
                }

                cmd.Parameters.AddWithValue("@FormTableId", this.FormTableId);
                cmd.Parameters.AddWithValue("@FormFieldName", this.FieldName);
                cmd.Parameters.AddWithValue("@FieldType", this.FieldType);
                
                cmd.Parameters.AddWithValue("@FormFieldOrder", this.FormFieldOrder);
                cmd.Parameters.AddWithValue("@FieldColSpan", this.FieldColSpan);
                cmd.Parameters.AddWithValue("@DisplayInDataTable", this.DisplayInDataTable);
                if (string.IsNullOrEmpty(this.FieldValue))
                {
                    cmd.Parameters.AddWithValue("@FieldValue", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FieldValue", this.FieldValue);
                }
                if (string.IsNullOrEmpty(this.DefualValue))
                {
                    cmd.Parameters.AddWithValue("@DefaultValue", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DefaultValue", this.DefualValue);
                }
                if (string.IsNullOrEmpty(this.FiledClass))
                {
                    cmd.Parameters.AddWithValue("@Class",DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Class", this.FiledClass);
                }
                
                if (string.IsNullOrEmpty(this.Format))
                {
                    cmd.Parameters.AddWithValue("@Format", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Format", this.Format);
                }
                if (string.IsNullOrEmpty(this.JavaScript))
                {
                    cmd.Parameters.AddWithValue("@JavaScript", DBNull.Value);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@JavaScript", this.JavaScript);
                }
                if (string.IsNullOrEmpty(this.CheckRights))
                {
                    cmd.Parameters.AddWithValue("@CheckRights", DBNull.Value);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@CheckRights", this.CheckRights);
                }

                if (this.TableFieldId == 0)
                    this.TableFieldId = int.Parse(cmd.ExecuteScalar().ToString());
                else
                {
                    if (cmd.ExecuteNonQuery() <= 0)
                        this.TableFieldId = 0;
                }
            }
            catch (System.Exception e) { this.TableFieldId = 0; e.ToString(); }
            finally { cmd.Dispose(); Obj.ConClose(Obj.Con); }
            return this.TableFieldId;
        }

        public List<FormPropertyTable> FormFieldList(int formmid)
        {
            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader SDR = null;
            List<FormPropertyTable> ListTmp = new List<FormPropertyTable>();
            FormPropertyTable ObjTmp = null;
            DBConn Obj = new DBConn();
            try
            {
                string Query = "SELECT * FROM FormTableProperty where FormTableId="+formmid;
                cmd = new System.Data.SqlClient.SqlCommand(Query, Obj.Con);
                SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
      
        ObjTmp = new FormPropertyTable();
                    ObjTmp.TableFieldId = int.Parse(SDR["TableFieldId"].ToString());
                    ObjTmp.FormTableId = int.Parse(SDR["FormTableId"].ToString());
                    ObjTmp.FieldName = SDR["FormFieldName"].ToString();
                    ObjTmp.FieldType = SDR["FieldType"].ToString();
                    ObjTmp.FieldValue = SDR["FieldValue"].ToString();
                    ObjTmp.DefualValue = SDR["DefaultValue"].ToString();
                    ObjTmp.FormFieldOrder =int.Parse(SDR["FormFieldOrder"].ToString());
                    ObjTmp.FieldColSpan= SDR["FieldColSpan"].ToString();
                    ObjTmp.FiledClass = SDR["Class"].ToString();
                    ObjTmp.Format = SDR["Format"].ToString();
                    ObjTmp.JavaScript = SDR["JavaScript"].ToString();
                    ObjTmp.CheckRights = SDR["CheckRights"].ToString();
                    ObjTmp.DisplayInDataTable = (bool)(SDR["DisplayInDataTable"]) ;
                    ListTmp.Add(ObjTmp);
                }
            }
            catch (System.Exception e) { e.ToString(); }
            finally { cmd.Dispose(); SDR.Close(); Obj.Con.Close(); Obj.Con.Dispose(); Obj.Con = null; }
            return (ListTmp);
        }


    }
}