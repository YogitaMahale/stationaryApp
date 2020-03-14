using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_order_b
    {
        public cls_order_b()
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
                cls_order_db objcls_order_db = new cls_order_db();
                dt = objcls_order_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable orderSelectAllby_branchId(Int64 branchid)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_order_db objcls_order_db = new cls_order_db();
                dt = objcls_order_db.orderSelectAllby_branchId(branchid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public DataTable order_SelectAllByZoneId(Int64 zoneid)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_order_db objcls_order_db = new cls_order_db();
                dt = objcls_order_db.order_SelectAllByZoneId(zoneid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        public orders  SelectById(Int64 cid)
        {
            orders objorders= new orders();
            try
            {
                cls_order_db objcls_order_db = new cls_order_db();

                objorders  = objcls_order_db.SelectById(cid);
                return objorders;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objorders;
            }
        }
        public Int64 Insert(orders  objorders)
        {
            Int64 result = 0;
            try
            {
               cls_order_db objcls_order_db = new cls_order_db();

                result = Convert.ToInt64(objcls_order_db.Insert(objorders));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(orders objorders)
        {
            Int64 result = 0;
            try
            {
                cls_order_db objcls_order_db = new cls_order_db();

                result = Convert.ToInt64(objcls_order_db.Update(objorders));
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
                cls_order_db objcls_order_db = new cls_order_db();

                if (objcls_order_db.Delete(cid))
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
    public class orders
    {
        public orders()
        { }

        #region Private Variables
        private Int64 _oid;
        private Int64 _branchid;
        private string _typeid;
        private Boolean _ispaid;
        private Boolean _isapproved;
        private Decimal _totalamount;
        private DateTime _orderdate;
        private Boolean _isdeleted;
        private string _Comments;
        private string _trackid;
        private int _status;
        //oid, branchid, typeid, ispaid, isapproved, totalamount, orderdate, isdeleted
        //    , Comments, trackid, status
        #endregion
        #region Public Properties
        public Int64 oid
        {
            get { return _oid; }
            set { _oid = value; }
        }
        public Int64 branchid
        {
            get { return _branchid; }
            set { _branchid = value; }
        }
        public string typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        public Boolean ispaid
        {
            get { return _ispaid; }
            set { _ispaid = value; }
        }
        public Boolean isapproved
        {
            get { return _isapproved; }
            set { _isapproved = value; }
        }
        public Decimal totalamount
        {
            get { return _totalamount; }
            set { _totalamount = value; }
        }
        public DateTime orderdate
        {
            get { return _orderdate; }
            set { _orderdate = value; }
        }
        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        public string trackid
        {
            get { return _trackid; }
            set { _trackid = value; }
        }
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion
    }

}