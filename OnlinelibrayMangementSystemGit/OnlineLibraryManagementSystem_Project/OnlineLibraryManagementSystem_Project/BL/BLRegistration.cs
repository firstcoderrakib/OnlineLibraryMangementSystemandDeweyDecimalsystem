using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLRegistration
    {
        public bool CreateRegistration(BORegistration _objRegistration)
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
                cmd = new SqlCommand("SP_Registration", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName",_objRegistration.FullName);
                cmd.Parameters.AddWithValue("@Address",_objRegistration.Address);
                cmd.Parameters.AddWithValue("@UserName",_objRegistration.UserName);
                cmd.Parameters.AddWithValue("@Password",_objRegistration.Password);
                cmd.Parameters.AddWithValue("@UniversityID",_objRegistration.UniversityID);
                cmd.Parameters.AddWithValue("@Department",_objRegistration.Department);
                cmd.Parameters.AddWithValue("@FatherName",_objRegistration.FatherName);
                cmd.Parameters.AddWithValue("@MotherName",_objRegistration.MotherName);
                cmd.Parameters.AddWithValue("@MobileNo",_objRegistration.MobileNo);
                cmd.Parameters.AddWithValue("@Email",_objRegistration.Email);
                cmd.Parameters.AddWithValue("@Picture",_objRegistration.Picture);
                cmd.Parameters.AddWithValue("@UserType",_objRegistration.UserType);
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