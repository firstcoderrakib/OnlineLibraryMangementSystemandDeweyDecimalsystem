using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;
namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLStudentinfo
    {
        public DataTable GetStudentinfo(string StudentID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblDepartment.DepartmentTitle AS DepartmentTitle, dbo.tblDepartment.DepartmentID, dbo.tblStudentInfo.EntryDate, dbo.tblStudentInfo.EntryBy, dbo.tblStudentInfo.StudentPic, 
                      dbo.tblStudentInfo.Email, dbo.tblStudentInfo.MobileNo, dbo.tblStudentInfo.Address,dbo.tblStudentInfo.FatherName,dbo.tblStudentInfo.MotherName, dbo.tblStudentInfo.StudentName, dbo.tblStudentInfo.StudentID
FROM         dbo.tblDepartment INNER JOIN
                      dbo.tblStudentInfo ON dbo.tblDepartment.DepartmentID = dbo.tblStudentInfo.DepartmentID WHERE StudentID='" + StudentID + "'";
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
        public int GetStudentBookNumber(string StudentID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            int bookNumber = 0;
            string SQLQuery = "SELECT  COUNT (ID)  FROM tblStudentLibraryCard WHERE StudentID='" + StudentID + "'";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery, cn);
                Object _objBookAmount = cmd.ExecuteScalar();
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
        public bool CreateStudentInfo(BOStudentInfo _objStudentInfo)
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
                cmd = new SqlCommand("SP_StudentInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", _objStudentInfo.StudentID);
                cmd.Parameters.AddWithValue("@StudentName", _objStudentInfo.StudentName);
                cmd.Parameters.AddWithValue("@DepartmentID", _objStudentInfo.DepartmentID);
                cmd.Parameters.AddWithValue("@Address", _objStudentInfo.Address);
                cmd.Parameters.AddWithValue("@FatherName",_objStudentInfo.FatherName);
                cmd.Parameters.AddWithValue("@MotherName",_objStudentInfo.MotherName);
                cmd.Parameters.AddWithValue("@MobileNo", _objStudentInfo.MobileNo);
                cmd.Parameters.AddWithValue("@Email", _objStudentInfo.Email);
                cmd.Parameters.AddWithValue("@StudentPic", _objStudentInfo.StudentPic);
                cmd.Parameters.AddWithValue("@EntryBy", _objStudentInfo.EntryBy);
                cmd.Parameters.AddWithValue("@EntryDate", _objStudentInfo.EntryDate);
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