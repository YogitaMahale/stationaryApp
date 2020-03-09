using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseLayer;

namespace BusinessLayer
{
    public class cls_typemaster_b
{
    public cls_typemaster_b()
    {
        //
        // TODO: Add constructor logic here
        //
    }
        public DataTable SelectAll(Int64 subcategoryId)
        {
            DataTable dt = new DataTable();
            try
            {
                cls_typemaster_db objcls_typemaster_db = new cls_typemaster_db();
                dt = objcls_typemaster_db.SelectAll(subcategoryId);
                return dt;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        public typemaster  SelectById(Int64 cid)
        {
            typemaster objcategory = new typemaster();
            try
            {
                cls_typemaster_db objcls_typemaster_db = new cls_typemaster_db();
                objcategory = objcls_typemaster_db.SelectById(cid);
                return objcategory;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return objcategory;
            }
        }

        public Int64 Insert(typemaster objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_typemaster_db objcls_typemaster_db = new cls_typemaster_db();
                result = Convert.ToInt64(objcls_typemaster_db.Insert(objcategory));
                return result;
            }
            catch (Exception ex)
            {
                ErrHandler.writeError(ex.Message, ex.StackTrace);
                return result;
            }
        }
        public Int64 Update(typemaster  objcategory)
        {
            Int64 result = 0;
            try
            {
                cls_typemaster_db objcls_typemaster_db = new cls_typemaster_db();
                result = Convert.ToInt64(objcls_typemaster_db.Update(objcategory));
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
                cls_typemaster_db objcls_typemaster_db = new cls_typemaster_db();
                if (objcls_typemaster_db.Delete(cid))
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
        //public bool Category_IsActive(Int64 CategoryId, Boolean IsActive)
        //{
        //    try
        //    {
        //        cls_subcategory_db objcls_subcategory_db = new cls_subcategory_db();
        //        if (objcls_subcategory_db.Category_IsActive(CategoryId, IsActive))
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




    }
    public class typemaster
    {
        public typemaster()
        { }

        #region Private Variables
        private Int64 _id;
        private Int64 _categoryid;
        private String _typename;
        
         
        private Boolean _isdeleted;
        private Boolean _isactive;
        private Int64 _maincategoryId;

        #endregion


        #region Public Properties
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Int64 categoryid
        {
            get { return _categoryid; }
            set { _categoryid = value; }
        }
        public String typename
        {
            get { return _typename; }
            set { _typename = value; }
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

        public  Int64 maincategoryId
        {
            get { return _maincategoryId; }
            set { _maincategoryId = value; }
        }

        #endregion
    }

}
