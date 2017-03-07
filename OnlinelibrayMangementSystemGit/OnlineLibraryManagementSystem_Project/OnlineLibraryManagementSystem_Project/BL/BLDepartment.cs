using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLDepartment
    {
        public DataTable LoadDepartment()
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = "SELECT *FROM tblDepartment";
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
        public bool CreateDepartment(BODepartment _objBODepartment)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            bool IsSave = false;
            string SQLQuery = "INSERT INTO tblDepartment(DepartmentTitle)VALUES(@DepartmentTitle)";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery,cn);
                cmd.Parameters.AddWithValue("@DepartmentTitle",_objBODepartment.DepartmentTitle);
                cmd.ExecuteNonQuery();
                IsSave = true;
            }
            catch (Exception)
            {
                throw;
            }
            return IsSave;
        }
        public bool CreateDepartmentInfo(BODepartment _objBODepartment)
        {
            bool IsSave = false;
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand("SP_DepartmentInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentTitle", _objBODepartment.DepartmentTitle);
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