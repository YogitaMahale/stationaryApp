using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_zone_b
    {

        #region Constructor
        public Cls_zone_b()
        { }
        #endregion

        #region Public Methods
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_zone_db objCls_zone_db = new Cls_zone_db();
                dt = objCls_zone_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public DataTable SelectAllByBankId(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_zone_db objCls_zone_db = new Cls_zone_db();
                dt = objCls_zone_db.SelectAllByBankId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public zone SelectById(Int64 id)
        {
            zone objzone = new zone();
            try
            {
                Cls_zone_db objCls_zone_db = new Cls_zone_db();
                objzone = objCls_zone_db.SelectById(id);
                return objzone;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objzone;
            }
        }
        public Int64 Insert(zone objzone)
        {
            Int64 result = 0;
            try
            {
                Cls_zone_db objCls_zone_db = new Cls_zone_db();
                result = Convert.ToInt64(objCls_zone_db.Insert(objzone));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(zone objzone)
        {
            Int64 result = 0;
            try
            {
                Cls_zone_db objCls_zone_db = new Cls_zone_db();
                result = Convert.ToInt64(objCls_zone_db.Update(objzone));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public bool Delete(Int64 id)
        {
            bool result = false;
            try
            {
                Cls_zone_db objCls_zone_db = new Cls_zone_db();
                if (objCls_zone_db.Delete(id))
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


        #region Unused Functions

        //public DataTable SelectAllAdmin()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_zone_db objCls_zone_db = new Cls_zone_db();
        //        dt = objCls_zone_db.SelectAllAdmin();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}
        //public DataTable zone_WSSelectAll()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_zone_db objCls_zone_db = new Cls_zone_db();
        //        dt = objCls_zone_db.zone_WSSelectAll();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}
        //public DataTable zone_WSSelectById(Int64 cid)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_zone_db objCls_zone_db = new Cls_zone_db();
        //        dt = objCls_zone_db.zone_WSSelectById(cid);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}
        //public bool zone_IsActive(Int64 zoneId, Boolean IsActive)
        //{
        //    try
        //    {
        //        Cls_zone_db objCls_zone_db = new Cls_zone_db();
        //        if (objCls_zone_db.zone_IsActive(zoneId, IsActive))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}



        #endregion


    }
    public class zone
    {
        public zone()
        { }
        //id, bankid, loginname, password, name, address, mobileno, emailid, isactive, isdeleted
        #region Private Variables
        private Int64 _id;
        private String _bankname;
        private Int64 _bankid;
        private String _loginname;
        private String _password;
        private String _emailid;
        private String _name;
        private String _address;
        private String _mobileno;
        private Boolean _isactive;
        private Boolean _isdeleted;
        #endregion


        #region Public Properties
        //public int MyProperty { get; set; }
        public long id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public long Bankid
        {
            get
            {
                return _bankid;
            }

            set
            {
                _bankid = value;
            }
        }
        public string Bankname
        {
            get
            {
                return _bankname;
            }

            set
            {
                _bankname = value;
            }
        }


        public string Loginname
        {
            get
            {
                return _loginname;
            }

            set
            {
                _loginname = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Emailid
        {
            get
            {
                return _emailid;
            }

            set
            {
                _emailid = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        public string Mobileno
        {
            get
            {
                return _mobileno;
            }

            set
            {
                _mobileno = value;
            }
        }

        public bool Isactive
        {
            get
            {
                return _isactive;
            }

            set
            {
                _isactive = value;
            }
        }

        public bool Isdeleted
        {
            get
            {
                return _isdeleted;
            }

            set
            {
                _isdeleted = value;
            }
        }

        
        
        #endregion

    }

}
