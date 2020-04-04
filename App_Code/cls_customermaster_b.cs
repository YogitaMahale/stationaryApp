using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_customermaster_b
    {
        public cls_customermaster_b()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Public Methods
        public DataTable customerLogin(string mobileno, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_customermaster_db objcls_customermaster_db = new cls_customermaster_db();
                dt = objcls_customermaster_db.customerLogin(mobileno,password);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                cls_customermaster_db objcls_customermaster_db = new cls_customermaster_db();
                dt = objcls_customermaster_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        public customermaster  SelectById(Int64 bankid)
        {
            customermaster objcustomermaster = new customermaster ();
            try
            {
                cls_customermaster_db objcls_customermaster_db = new cls_customermaster_db();

                objcustomermaster = objcls_customermaster_db.SelectById(bankid);
                return objcustomermaster;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcustomermaster;
            }
        }

        public Int64 Insert(customermaster objcustomermaster)
        {
            Int64 result = 0;
            try
            {
                cls_customermaster_db objcls_customermaster_db = new cls_customermaster_db();

                result = Convert.ToInt64(objcls_customermaster_db.Insert(objcustomermaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(customermaster objcustomermaster)
        {
            Int64 result = 0;
            try
            {
                cls_customermaster_db objcls_customermaster_db = new cls_customermaster_db();

                result = Convert.ToInt64(objcls_customermaster_db.Update(objcustomermaster));
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
                cls_customermaster_db objcls_customermaster_db = new cls_customermaster_db();

                if (objcls_customermaster_db.Delete(bankid))
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
    public class customermaster
    {
        public customermaster()
        { }

        #region Private Variables
        private Int64 _id;
        private String _customername;
        private String _mobileno;
        private String _emailid;
        private String _password;
        private String _address;       
        private Boolean _isactive;
        private Boolean _isdelete;
      

        
        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public String customername
        {
            get { return _customername; }
            set { _customername = value; }
        }
        public string mobileno
        {
            get { return _mobileno; }
            set { _mobileno = value; }
        }

        public string emailid
        {
            get { return _emailid; }
            set { _emailid = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string address
        {
            get { return _address; }
            set { _address = value; }
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
