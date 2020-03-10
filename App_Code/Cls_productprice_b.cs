using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_productprice_b
    {
        public Cls_productprice_b()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Public Methods
        //public DataTable SelectAll()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        Cls_productprice_db objCls_productprice_db = new Cls_productprice_db();
        //        dt = objCls_productprice_db.SelectAll();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return dt;
        //    }
        //}

        public DataTable SelectAllByProductId(Int64 pid)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_productprice_db objCls_productprice_db = new Cls_productprice_db();
                dt = objCls_productprice_db.SelectAllByProductId(pid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        //public productprices SelectById(Int64 cid)
        //{
        //    productprices objproductprices = new productprices();
        //    try
        //    {
        //        Cls_productprice_db objCls_productprice_db = new Cls_productprice_db();

        //        objproductprices = objCls_productprice_db.SelectById(cid);
        //        return objproductprices;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return objproductprices;
        //    }
        //}
        public Int64 Insert(productprice objcompany)
        {
            Int64 result = 0;
            try
            {
                Cls_productprice_db objCls_productprice_db = new Cls_productprice_db();

                result = Convert.ToInt64(objCls_productprice_db.Insert(objcompany));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        //public Int64 Update(productprices objcompany)
        //{
        //    Int64 result = 0;
        //    try
        //    {
        //        Cls_productprice_db objCls_productprice_db = new Cls_productprice_db();

        //        result = Convert.ToInt64(objCls_productprice_db.Update(objcompany));
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return result;
        //    }
        //}
        public bool Delete(Int64 cid)
        {
            try
            {
                Cls_productprice_db objCls_productprice_db = new Cls_productprice_db();

                if (objCls_productprice_db.Delete(cid))
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
    public class productprice
    {
        public productprice()
        { }

        #region Private Variables
        private Int64 _id;
        private Int64 _pid;
        private Int64 _bankid;
        private decimal _price;
        private string _productname;
        private string _bankname;
        private bool _isdeleted;


        #endregion


        #region Public Properties


        public long Id
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

        public long Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }

        public string Productname
        {
            get
            {
                return _productname;
            }

            set
            {
                _productname = value;
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

        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }


        #endregion
    }

}