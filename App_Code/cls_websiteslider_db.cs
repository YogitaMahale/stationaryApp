using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class cls_websiteslider_db
    {
        
        SqlConnection ConnectionString = new SqlConnection();
        public cls_websiteslider_db()
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


        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "websiteslider_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;
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
        
        public websiteslider SelectById(Int64 cid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            websiteslider objcategory = new websiteslider();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "websiteslider_SelectById";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", cid);
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

                                objcategory.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                
                                objcategory.imagename = Convert.ToString(ds.Tables[0].Rows[0]["imagename"]);


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
            return objcategory;
        }


        public Int64 Insert(websiteslider objcategory)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "websiteslider_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcategory.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                 
                cmd.Parameters.AddWithValue("@imagename", objcategory.imagename);


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

        public Int64 Update(websiteslider objcategory)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "websiteslider_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcategory.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                
                cmd.Parameters.AddWithValue("@imagename", objcategory.imagename);


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
        public bool Delete(Int64 cid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "websiteslider_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@id", cid);

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
