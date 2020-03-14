using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_product_b
{
    public cls_product_b()
    {
        //
        // TODO: Add constructor logic here
        //
    }
        #region Public Methods

        public DataTable SelectAll(Int64 subcategoryId)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();
                dt = objcls_product_db.SelectAll(subcategoryId);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
        public DataTable product_SelectBybrandId(Int64 brandid)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();
                dt = objcls_product_db.product_SelectBybrandId(brandid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }


        public productmaster  SelectById(Int64 bankid)
        {
            productmaster objproductmaster = new productmaster();
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();

                objproductmaster = objcls_product_db.SelectById(bankid);
                return objproductmaster;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objproductmaster ;
            }
        }

        public Int64 Insert(productmaster objproductmaster)
        {
            Int64 result = 0;
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();

                result = Convert.ToInt64(objcls_product_db.Insert(objproductmaster));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public Int64 Update(productmaster objproductmaster)
        {
            Int64 result = 0;
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();

                result = Convert.ToInt64(objcls_product_db.Update(objproductmaster ));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }

        public bool Delete(Int64  bankid)
        {
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();

                if (objcls_product_db.Delete(bankid))
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

        public bool IsActive(Int64 bankid, bool isActive)
        {
            try
            {
                cls_product_db objcls_product_db = new cls_product_db();
                if (objcls_product_db.IsActive(bankid, isActive))
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
    public class productmaster
    {
        public productmaster()
        { }

        #region Private Variables
    

        private Int64 _id;
        private Int64 _brandid;
        private Int64 _typeId;
        private Int64 _subcategoryId;
        private Int64 _maincategoryId;

        private string  _productname;
        private string _mainimage;
        private Int64 _stock;
        private decimal _gst;
        private Int64 _moq;
        private string  _shortdescp;
        private string _longdescp;
        private Boolean _isactive;
        private Boolean _isdeleted;
        private decimal _mrp;

        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int64 brandid
        {
            get { return _brandid; }
            set { _brandid = value; }
        }

        public Int64 typeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        public Int64 subcategoryId
        {
            get { return _subcategoryId; }
            set { _subcategoryId = value; }
        }

        public Int64 maincategoryId
        {
            get { return _maincategoryId; }
            set { _maincategoryId = value; }
        }
 

        public String productname
        {
            get { return _productname; }
            set { _productname = value; }
        }

        public String mainimage
        {
            get { return _mainimage; }
            set { _mainimage = value; }
        }
        public Int64 stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public decimal  gst
        {
            get { return _gst; }
            set { _gst = value; }
        }
        public Int64 moq
        {
            get { return _moq; }
            set { _moq = value; }
        }
        public String shortdescp
        {
            get { return _shortdescp; }
            set { _shortdescp = value; }
        }
        public String longdescp
        {
            get { return _longdescp; }
            set { _longdescp = value; }
        }

        public Boolean isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        public decimal mrp
        {
            get { return _mrp; }
            set { _mrp = value; }
        }

        #endregion
    }

}
