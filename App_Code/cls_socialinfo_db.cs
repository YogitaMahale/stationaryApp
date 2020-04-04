using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class cls_socialinfo_db
    {
        SqlConnection ConnectionString = new SqlConnection();

        public cls_socialinfo_db()
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


        public DataTable SelectAll(Int64 customerid)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "socialInfo_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerid", customerid);
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

        public socialinfo SelectById(Int64 bankid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            socialinfo objsocialinfo = new socialinfo();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "socialInfo_Selectbyid";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", bankid);
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
                                
                                    objsocialinfo.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                                objsocialinfo.customerid = Convert.ToInt32(ds.Tables[0].Rows[0]["customerid"]);
                                objsocialinfo.title = Convert.ToString(ds.Tables[0].Rows[0]["title"]);
                                objsocialinfo.shortdesc = Convert.ToString(ds.Tables[0].Rows[0]["shortdesc"]);
                                objsocialinfo.longdesc = Convert.ToString(ds.Tables[0].Rows[0]["longdesc"]);
                                objsocialinfo.videourl1 = Convert.ToString(ds.Tables[0].Rows[0]["videourl1"]);

                                objsocialinfo.videourl2 = Convert.ToString(ds.Tables[0].Rows[0]["videourl2"]);
                                objsocialinfo.videourl3 = Convert.ToString(ds.Tables[0].Rows[0]["videourl3"]);
                                objsocialinfo.videourl4 = Convert.ToString(ds.Tables[0].Rows[0]["videourl4"]);

                                
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
            return objsocialinfo;
        }

        public Int64 Insert(socialinfo objsocialinfo)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "socialInfo_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objsocialinfo.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                
                    cmd.Parameters.AddWithValue("@customerid", objsocialinfo.customerid);
                cmd.Parameters.AddWithValue("@title", objsocialinfo.title );
                cmd.Parameters.AddWithValue("@shortdesc", objsocialinfo.shortdesc );
                cmd.Parameters.AddWithValue("@longdesc", objsocialinfo.longdesc  );
                cmd.Parameters.AddWithValue("@videourl1", objsocialinfo.videourl1);
                cmd.Parameters.AddWithValue("@videourl2", objsocialinfo.videourl2);
                cmd.Parameters.AddWithValue("@videourl3", objsocialinfo.videourl3);
                cmd.Parameters.AddWithValue("@videourl4", objsocialinfo.videourl4);
              


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

        public Int64 Update(socialinfo objsocialinfo)

        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "socialInfo_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objsocialinfo.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@customerid", objsocialinfo.customerid);
                cmd.Parameters.AddWithValue("@title", objsocialinfo.title);
                cmd.Parameters.AddWithValue("@shortdesc", objsocialinfo.shortdesc);
                cmd.Parameters.AddWithValue("@longdesc", objsocialinfo.longdesc);
                cmd.Parameters.AddWithValue("@videourl1", objsocialinfo.videourl1);
                cmd.Parameters.AddWithValue("@videourl2", objsocialinfo.videourl2);
                cmd.Parameters.AddWithValue("@videourl3", objsocialinfo.videourl3);
                cmd.Parameters.AddWithValue("@videourl4", objsocialinfo.videourl4);


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

        public bool Delete(Int32 bankid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "socialInfo_Delete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                cmd.Parameters.AddWithValue("@id", bankid);

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
