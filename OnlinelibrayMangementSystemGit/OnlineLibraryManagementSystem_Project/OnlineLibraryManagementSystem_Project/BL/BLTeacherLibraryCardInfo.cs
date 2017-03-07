using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;


namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLTeacherLibraryCardInfo
    {
        public bool CreateTeacherLibraryCardInfo(BOTeacherLibraryCardInfo _objTeacherLibraryCardInfo)
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
                cmd = new SqlCommand("SP_TeacherLibraryCard", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherName",_objTeacherLibraryCardInfo.TeacherName);
                cmd.Parameters.AddWithValue("@TeacherID", _objTeacherLibraryCardInfo.TeacherID);
                cmd.Parameters.AddWithValue("@BookID",_objTeacherLibraryCardInfo.BookID);
                cmd.Parameters.AddWithValue("@IsueeDate",_objTeacherLibraryCardInfo.IsueeDate);
                cmd.Parameters.AddWithValue("@ReturnDate",_objTeacherLibraryCardInfo.ReturnDate);
                cmd.Parameters.AddWithValue("@IsRetrun",_objTeacherLibraryCardInfo.IsReturn);
                cmd.Parameters.AddWithValue("@IsRenew", _objTeacherLibraryCardInfo.IsRenew);
                cmd.Parameters.AddWithValue("@IssueType", _objTeacherLibraryCardInfo.IssueType);
                cmd.Parameters.AddWithValue("@EntryDate",_objTeacherLibraryCardInfo.EntryDate);
                cmd.Parameters.AddWithValue("@EntryBy",_objTeacherLibraryCardInfo.EntryBy);
                cmd.ExecuteNonQuery();
                IsSave = true;
            }
            catch (Exception)
            {
                throw;
 
            }
            return IsSave;
        }
        public DataTable LoadTeacherLiCard() 
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblbookInfo.BookID, dbo.tblTeacherLibraryCard.BookID AS BookID, dbo.tblbookInfo.BookTitle,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE()) ELSE   DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE()) END AS TotalDay,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE())*50 ELSE DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE())*50 END AS Fine, dbo.tblbookInfo.WriterName, 
                      dbo.tblTeacherLibraryCard.TeacherName, dbo.tblTeacherLibraryCard.TeacherID, dbo.tblTeacherLibraryCard.IsueeDate, dbo.tblTeacherLibraryCard.ReturnDate,dbo.tblTeacherLibraryCard.RenewDate
FROM         dbo.tblTeacherLibraryCard INNER JOIN
                      dbo.tblbookInfo ON dbo.tblTeacherLibraryCard.BookID = dbo.tblbookInfo.BookID WHERE IsRetrun=0 ";
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

        public DataTable LoadTeacherLiCard( string ID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblbookInfo.BookID, dbo.tblTeacherLibraryCard.BookID AS BookID, dbo.tblbookInfo.BookTitle, dbo.tblbookInfo.WriterName, 
                      dbo.tblTeacherLibraryCard.TeacherName, dbo.tblTeacherLibraryCard.TeacherID, dbo.tblTeacherLibraryCard.IsueeDate, dbo.tblTeacherLibraryCard.ReturnDate,dbo.tblTeacherLibraryCard.RenewDate
FROM         dbo.tblTeacherLibraryCard INNER JOIN
                      dbo.tblbookInfo ON dbo.tblTeacherLibraryCard.BookID = dbo.tblbookInfo.BookID WHERE IsRetrun=0 AND TeacherID='" + ID + "'";
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


        public bool DeleteTeacher(string TeacherID,string BookID)
        {
            bool IsSave = false;
            try
            {
                SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE  tblTeacherLibraryCard SET IsRetrun=1 WHERE TeacherID =@TeacherID AND BookID=@BookID";
                cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
                cmd.Parameters.AddWithValue("@BookID",BookID);
                                          
                           
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    IsSave = true;
                }
            }
            catch (Exception)
            { 
                throw;
            }
            return IsSave;
        }
        public bool UpdateTeacher(string TeacherName, string RenewDate, string TeacherID, string BookID)
        {
            bool IsSave = false;
            try
            {
                SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE  tblTeacherLibraryCard  SET TeacherName=@TeacherName ,RenewDate=@RenewDate  WHERE TeacherID =@TeacherID AND BookID=@BookID";
                cmd.Parameters.AddWithValue("@TeacherName", TeacherName);
                cmd.Parameters.AddWithValue("@RenewDate",RenewDate);
                cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
                cmd.Parameters.AddWithValue("@BookID", BookID);


                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    IsSave = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return IsSave;
        }
       

        public DataTable LoadTeacherLiCardbyTeacherID(string TeacherID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblbookInfo.BookID, dbo.tblTeacherLibraryCard.BookID AS BookID, dbo.tblbookInfo.BookTitle,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE()) ELSE   DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE()) END AS TotalDay,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE())*50 ELSE DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE())*50 END AS Fine ,dbo.tblbookInfo.WriterName, 
                      dbo.tblTeacherLibraryCard.TeacherName, dbo.tblTeacherLibraryCard.TeacherID, dbo.tblTeacherLibraryCard.IsueeDate,dbo.tblTeacherLibraryCard.RenewDate, dbo.tblTeacherLibraryCard.ReturnDate
FROM         dbo.tblTeacherLibraryCard INNER JOIN
                      dbo.tblbookInfo ON dbo.tblTeacherLibraryCard.BookID = dbo.tblbookInfo.BookID WHERE TeacherID=@TeacherID AND IsRetrun=0  ";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery, cn);
                cmd.Parameters.AddWithValue("@TeacherID",TeacherID);
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


        
    }
}