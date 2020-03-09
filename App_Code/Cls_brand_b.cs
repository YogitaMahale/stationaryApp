using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class Cls_brand_b
    {
        public Cls_brand_b()
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
                Cls_brand_db objCls_brand_db = new Cls_brand_db();
                dt = objCls_brand_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public DataTable SelectAllByTypeId(Int64 id)
        {
            DataTable dt = new DataTable();
            try
            {
                Cls_brand_db objCls_brand_db = new Cls_brand_db();
                dt = objCls_brand_db.SelectAllByTypeId(id);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }



        public brand SelectById(Int64 cid)
        {
            brand objbrand = new brand();
            try
            {
                Cls_brand_db objCls_brand_db = new Cls_brand_db();

                objbrand = objCls_brand_db.SelectById(cid);
                return objbrand;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objbrand;
            }
        }
        public Int64 Insert(brand objcompany)
        {
            Int64 result = 0;
            try
            {
                Cls_brand_db objCls_brand_db = new Cls_brand_db();

                result = Convert.ToInt64(objCls_brand_db.Insert(objcompany));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(brand objcompany)
        {
            Int64 result = 0;
            try
            {
                Cls_brand_db objCls_brand_db = new Cls_brand_db();

                result = Convert.ToInt64(objCls_brand_db.Update(objcompany));
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
                Cls_brand_db objCls_brand_db = new Cls_brand_db();

                if (objCls_brand_db.Delete(cid))
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
    public class brand
    {
        public brand()
        { }

        #region Private Variables
        private Int64 _id;
        private Int64 _typeid;
        private Int64 _subcategoryid;
        private Int64 _maincategoryid;
        private String _brandname;
        private String _typename;
        private String _subcategoryname;
        private String _maincategoryname;

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

        public long Typeid
        {
            get
            {
                return _typeid;
            }

            set
            {
                _typeid = value;
            }
        }

        public string Brandname
        {
            get
            {
                return _brandname;
            }

            set
            {
                _brandname = value;
            }
        }

        public string Typename
        {
            get
            {
                return _typename;
            }

            set
            {
                _typename = value;
            }
        }

        public long Subcategoryid
        {
            get
            {
                return _subcategoryid;
            }

            set
            {
                _subcategoryid = value;
            }
        }

        public long Maincategoryid
        {
            get
            {
                return _maincategoryid;
            }

            set
            {
                _maincategoryid = value;
            }
        }

        public string Subcategoryname
        {
            get
            {
                return _subcategoryname;
            }

            set
            {
                _subcategoryname = value;
            }
        }

        public string Maincategoryname
        {
            get
            {
                return _maincategoryname;
            }

            set
            {
                _maincategoryname = value;
            }
        }
        #endregion
    }

}