using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
public class cls_CityMaster_b
{
	public cls_CityMaster_b()
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
            cls_CityMaster_db objCls_company_db = new cls_CityMaster_db();
            dt = objCls_company_db.SelectAll();
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }

        public DataTable SelectAllByStateId(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_CityMaster_db objCls_company_db = new cls_CityMaster_db();
                dt = objCls_company_db.SelectAllByStateId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        public citymaster SelectById(Int64 cid)
        {
        citymaster objcompany = new citymaster();
        try
        {
            cls_CityMaster_db objCls_company_db = new cls_CityMaster_db();

            objcompany = objCls_company_db.SelectById(cid);
            return objcompany;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return objcompany;
        }
    }
    public Int64 Insert(citymaster objcompany)
    {
        Int64 result = 0;
        try
        {
            cls_CityMaster_db objCls_company_db = new cls_CityMaster_db();

            result = Convert.ToInt64(objCls_company_db.Insert(objcompany));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public Int64 Update(citymaster  objcompany)
    {
        Int64 result = 0;
        try
        {
            cls_CityMaster_db objCls_company_db = new cls_CityMaster_db();

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
            cls_CityMaster_db objCls_company_db = new cls_CityMaster_db();

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
public class statemaster
{
    public statemaster()
    { }

    #region Private Variables
    private Int64 _id;
    private Int64 _countryid;
    private String _statename;


    #endregion


    #region Public Properties
    public Int64 id
    {
        get { return _id; }
        set { _id = value; }
    }
    public Int64 countryid
    {
        get { return _countryid; }
        set { _countryid = value; }
    }
    public String statename
    {
        get { return _statename; }
        set { _statename = value; }
    }

    #endregion
}

}