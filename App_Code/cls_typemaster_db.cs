using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class cls_typemaster_db
{
        SqlConnection ConnectionString = new SqlConnection();
        public cls_typemaster_db()
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
                cmd.CommandText = "typemaster_SelectAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@categoryid", subcategoryId);
                 
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



        public typemaster SelectById(Int64 cid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            typemaster objtypemaster = new typemaster();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "typemaster_SelectById";
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
                               
                                    objtypemaster.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objtypemaster.categoryid = Convert.ToInt64(ds.Tables[0].Rows[0]["categoryid"]);
                                    objtypemaster.typename  = Convert.ToString(ds.Tables[0].Rows[0]["typename"]);
                                objtypemaster.maincategoryId  = Convert.ToInt64(ds.Tables[0].Rows[0]["maincategoryId"]);
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
            return objtypemaster;
        }


        public Int64 Insert(typemaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "typemaster_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcategory.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@categoryid", objcategory.categoryid );
                cmd.Parameters.AddWithValue("@typename", objcategory.typename );
               
                
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

        public Int64 Update(typemaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "typemaster_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcategory.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@categoryid", objcategory.categoryid );
                cmd.Parameters.AddWithValue("@typename", objcategory.typename ); 
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
                cmd.CommandText = "typemaster_Delete";
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

        //public bool Category_IsActive(Int64 CategoryId, Boolean IsActive)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "subcategory_IsActive";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        cmd.Parameters.AddWithValue("@id", CategoryId);
        //        cmd.Parameters.AddWithValue("@isactive", IsActive);
        //        ConnectionString.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        ConnectionString.Close();
        //    }
        //    return true;
        //}

        #endregion
    }

}
