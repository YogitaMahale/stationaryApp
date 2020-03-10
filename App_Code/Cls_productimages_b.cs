using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_productimage_b
    {
        public Cls_productimage_b()
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
        //        Cls_productimage_db objCls_productimage_db = new Cls_productimage_db();
        //        dt = objCls_productimage_db.SelectAll();
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
                Cls_productimage_db objCls_productimage_db = new Cls_productimage_db();
                dt = objCls_productimage_db.SelectAllByProductId(pid);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        //public productimages SelectById(Int64 cid)
        //{
        //    productimages objproductimages = new productimages();
        //    try
        //    {
        //        Cls_productimage_db objCls_productimage_db = new Cls_productimage_db();

        //        objproductimages = objCls_productimage_db.SelectById(cid);
        //        return objproductimages;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrHandler.writeError(ex.Message, ex.StackTrace);
        //        return objproductimages;
        //    }
        //}
        public Int64 Insert(productimage objcompany)
        {
            Int64 result = 0;
            try
            {
                Cls_productimage_db objCls_productimage_db = new Cls_productimage_db();

                result = Convert.ToInt64(objCls_productimage_db.Insert(objcompany));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        //public Int64 Update(productimages objcompany)
        //{
        //    Int64 result = 0;
        //    try
        //    {
        //        Cls_productimage_db objCls_productimage_db = new Cls_productimage_db();

        //        result = Convert.ToInt64(objCls_productimage_db.Update(objcompany));
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
                Cls_productimage_db objCls_productimage_db = new Cls_productimage_db();

                if (objCls_productimage_db.Delete(cid))
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
    public class productimage
    {
        public productimage()
        { }

        #region Private Variables
        private Int64 _id;
        private Int64 _pid;
        private string _productname;
        private string _imagename;
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

        public string Imagename
        {
            get
            {
                return _imagename;
            }

            set
            {
                _imagename = value;
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