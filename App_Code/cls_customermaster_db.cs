using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class cls_customermaster_db
    {
        SqlConnection ConnectionString = new SqlConnection();

        public cls_customermaster_db()
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


        public DataTable customerLogin(string mobileno,string password)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mobileno", mobileno);
                cmd.Parameters.AddWithValue("@password", password);
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
        public DataTable SelectAll()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_SelectAll";
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

        public customermaster SelectById(Int64 bankid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            customermaster objcustomermaster = new customermaster();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Selectbyid";
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

                                objcustomermaster.id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
                                objcustomermaster.customername = Convert.ToString(ds.Tables[0].Rows[0]["customername"]);
                                objcustomermaster.mobileno = Convert.ToString(ds.Tables[0].Rows[0]["mobileno"]);
                                objcustomermaster.emailid = Convert.ToString(ds.Tables[0].Rows[0]["emailid"]);
                                objcustomermaster.password = Convert.ToString(ds.Tables[0].Rows[0]["password"]);
                                objcustomermaster.address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                              
                                //id, customername, mobileno, emailid, password, address, isactive, isdelete
                                
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
            return objcustomermaster ;
        }

        public Int64 Insert(customermaster objcustomermaster)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcustomermaster.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@customername", objcustomermaster.customername);
                cmd.Parameters.AddWithValue("@mobileno", objcustomermaster.mobileno);
                cmd.Parameters.AddWithValue("@emailid", objcustomermaster.emailid);
                cmd.Parameters.AddWithValue("@password", objcustomermaster.password);
                cmd.Parameters.AddWithValue("@address", objcustomermaster.address);
                
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

        public Int64 Update(customermaster objcustomermaster)

        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "customer_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcustomermaster.id;
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@customername", objcustomermaster.customername);
                cmd.Parameters.AddWithValue("@mobileno", objcustomermaster.mobileno);
                cmd.Parameters.AddWithValue("@emailid", objcustomermaster.emailid);
                cmd.Parameters.AddWithValue("@password", objcustomermaster.password);
                cmd.Parameters.AddWithValue("@address", objcustomermaster.address);
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
                cmd.CommandText = "customer_Delete";
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
