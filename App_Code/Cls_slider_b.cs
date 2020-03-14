using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
public class Cls_slider_b
{
	public Cls_slider_b()
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
            Cls_slider_db objCls_category_db = new Cls_slider_db();
            dt = objCls_category_db.SelectAll();
            return dt;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return dt;
        }
    }
    
    public slider  SelectById(Int64 cid)
    {
        slider  objcategory = new slider ();
        try
        {
            Cls_slider_db objCls_category_db = new Cls_slider_db();
            objcategory = objCls_category_db.SelectById(cid);
            return objcategory;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return objcategory;
        }
    }
        public DataTable  slider_SelectAllbybankid(Int64 cid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_slider_db objCls_category_db = new Cls_slider_db();
                dt = objCls_category_db.slider_SelectAllbybankid(cid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public Int64 Insert(slider  objcategory)
    {
        Int64 result = 0;
        try
        {
            Cls_slider_db objCls_category_db = new Cls_slider_db();
            result = Convert.ToInt64(objCls_category_db.Insert(objcategory));
            return result;
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return result;
        }
    }
    public Int64 Update(slider  objcategory)
    {
        Int64 result = 0;
        try
        {
            Cls_slider_db objCls_category_db = new Cls_slider_db();
            result = Convert.ToInt64(objCls_category_db.Update(objcategory));
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
        bool result = false;
        try
        {
            Cls_slider_db objCls_category_db = new Cls_slider_db();
            if (objCls_category_db.Delete(cid))
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        catch (Exception ex)
        {
            result = false;
            ErrHandler.writeError(ex.Message, ex.StackTrace);
        }
        return result;
    }
    

    #endregion


}
public class slider
{
    public slider()
    { }

    #region Private Variables
    private Int64 _id;
        private Int64 _bankid;

        private String _imagename;
   
    private Boolean _isdeleted;
     
    #endregion


    #region Public Properties
    public Int64 id
    {
        get { return _id; }
        set { _id = value; }
    }
    public Int64 bankid
        {
            get { return _bankid; }
            set { _bankid = value; }
        }


    public String imagename
    {
        get { return _imagename; }
        set { _imagename = value; }
    }
    
    public Boolean isdeleted
    {
        get { return _isdeleted; }
        set { _isdeleted = value; }
    }
    
    #endregion
}

}
