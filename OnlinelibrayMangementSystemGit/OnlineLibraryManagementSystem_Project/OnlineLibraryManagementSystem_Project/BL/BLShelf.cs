using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLShelf
    {
        public DataTable LoadShelf()
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = "SELECT *FROM tblShelfInfo";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery, cn);
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
        public bool CreateShelf(BOAddShelf _objBOShelf)
        {
            SqlConnection cn=new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd=null;
            bool IsSave=false;
            string SQLQuery="INSERT INTO tblShelfInfo(ShelfTitle)VALUES(@ShelfTitle)";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery, cn);
                cmd.Parameters.AddWithValue("@ShelfTitle", _objBOShelf.ShelfTitle);
                cmd.ExecuteNonQuery();
                IsSave = true;

            }
            catch (Exception)
            {
                throw;
            }
            return IsSave;
        }
    }
}