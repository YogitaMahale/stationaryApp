using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class cls_product_db
{
        SqlConnection ConnectionString = new SqlConnection();

        public cls_product_db()
    {
            string name = string.Empty;
            string conname = string.Empty;
            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            if (connections.Count != 0)
            {
                foreach (ConnectionStringSettings connection in connections)
                {
                    name = connection.Name;
                }
                conname = "" + name + "";
            }
            ConnectionString.ConnectionString = ConfigurationManager.ConnectionStrings[conname].ConnectionString;
        }
        #region Public Methods


        public DataTable SelectAll(Int64 subcategoryId)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productmaster_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@subcategoryId", subcategoryId);
                cmd.Connection = ConnectionString;
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                ConnectionString.Close();
            }
            return ds.Tables[0];
        }

        public productmaster  SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            productmaster objbankmaster = new productmaster();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productmaster_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", id);
                ConnectionString.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                {
                                    objbankmaster.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                                    objbankmaster.brandid = Convert.ToInt64(ds.Tables[0].Rows[0]["brandid"]);
                                    objbankmaster.typeId = Convert.ToInt64(ds.Tables[0].Rows[0]["typeId"]);
                                    objbankmaster.subcategoryId = Convert.ToInt64(ds.Tables[0].Rows[0]["subcategoryId"]);
                                    objbankmaster.maincategoryId = Convert.ToInt64(ds.Tables[0].Rows[0]["maincategoryId"]);
                                    objbankmaster.productname = Convert.ToString(ds.Tables[0].Rows[0]["productname"]);
                                    objbankmaster.mainimage = Convert.ToString(ds.Tables[0].Rows[0]["mainimage"]);
                                    objbankmaster.stock = Convert.ToInt64(ds.Tables[0].Rows[0]["stock"]);
                                    objbankmaster.gst = Convert.ToDecimal (ds.Tables[0].Rows[0]["gst"]);
                                    objbankmaster.moq = Convert.ToInt64(ds.Tables[0].Rows[0]["moq"]);
                                    objbankmaster.shortdescp = Convert.ToString(ds.Tables[0].Rows[0]["shortdescp"]);
                                    objbankmaster.longdescp = Convert.ToString(ds.Tables[0].Rows[0]["longdescp"]);
 

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return null;
            }
            finally
            {
                ConnectionString.Close();
            }
            return objbankmaster;
        }

        public Int64 Insert(productmaster objproductmaster)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productmaster_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objproductmaster.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@brandid", objproductmaster.brandid);
                cmd.Parameters.AddWithValue("@productname", objproductmaster.productname);
                cmd.Parameters.AddWithValue("@mainimage", objproductmaster.mainimage);
                cmd.Parameters.AddWithValue("@stock", objproductmaster.stock );
                cmd.Parameters.AddWithValue("@gst", objproductmaster.gst);
                cmd.Parameters.AddWithValue("@moq", objproductmaster.moq );
                cmd.Parameters.AddWithValue("@shortdescp", objproductmaster.shortdescp );
                cmd.Parameters.AddWithValue("@longdescp", objproductmaster.longdescp );
 

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt64(param.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
            finally
            {
                ConnectionString.Close();
            }
            return result;
        }

        public Int64 Update(productmaster objproductmaster)

        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productmaster_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objproductmaster.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@brandid", objproductmaster.brandid);
                cmd.Parameters.AddWithValue("@productname", objproductmaster.productname);
                cmd.Parameters.AddWithValue("@mainimage", objproductmaster.mainimage);
                cmd.Parameters.AddWithValue("@stock", objproductmaster.stock);
                cmd.Parameters.AddWithValue("@gst", objproductmaster.gst);
                cmd.Parameters.AddWithValue("@moq", objproductmaster.moq);
                cmd.Parameters.AddWithValue("@shortdescp", objproductmaster.shortdescp);
                cmd.Parameters.AddWithValue("@longdescp", objproductmaster.longdescp);

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt64(param.Value);
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
            finally
            {
                ConnectionString.Close();
            }
            return result;
        }

        public bool Delete(Int64 id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productmaster_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@id", id);

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                ConnectionString.Close();
            }
            return true;
        }

        public bool IsActive(Int64 id, bool isactive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productmaster_IsActive";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@isactive", isactive);

                ConnectionString.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                ConnectionString.Close();
            }
            return true;
        }

        #endregion


    }

}
