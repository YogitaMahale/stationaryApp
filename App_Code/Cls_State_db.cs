using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
public class Cls_State_db
{
      SqlConnection ConnectionString = new SqlConnection();
	public Cls_State_db()
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
            cmd.CommandText = "state_SelectAll";
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


    public statemaster SelectById(Int64 cid)
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        statemaster objcompany = new statemaster();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "state_SelectById";
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
                            {
                                objcompany.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                objcompany.countryid = Convert.ToInt64(ds.Tables[0].Rows[0]["countryid"]);
                                objcompany.statename = Convert.ToString(ds.Tables[0].Rows[0]["statename"]);

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
        return objcompany;
    }
    public Int64 Insert(statemaster objcompany)
    {
        Int64 result = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "state_Insert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = objcompany.id;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@countryid", objcompany.countryid);
            cmd.Parameters.AddWithValue("@statename", objcompany.statename);

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
    public Int64 Update(statemaster objcompany)
    {
        Int64 result = 0;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "state_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = objcompany.id;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@countryid", objcompany.countryid);
            cmd.Parameters.AddWithValue("@statename", objcompany.statename);

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
            cmd.CommandText = "state_Delete";
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


    public DataTable getState_byCountryId(Int64 id)
    {
        SqlDataAdapter da;
        DataTable ds = new DataTable();
      
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getState_byCountryId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;
            cmd.Parameters.AddWithValue("@countryid", id);
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
        return ds;
    }
    public DataTable getCity_byStateId(Int64 id)
    {
        SqlDataAdapter da;
        DataTable ds = new DataTable();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getCity_byStateId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;
            cmd.Parameters.AddWithValue("@stateid", id);
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
        return ds;
    }


    public DataTable getSubarea_byCityId(Int64 id)
    {
        SqlDataAdapter da;
        DataTable ds = new DataTable();

        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "getSubArea_byCityId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = ConnectionString;
            cmd.Parameters.AddWithValue("@Cityid", id);
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
        return ds;
    }
    #endregion

}

}
