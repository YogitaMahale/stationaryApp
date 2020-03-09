using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_zone_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        #region Constructor
        public Cls_zone_db()
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
        #endregion

        #region Public Methods

        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "zone_SelectAll";
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
        public DataTable SelectAllByBankId(Int64 id)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "getZonesByBankId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@bankid", id);
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
        public zone SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            zone objzone = new zone();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "zone_SelectById";
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
                                    //id, bankid, loginname, password, name, address, mobileno, emailid, isactive, isdeleted
                                    
                                    objzone.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objzone.Bankid = Convert.ToInt64(ds.Tables[0].Rows[0]["bankid"]);
                                    objzone.Loginname = Convert.ToString(ds.Tables[0].Rows[0]["loginname"]);
                                    objzone.Password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                                    objzone.Name = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                                    objzone.Address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                                    objzone.Mobileno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                                    objzone.Emailid = Convert.ToString(ds.Tables[0].Rows[0]["emailid"]);
                                    
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
            return objzone;
        }
        public Int64 Insert(zone objzone)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "zone_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objzone.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                
                //id, bankid, loginname, password, name, address, mobileno, emailid, isactive, isdeleted
                
                cmd.Parameters.AddWithValue("@bankid", objzone.Bankid);
                cmd.Parameters.AddWithValue("@loginname", objzone.Loginname);
                cmd.Parameters.AddWithValue("@password", objzone.Password);
                cmd.Parameters.AddWithValue("@emailid", objzone.Emailid);
                cmd.Parameters.AddWithValue("@name", objzone.Name);
                cmd.Parameters.AddWithValue("@address", objzone.Address);
                cmd.Parameters.AddWithValue("@mobileno", objzone.Mobileno);
                
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
        public Int64 Update(zone objzone)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "zone_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objzone.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@bankid", objzone.Bankid);
                cmd.Parameters.AddWithValue("@loginname", objzone.Loginname);
                cmd.Parameters.AddWithValue("@password", objzone.Password);
                cmd.Parameters.AddWithValue("@emailid", objzone.Emailid);
                cmd.Parameters.AddWithValue("@name", objzone.Name);
                cmd.Parameters.AddWithValue("@address", objzone.Address);
                cmd.Parameters.AddWithValue("@mobileno", objzone.Mobileno);

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
                cmd.CommandText = "zone_Delete";
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

        #endregion


        #region Unused Functions

        //public DataTable SelectAllAdmin()
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "zone_SelectAllAdmin";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        ConnectionString.Open();
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return null;
        //    }
        //    finally
        //    {
        //        ConnectionString.Close();
        //    }
        //    return ds.Tables[0];
        //}
        //public DataTable zone_WSSelectAll()
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "zone_WSSelectAll";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        ConnectionString.Open();
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return null;
        //    }
        //    finally
        //    {
        //        ConnectionString.Close();
        //    }
        //    return ds.Tables[0];
        //}
        //public DataTable zone_WSSelectById(Int64 cid)
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "zone_WSSelectById";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        cmd.Parameters.AddWithValue("@cid", cid);
        //        ConnectionString.Open();
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return null;
        //    }
        //    finally
        //    {
        //        ConnectionString.Close();
        //    }
        //    return ds.Tables[0];
        //}
        //public bool zone_IsActive(Int64 zoneId, Boolean IsActive)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "zone_IsActive";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        cmd.Parameters.AddWithValue("@cid", zoneId);
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
