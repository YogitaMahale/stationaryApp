using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
public class Cls_country_b
{
	public Cls_country_b()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Public Methods
    public DataTable SelectAll()
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_country_db objCls_company_db = new Cls_country_db();
            dt = objCls_company_db.SelectAll();
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }
    
    public countrymaster SelectById(Int64 cid)
    {
        countrymaster objcompany = new countrymaster();
        try
        {
            Cls_country_db objCls_company_db = new Cls_country_db();

            objcompany = objCls_company_db.SelectById(cid);
            return objcompany;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return objcompany;
        }
    }
    public Int64 Insert(countrymaster objcompany)
    {
        Int64 result = 0;
        try
        {
            Cls_country_db objCls_company_db = new Cls_country_db();

            result = Convert.ToInt64(objCls_company_db.Insert(objcompany));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public Int64 Update(countrymaster  objcompany)
    {
        Int64 result = 0;
        try
        {
            Cls_country_db objCls_company_db = new Cls_country_db();

            result = Convert.ToInt64(objCls_company_db.Update(objcompany));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public bool Delete(Int64 cid)
    {
        try
        {
            Cls_country_db objCls_company_db = new Cls_country_db();

            if (objCls_company_db.Delete(cid))
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
     
    #endregion

}
public class countrymaster
{
    public countrymaster()
    { }
     
    #region Private Variables
    private Int64 _id;
    private String _countrycode;
    private String _countryname;
 

    #endregion


    #region Public Properties
    public Int64 id
    {
        get { return _id; }
        set { _id = value; }
    }
    public String countrycode
    {
        get { return _countrycode; }
        set { _countrycode = value; }
    }
    public String countryname
    {
        get { return _countryname; }
        set { _countryname = value; }
    }
    
  
   
    #endregion
}

}