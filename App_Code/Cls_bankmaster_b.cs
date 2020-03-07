using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_bankmaster_b
    {
        public Cls_bankmaster_b()
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
                Cls_bankmaster_db objCls_bankmaster_db = new Cls_bankmaster_db();
                dt = objCls_bankmaster_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        

        public bankmaster SelectById(Int64 bankid)
        {
            bankmaster objbankmaster = new bankmaster();
            try
            {
                Cls_bankmaster_db objCls_bankmaster_db = new Cls_bankmaster_db();

                objbankmaster = objCls_bankmaster_db.SelectById(bankid);
                return objbankmaster;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objbankmaster;
            }
        }

        public Int64 Insert(bankmaster objbankmaster)
        {
            Int64 result = 0;
            try
            {
                Cls_bankmaster_db objCls_bankmaster_db = new Cls_bankmaster_db();

                result = Convert.ToInt64(objCls_bankmaster_db.Insert(objbankmaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(bankmaster objbankmaster)
        {
            Int64 result = 0;
            try
            {
                Cls_bankmaster_db objCls_bankmaster_db = new Cls_bankmaster_db();

                result = Convert.ToInt64(objCls_bankmaster_db.Update(objbankmaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public bool Delete(Int32 bankid)
        {
            try
            {
                Cls_bankmaster_db objCls_bankmaster_db = new Cls_bankmaster_db();

                if (objCls_bankmaster_db.Delete(bankid))
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

        public bool IsActive(Int32 bankid, bool isActive)
        {
            try
            {
                Cls_bankmaster_db objCls_bankmaster_db = new Cls_bankmaster_db();
                if (objCls_bankmaster_db.IsActive(bankid, isActive))
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
    public class bankmaster
    {
        public bankmaster()
        { }

        #region Private Variables
        private Int64 _id;
        private String _bankname;        
        private Boolean _isactive;
        private Boolean _isdelete;
         
       


        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public String bankname
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
       
        public Boolean isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        public Boolean isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

     
        #endregion
    }

}
