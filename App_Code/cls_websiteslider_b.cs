using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_websiteslider_b
    {
        public cls_websiteslider_b()
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
                cls_websiteslider_db objcls_websiteslider_db = new cls_websiteslider_db();
                dt = objcls_websiteslider_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public websiteslider SelectById(Int64 cid)
        {
            websiteslider  objcategory = new websiteslider();
            try
            {
                cls_websiteslider_db objcls_websiteslider_db = new cls_websiteslider_db();
                objcategory = objcls_websiteslider_db.SelectById(cid);
                return objcategory;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcategory;
            }
        }
       

        public Int64 Insert(websiteslider  objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_websiteslider_db objcls_websiteslider_db = new cls_websiteslider_db();
                result = Convert.ToInt64(objcls_websiteslider_db.Insert(objcategory));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(websiteslider objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_websiteslider_db objcls_websiteslider_db = new cls_websiteslider_db();
                result = Convert.ToInt64(objcls_websiteslider_db.Update(objcategory));
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
            bool result = false;
            try
            {
                cls_websiteslider_db objcls_websiteslider_db = new cls_websiteslider_db();
                if (objcls_websiteslider_db.Delete(cid))
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


    }
    public class websiteslider
    {
        public websiteslider()
        { }

        #region Private Variables
        private Int64 _id;
       
        private String _imagename;

        private Boolean _isdeleted;

        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
         

        public String imagename
        {
            get { return _imagename; }
            set { _imagename = value; }
        }

        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }

        #endregion
    }

}
