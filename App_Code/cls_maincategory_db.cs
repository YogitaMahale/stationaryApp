using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLayer;

namespace DatabaseLayer
{
    public class cls_maincategory_db
{
        SqlConnection ConnectionString = new SqlConnection();
        public cls_maincategory_db()
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
                cmd.CommandText = "maincategory_SelectAll";
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

       

        public mainCategoryMaster  SelectById(Int64 cid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            mainCategoryMaster objcategory = new mainCategoryMaster();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "maincategory_SelectById";
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
                                    objcategory.id = Convert.ToInt64(ds.Tables[0].Rows[0]["id"]);
                                    objcategory.categoryname = Convert.ToString(ds.Tables[0].Rows[0]["categoryname"]);
                                    objcategory.imagename = Convert.ToString(ds.Tables[0].Rows[0]["imagename"]);
                                     objcategory.shortdesc = Convert.ToString(ds.Tables[0].Rows[0]["shortdesc"]);
                                    objcategory.longdescp = Convert.ToString(ds.Tables[0].Rows[0]["longdescp"]);
                                    
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
            return objcategory;
        }

       
        public Int64 Insert(mainCategoryMaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "maincategory_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcategory.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@categoryname", objcategory.categoryname);
                cmd.Parameters.AddWithValue("@imagename", objcategory.imagename);
             
                cmd.Parameters.AddWithValue("@shortdesc", objcategory.shortdesc);
                cmd.Parameters.AddWithValue("@longdescp", objcategory.longdescp);
                

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

        public Int64 Update(mainCategoryMaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "maincategory_Update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = objcategory.id;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@categoryname", objcategory.categoryname);
                cmd.Parameters.AddWithValue("@imagename", objcategory.imagename);              
                cmd.Parameters.AddWithValue("@shortdesc", objcategory.shortdesc);
                cmd.Parameters.AddWithValue("@longdescp", objcategory.longdescp);
                
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
                cmd.CommandText = "maincategory_Delete";
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

        public bool Category_IsActive(Int64 CategoryId, Boolean IsActive)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "maincategory_IsActive";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = ConnectionString;
                cmd.Parameters.AddWithValue("@id", CategoryId);
                cmd.Parameters.AddWithValue("@isactive", IsActive);
                ConnectionString.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
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
