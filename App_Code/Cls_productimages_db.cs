using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_productimage_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        public Cls_productimage_db()
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
        //public DataTable SelectAll()
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "productimages_SelectAll";
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

        public DataTable SelectAllByProductId(Int64 pid)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "getProductImagesByProductId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@pid", pid);

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

        //public productimages SelectById(Int64 cid)
        //{
        //    SqlDataAdapter da;
        //    DataSet ds = new DataSet();
        //    productimages objproductimages = new productimages();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "productimages_SelectById";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;
        //        cmd.Parameters.AddWithValue("@id", cid);
        //        ConnectionString.Open();
        //        da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);

        //        if (ds != null)
        //        {
        //            if (ds.Tables.Count > 0)
        //            {
        //                if (ds.Tables[0] != null)
        //                {
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        {
        //                            objproductimages.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
        //                            objproductimages.Typeid = Convert.ToInt64(ds.Tables[0].Rows[0]["typeid"]);
        //                            objproductimages.Subcategoryid = Convert.ToInt64(ds.Tables[0].Rows[0]["subcategoryid"]);
        //                            objproductimages.Maincategoryid = Convert.ToInt64(ds.Tables[0].Rows[0]["maincategoryid"]);
        //                            objproductimages.productimagesname = Convert.ToString(ds.Tables[0].Rows[0]["productimagesname"]);

        //                        }
        //                    }
        //                }
        //            }
        //        }
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
        //    return objproductimages;
        //}

        public Int64 Insert(productimage objproductimages)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productimages_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objproductimages.Id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@pid", objproductimages.Pid);
                cmd.Parameters.AddWithValue("@imagename", objproductimages.Imagename);

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
        //public Int64 Update(productimages objproductimages)
        //{
        //    Int64 result = 0;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "productimages_Update";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;

        //        SqlParameter param = new SqlParameter();
        //        param.ParameterName = "@id";
        //        param.Value = objproductimages.Id;
        //        param.SqlDbType = SqlDbType.BigInt;
        //        param.Direction = ParameterDirection.InputOutput;
        //        cmd.Parameters.Add(param);
        //        cmd.Parameters.AddWithValue("@typeid", objproductimages.Typeid);
        //        cmd.Parameters.AddWithValue("@productimagesname", objproductimages.productimagesname);

        //        ConnectionString.Open();
        //        cmd.ExecuteNonQuery();
        //        result = Convert.ToInt64(param.Value);




        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return result;
        //    }
        //    finally
        //    {
        //        ConnectionString.Close();
        //    }
        //    return result;
        //}
        public bool Delete(Int64 cid)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productimages_Delete";
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
