using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_subcategory_b
{
    public cls_subcategory_b()
    {
        //
        // TODO: Add constructor logic here
        //
    }

        public DataTable SelectAll(Int64 maincategoryId)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
                dt = objcls_subcategory_db.SelectAll(maincategoryId);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public subCategoryMaster  SelectById(Int64 cid)
        {
            subCategoryMaster  objcategory = new subCategoryMaster ();
            try
            {
                cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
                objcategory = objcls_subcategory_db.SelectById(cid);
                return objcategory;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcategory;
            }
        }

        public Int64 Insert(subCategoryMaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
                result = Convert.ToInt64(objcls_subcategory_db.Insert(objcategory));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(subCategoryMaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
                result = Convert.ToInt64(objcls_subcategory_db.Update(objcategory));
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
                cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
                if (objcls_subcategory_db.Delete(cid))
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
                cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
                if (objcls_subcategory_db.Category_IsActive(CategoryId, IsActive))
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

 


    }
    public class subCategoryMaster
    {
        public subCategoryMaster()
        { }

        #region Private Variables
        private Int64 _id;
        private Int64 _maincategoryid;
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
        public Int64 maincategoryid
        {
            get { return _maincategoryid; }
            set { _maincategoryid = value; }
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
