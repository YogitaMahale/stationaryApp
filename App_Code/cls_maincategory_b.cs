using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_maincategory_b
{
    public cls_maincategory_b()
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
                cls_maincategory_db objcls_maincategory_db = new cls_maincategory_db();
                dt = objcls_maincategory_db.SelectAll();
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }
      
        public mainCategoryMaster  SelectById(Int64 cid)
        {
            mainCategoryMaster  objcategory = new mainCategoryMaster ();
            try
            {
                cls_maincategory_db objcls_maincategory_db = new cls_maincategory_db();
                objcategory = objcls_maincategory_db.SelectById(cid);
                return objcategory;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcategory;
            }
        }
       
        public Int64 Insert(mainCategoryMaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_maincategory_db objcls_maincategory_db = new cls_maincategory_db();
                result = Convert.ToInt64(objcls_maincategory_db.Insert(objcategory));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(mainCategoryMaster objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_maincategory_db objcls_maincategory_db = new cls_maincategory_db();
                result = Convert.ToInt64(objcls_maincategory_db.Update(objcategory));
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
                cls_maincategory_db objcls_maincategory_db = new cls_maincategory_db();
                if (objcls_maincategory_db.Delete(cid))
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
        public bool Category_IsActive(Int64 CategoryId, Boolean IsActive)
        {
            try
            {
                cls_maincategory_db objcls_maincategory_db = new cls_maincategory_db();
                if (objcls_maincategory_db.Category_IsActive(CategoryId, IsActive))
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
    public class mainCategoryMaster
    {
        public mainCategoryMaster()
        { }

        #region Private Variables
        private Int64 _id;
        private String _categoryname;
        private String _imagename;
       
        private String _shortdesc;
        private String _longdescp;
        private Boolean _isdeleted;
        private Boolean _isactive;

        
        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
       
        public String categoryname
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }
        public String imagename
        {
            get { return _imagename; }
            set { _imagename = value; }
        }
        
        public String shortdesc
        {
            get { return _shortdesc; }
            set { _shortdesc = value; }
        }
        public String longdescp
        {
            get { return _longdescp; }
            set { _longdescp = value; }
        }
        public Boolean isdeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        public Boolean isactive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
        #endregion
    }

}
