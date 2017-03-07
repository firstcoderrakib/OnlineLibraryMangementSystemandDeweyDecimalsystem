using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BL;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLBookCategory
    {
        public DataTable LoadBookCategory()
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = "SELECT CategoryID,CategoryTitle FROM tbl_BookCategory";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery,cn);
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ad.Dispose();
                cmd.Dispose();
                cn.Close();
            }
            return dt; 
        }

        //public bool CreateCategoryTitle(BOAddCategoryTitle _objBOCategory)
        //{
        //    SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
        //    SqlCommand cmd = null;
        //    bool IsSave = false;
        //    string SQLQuery = "INSERT INTO  tbl_BookCategory(CategoryID,CategoryTitle)VALUES(@CategoryID,@CategoryTitle)";
        //    try
        //    {
        //        if (cn.State == ConnectionState.Open)
        //        {
        //            cn.Close();
        //        }
        //        cn.Open();
        //        cmd = new SqlCommand(SQLQuery, cn);
        //        cmd.Parameters.AddWithValue("@CategoryID", _objBOCategory.CategoryID);
        //        cmd.Parameters.AddWithValue("@CategoryID", _objBOCategory.CategoryTitle);
        //        cmd.ExecuteNonQuery();
        //        IsSave = true;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return IsSave;
 
        //}

        public bool CreateBookCategory(BOAddCategoryTitle _objBOBookCategory)
        {
            bool IsSave=false;
            SqlConnection cn=new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd=null;
            try
            {
                if(cn.State==ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd=new SqlCommand("SP_Category",cn);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CategoryID",_objBOBookCategory.CategoryID);
                cmd.Parameters.AddWithValue("CategoryTitle",_objBOBookCategory.CategoryTitle);
                cmd.ExecuteNonQuery();
                IsSave=true;
            }
            catch (Exception)
            {
                throw;
            }
            return IsSave;
        }
    }
    
}