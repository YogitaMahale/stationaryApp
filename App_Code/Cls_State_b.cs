using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
public class Cls_State_b
{
	public Cls_State_b()
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
            Cls_State_db objCls_company_db = new Cls_State_db();
            dt = objCls_company_db.SelectAll();
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }

    public statemaster SelectById(Int64 cid)
    {
        statemaster  objcompany = new statemaster();
        try
        {
            Cls_State_db objCls_company_db = new Cls_State_db();

            objcompany = objCls_company_db.SelectById(cid);
            return objcompany;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return objcompany;
        }
    }
    public Int64 Insert(statemaster  objcompany)
    {
        Int64 result = 0;
        try
        {
            Cls_State_db objCls_company_db = new Cls_State_db();

            result = Convert.ToInt64(objCls_company_db.Insert(objcompany));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public Int64 Update(statemaster objcompany)
    {
        Int64 result = 0;
        try
        {
            Cls_State_db objCls_company_db = new Cls_State_db();

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
            Cls_State_db objCls_company_db = new Cls_State_db();

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
    public DataTable getState_byCountryId(Int64 id)
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_State_db objCls_company_db = new Cls_State_db();
            dt = objCls_company_db.getState_byCountryId(id);
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }
    public DataTable getCity_byStateId(Int64 id)
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_State_db objCls_company_db = new Cls_State_db();
            dt = objCls_company_db.getCity_byStateId(id);
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }


    public DataTable getSubarea_byCityId(Int64 id)
    {
        DataTable dt = new DataTable();
        try
        {
            Cls_State_db objCls_company_db = new Cls_State_db();
            dt = objCls_company_db.getSubarea_byCityId(id);
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
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