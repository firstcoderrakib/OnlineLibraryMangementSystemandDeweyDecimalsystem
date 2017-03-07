using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;
namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLTeacherInfo
    {
        public DataTable GetTeacherInfo(string TeacherID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblDepartment.DepartmentTitle, dbo.tblTeacherInfo.TeacherID, dbo.tblTeacherInfo.TeacherName, dbo.tblTeacherInfo.Address, dbo.tblTeacherInfo.MobileNo, 
                      dbo.tblTeacherInfo.Email, dbo.tblTeacherInfo.TeacherPic, dbo.tblTeacherInfo.EntryBy, dbo.tblTeacherInfo.EntryDate, dbo.tblDepartment.DepartmentID, 
                      dbo.tblTeacherInfo.FatherName, dbo.tblTeacherInfo.MotherName
FROM         dbo.tblDepartment INNER JOIN
                      dbo.tblTeacherInfo ON dbo.tblDepartment.DepartmentID = dbo.tblTeacherInfo.DepartmentID WHERE TeacherID='" + TeacherID + "'";
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
        public int GetTeacherBookNumber(string TeacherID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            int bookNumber = 0;
            string SQLQuery = "SELECT COUNT(ID) FROM tblTeacherLibraryCard WHERE TeacherID='" + TeacherID + "'";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery, cn);
                object _objBookAmount = cmd.ExecuteScalar();
                if (_objBookAmount != null)
                {
                    bookNumber =int.Parse( _objBookAmount.ToString());
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
                cmd.Dispose();
                cn.Close();
            }
            return bookNumber;


        }
        public bool CreateTeacherInfo(BOTeacherInfo _objTeacherInfo)
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
                cmd = new SqlCommand("SP_TeacherInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherID", _objTeacherInfo.TeacherID);
                cmd.Parameters.AddWithValue("@TeacherName", _objTeacherInfo.TeacherName);
                cmd.Parameters.AddWithValue("@DepartmentID", _objTeacherInfo.DepartmentID);
                cmd.Parameters.AddWithValue("@Address", _objTeacherInfo.Address);
                cmd.Parameters.AddWithValue("@FatherName",_objTeacherInfo.FatherName);
                cmd.Parameters.AddWithValue("@MotherName",_objTeacherInfo.MotherName);
                cmd.Parameters.AddWithValue("@MobileNo", _objTeacherInfo.MobileNo);
                cmd.Parameters.AddWithValue("@Email", _objTeacherInfo.Email);
                cmd.Parameters.AddWithValue("@TeacherPic", _objTeacherInfo.TeacherPic);
                cmd.Parameters.AddWithValue("@EntryBy", _objTeacherInfo.EntryBy);
                cmd.Parameters.AddWithValue("@EntryDate", _objTeacherInfo.EntryDate);
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
