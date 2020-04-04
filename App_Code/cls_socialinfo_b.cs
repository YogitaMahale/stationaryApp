using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_socialinfo_b
    {
        public cls_socialinfo_b()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Public Methods

        public DataTable SelectAll(Int64 customerid)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_socialinfo_db objcls_socialinfo_db = new cls_socialinfo_db();
                dt = objcls_socialinfo_db.SelectAll(customerid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        public socialinfo  SelectById(Int64 bankid)
        {
            socialinfo  objbankmaster = new socialinfo ();
            try
            {
                cls_socialinfo_db objcls_socialinfo_db = new cls_socialinfo_db();

                objbankmaster = objcls_socialinfo_db.SelectById(bankid);
                return objbankmaster;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objbankmaster;
            }
        }

        public Int64 Insert(socialinfo  objbankmaster)
        {
            Int64 result = 0;
            try
            {
                cls_socialinfo_db objcls_socialinfo_db = new cls_socialinfo_db();

                result = Convert.ToInt64(objcls_socialinfo_db.Insert(objbankmaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(socialinfo  objbankmaster)
        {
            Int64 result = 0;
            try
            {
                cls_socialinfo_db objcls_socialinfo_db = new cls_socialinfo_db();

                result = Convert.ToInt64(objcls_socialinfo_db.Update(objbankmaster));
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
                cls_socialinfo_db objcls_socialinfo_db = new cls_socialinfo_db();

                if (objcls_socialinfo_db.Delete(bankid))
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
    public class socialinfo
    {
        public socialinfo()
        { }

        #region Private Variables
        private Int64 _id;
        private Int64 _customerid;
        private string _title;
        private string _shortdesc;
        private string _longdesc;
        private string _videourl1;
        private string _videourl2;
        private string _videourl3;
        private string _videourl4;
        private bool _isdelete;
        private bool _isactive;


        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int64 customerid
        {
            get { return _customerid; }
            set { _customerid = value; }
        }
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string shortdesc
        {
            get { return _shortdesc; }
            set { _shortdesc = value; }
        }
        public string longdesc
        {
            get { return _longdesc; }
            set { _longdesc = value; }
        }
        public string videourl1
        {
            get { return _videourl1; }
            set { _videourl1 = value; }
        }
        public string videourl2
        {
            get { return _videourl2; }
            set { _videourl2 = value; }
        }
        public string videourl3
        {
            get { return _videourl3; }
            set { _videourl3 = value; }
        }
        public string videourl4
        {
            get { return _videourl4; }
            set { _videourl4 = value; }
        }
        public bool isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }
        public bool isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }


        #endregion
    }

}
