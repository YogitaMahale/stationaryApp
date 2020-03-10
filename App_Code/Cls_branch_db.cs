using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_branch_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        #region Constructor
        public Cls_branch_db()
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
                cmd.CommandText = "branch_SelectAll";
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
                cmd.CommandText = "branch_SelectAllByBankId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@zoneid", id);
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
        public branch SelectById(Int64 id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            branch objbranch = new branch();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "branch_SelectById";
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
                                    //branchid, zoneid, loginname, password, emailid, name, ifsccode, micrcode, address, phone, country, state, city, pincode, branchcode, mobileNo, gstno, road, appartment, isactive, isdeleted

                                    objbranch.Branchid = Convert.ToInt64(ds.Tables[0].Rows[0]["branchid"]);
                                    objbranch.Bankid = Convert.ToInt64(ds.Tables[0].Rows[0]["bankid"]);
                                    objbranch.Zoneid = Convert.ToInt64(ds.Tables[0].Rows[0]["zoneid"]);
                                    objbranch.Loginname = Convert.ToString(ds.Tables[0].Rows[0]["loginname"]);
                                    objbranch.Password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                                    objbranch.Emailid = Convert.ToString(ds.Tables[0].Rows[0]["emailid"]);
                                    objbranch.Name = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                                    objbranch.Ifsccode= Convert.ToString(ds.Tables[0].Rows[0]["ifsccode"]);
                                    objbranch.Micrcode = Convert.ToString(ds.Tables[0].Rows[0]["micrcode"]);
                                    objbranch.Address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                                    objbranch.Phone = Convert.ToString(ds.Tables[0].Rows[0]["phone"]);
                                    objbranch.Country = Convert.ToString(ds.Tables[0].Rows[0]["country"]);
                                    objbranch.State = Convert.ToInt64(ds.Tables[0].Rows[0]["state"]);
                                    objbranch.City= Convert.ToInt64(ds.Tables[0].Rows[0]["city"]);
                                    objbranch.Pincode = Convert.ToString(ds.Tables[0].Rows[0]["pincode"]);
                                    objbranch.Branchcode = Convert.ToString(ds.Tables[0].Rows[0]["branchcode"]);
                                    objbranch.Mobileno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                                    objbranch.Gstno = Convert.ToString(ds.Tables[0].Rows[0]["gstno"]);
                                    objbranch.Road = Convert.ToString(ds.Tables[0].Rows[0]["road"]);
                                    objbranch.Apartment = Convert.ToString(ds.Tables[0].Rows[0]["apartment"]);
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
            return objbranch;
        }
        public Int64 Insert(branch objbranch)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "branch_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objbranch.Branchid;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                //branchid, zoneid, loginname, password, emailid, name, ifsccode, micrcode, address, phone, country, state, city, pincode, branchcode, mobileNo, gstno, road, appartment, isactive, isdeleted
                cmd.Parameters.AddWithValue("@zoneid", objbranch.Zoneid);
                cmd.Parameters.AddWithValue("@loginname", objbranch.Loginname);
                cmd.Parameters.AddWithValue("@password", objbranch.Password);
                cmd.Parameters.AddWithValue("@emailid", objbranch.Emailid);
                cmd.Parameters.AddWithValue("@name", objbranch.Name);
                cmd.Parameters.AddWithValue("@ifsccode", objbranch.Ifsccode);
                cmd.Parameters.AddWithValue("@micrcode", objbranch.Micrcode);
                cmd.Parameters.AddWithValue("@address", objbranch.Address);
                cmd.Parameters.AddWithValue("@phone", objbranch.Phone);
                cmd.Parameters.AddWithValue("@country", objbranch.Country);
                cmd.Parameters.AddWithValue("@state", objbranch.State);
                cmd.Parameters.AddWithValue("@city", objbranch.City);
                cmd.Parameters.AddWithValue("@pincode", objbranch.Pincode);
                cmd.Parameters.AddWithValue("@branchcode", objbranch.Branchcode);
                cmd.Parameters.AddWithValue("@mobileno", objbranch.Mobileno);
                cmd.Parameters.AddWithValue("@gstno", objbranch.Gstno);
                cmd.Parameters.AddWithValue("@road", objbranch.Road);
                cmd.Parameters.AddWithValue("@apartment", objbranch.Apartment);

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
        public Int64 Update(branch objbranch)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "branch_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objbranch.Branchid;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                //branchid, zoneid, loginname, password, emailid, name, ifsccode, micrcode, address, phone, country, state, city, pincode, branchcode, mobileNo, gstno, road, appartment, isactive, isdeleted
                cmd.Parameters.AddWithValue("@zoneid", objbranch.Zoneid);
                cmd.Parameters.AddWithValue("@loginname", objbranch.Loginname);
                cmd.Parameters.AddWithValue("@password", objbranch.Password);
                cmd.Parameters.AddWithValue("@emailid", objbranch.Emailid);
                cmd.Parameters.AddWithValue("@name", objbranch.Name);
                cmd.Parameters.AddWithValue("@ifsccode", objbranch.Ifsccode);
                cmd.Parameters.AddWithValue("@micrcode", objbranch.Micrcode);
                cmd.Parameters.AddWithValue("@address", objbranch.Address);
                cmd.Parameters.AddWithValue("@phone", objbranch.Phone);
                cmd.Parameters.AddWithValue("@country", objbranch.Country);
                cmd.Parameters.AddWithValue("@state", objbranch.State);
                cmd.Parameters.AddWithValue("@city", objbranch.City);
                cmd.Parameters.AddWithValue("@pincode", objbranch.Pincode);
                cmd.Parameters.AddWithValue("@branchcode", objbranch.Branchcode);
                cmd.Parameters.AddWithValue("@mobileno", objbranch.Mobileno);
                cmd.Parameters.AddWithValue("@gstno", objbranch.Gstno);
                cmd.Parameters.AddWithValue("@road", objbranch.Road);
                cmd.Parameters.AddWithValue("@apartment", objbranch.Apartment);

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
                cmd.CommandText = "branch_Delete";
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
        //        cmd.CommandText = "branch_SelectAllAdmin";
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
        //public DataTable branch_WSSelectAll()
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "branch_WSSelectAll";
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
        //public DataTable branch_WSSelectById(Int64 cid)
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "branch_WSSelectById";
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
        //public bool branch_IsActive(Int64 branchId, Boolean IsActive)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "branch_IsActive";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        cmd.Parameters.AddWithValue("@cid", branchId);
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
