using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_branch_b
    {

        #region Constructor
        public Cls_branch_b()
        { }
        #endregion

        #region Public Methods
        public DataTable SelectAll()
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                dt = objCls_branch_db.SelectAll();
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
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                dt = objCls_branch_db.SelectAllByBankId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public branch SelectById(Int64 id)
        {
            branch objbranch = new branch();
            try
            {
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                objbranch = objCls_branch_db.SelectById(id);
                return objbranch;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objbranch;
            }
        }
        public Int64 Insert(branch objbranch)
        {
            Int64 result = 0;
            try
            {
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                result = Convert.ToInt64(objCls_branch_db.Insert(objbranch));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(branch objbranch)
        {
            Int64 result = 0;
            try
            {
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                result = Convert.ToInt64(objCls_branch_db.Update(objbranch));
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
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                if (objCls_branch_db.Delete(id))
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

        public bool ToggleIsActive(Int64 id)
        {
            try
            {
                Cls_branch_db objCls_branch_db = new Cls_branch_db();
                if (objCls_branch_db.ToggleIsActive(id))
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


        #region Unused Functions

        //public DataTable SelectAllAdmin()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_branch_db objCls_branch_db = new Cls_branch_db();
        //        dt = objCls_branch_db.SelectAllAdmin();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}
        //public DataTable branch_WSSelectAll()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_branch_db objCls_branch_db = new Cls_branch_db();
        //        dt = objCls_branch_db.branch_WSSelectAll();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}
        //public DataTable branch_WSSelectById(Int64 cid)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_branch_db objCls_branch_db = new Cls_branch_db();
        //        dt = objCls_branch_db.branch_WSSelectById(cid);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}
        //public bool branch_IsActive(Int64 branchId, Boolean IsActive)
        //{
        //    try
        //    {
        //        Cls_branch_db objCls_branch_db = new Cls_branch_db();
        //        if (objCls_branch_db.branch_IsActive(branchId, IsActive))
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
    public class branch
    {
        public branch()
        { }

        #region Private Variables
        private Int64 _branchid;
        private Int64 _bankid;
        private String _bankname;
        private Int64 _zoneid;
        private String _zonename;
        private String _loginname;
        private String _password;
        private String _emailid;
        private String _name;
        private String _ifsccode;
        private String _micrcode;
        private String _address;
        private String _phone;
        private String _country;
        private Int64 _state;
        private Int64 _city;
        private String _statename;
        private String _cityname;
        private String _pincode;
        private String _branchcode;
        private String _mobileno;
        private String _gstno;
        private String _road;
        private String _apartment;
        private Boolean _isactive;
        private Boolean _isdeleted;
        #endregion


        #region Public Properties
        //public int MyProperty { get; set; }
        public long Zoneid
        {
            get
            {
                return _zoneid;
            }

            set
            {
                _zoneid = value;
            }
        }

        public long Branchid
        {
            get
            {
                return _branchid;
            }

            set
            {
                _branchid = value;
            }
        }

        public string Zonename
        {
            get
            {
                return _zonename;
            }

            set
            {
                _zonename = value;
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

        public string Ifsccode
        {
            get
            {
                return _ifsccode;
            }

            set
            {
                _ifsccode = value;
            }
        }

        public string Micrcode
        {
            get
            {
                return _micrcode;
            }

            set
            {
                _micrcode = value;
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

        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public long State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        public long City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }

        public string Statename
        {
            get
            {
                return _statename;
            }

            set
            {
                _statename = value;
            }
        }

        public string Cityname
        {
            get
            {
                return _cityname;
            }

            set
            {
                _cityname = value;
            }
        }

        public string Pincode
        {
            get
            {
                return _pincode;
            }

            set
            {
                _pincode = value;
            }
        }

        public string Branchcode
        {
            get
            {
                return _branchcode;
            }

            set
            {
                _branchcode = value;
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

        public string Gstno
        {
            get
            {
                return _gstno;
            }

            set
            {
                _gstno = value;
            }
        }

        public string Road
        {
            get
            {
                return _road;
            }

            set
            {
                _road = value;
            }
        }

        public string Apartment
        {
            get
            {
                return _apartment;
            }

            set
            {
                _apartment = value;
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

        #endregion

    }

}
