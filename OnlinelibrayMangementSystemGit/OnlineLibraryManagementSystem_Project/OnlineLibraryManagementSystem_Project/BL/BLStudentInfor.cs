using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;
namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLStudentInfor
    {
        public bool CreateStudentInfo(BOStudentInfo _objStudentInfo)
        {
            bool IsSave=false;
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
                cmd.Parameters.AddWithValue("@StudentID",_objStudentInfo.StudentID);
                cmd.Parameters.AddWithValue("@StudentName",_objStudentInfo.StudentName);
                cmd.Parameters.AddWithValue("@DepartmentID",_objStudentInfo.DepartmentID);
                cmd.Parameters.AddWithValue("@Address",_objStudentInfo.Address);
                cmd.Parameters.AddWithValue("@MobileNo",_objStudentInfo.MobileNo);
                cmd.Parameters.AddWithValue("@Email",_objStudentInfo.Email);
                cmd.Parameters.AddWithValue("@StudentPic",_objStudentInfo.StudentPic);
                cmd.Parameters.AddWithValue("@EntryBy",_objStudentInfo.EntryBy);
                cmd.Parameters.AddWithValue("@EntryDate",_objStudentInfo.EntryDate);
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