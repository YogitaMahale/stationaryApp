using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class Cls_productprice_db
    {
        SqlConnection ConnectionString = new SqlConnection();
        public Cls_productprice_db()
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
        //        cmd.CommandText = "productprices_SelectAll";
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
                cmd.CommandText = "getProductRatesByProductId";
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

        //public productprices SelectById(Int64 cid)
        //{
        //    SqlDataAdapter da;
        //    DataSet ds = new DataSet();
        //    productprices objproductprices = new productprices();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "productprices_SelectById";
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
        //                            objproductprices.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
        //                            objproductprices.Typeid = Convert.ToInt64(ds.Tables[0].Rows[0]["typeid"]);
        //                            objproductprices.Subcategoryid = Convert.ToInt64(ds.Tables[0].Rows[0]["subcategoryid"]);
        //                            objproductprices.Maincategoryid = Convert.ToInt64(ds.Tables[0].Rows[0]["maincategoryid"]);
        //                            objproductprices.productpricesname = Convert.ToString(ds.Tables[0].Rows[0]["productpricesname"]);

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
        //    return objproductprices;
        //}

        public Int64 Insert(productprice objproductprices)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "productprices_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objproductprices.Id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@pid", objproductprices.Pid);
                cmd.Parameters.AddWithValue("@bankid", objproductprices.Bankid);
                cmd.Parameters.AddWithValue("@price", objproductprices.Price);
                
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
        //public Int64 Update(productprices objproductprices)
        //{
        //    Int64 result = 0;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "productprices_Update";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = ConnectionString;

        //        SqlParameter param = new SqlParameter();
        //        param.ParameterName = "@id";
        //        param.Value = objproductprices.Id;
        //        param.SqlDbType = SqlDbType.BigInt;
        //        param.Direction = ParameterDirection.InputOutput;
        //        cmd.Parameters.Add(param);
        //        cmd.Parameters.AddWithValue("@typeid", objproductprices.Typeid);
        //        cmd.Parameters.AddWithValue("@productpricesname", objproductprices.productpricesname);

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
                cmd.CommandText = "productprices_Delete";
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
