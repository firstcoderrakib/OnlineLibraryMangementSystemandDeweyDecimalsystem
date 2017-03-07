using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLStudentLibraryCard
    {
        public bool CreateStudentInfo(BOStudentLibraryCardInfo _objStudentLibraryCardInfo)
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
                cmd = new SqlCommand("SP_StudentLibraryCard", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", _objStudentLibraryCardInfo.StudentName);
                cmd.Parameters.AddWithValue("@StudentID",_objStudentLibraryCardInfo.StudentID);
                cmd.Parameters.AddWithValue("@BookID",_objStudentLibraryCardInfo.BookID);
                cmd.Parameters.AddWithValue("@IsueeDate",_objStudentLibraryCardInfo.IsueeDate);
                cmd.Parameters.AddWithValue("@ReturnDate",_objStudentLibraryCardInfo.ReturnDate);
                cmd.Parameters.AddWithValue("@IsRetrun", _objStudentLibraryCardInfo.IsRetrun);
                cmd.Parameters.AddWithValue("@IsRenew", _objStudentLibraryCardInfo.IsRenew);
                cmd.Parameters.AddWithValue("@IssueType", _objStudentLibraryCardInfo.IssueType);
                cmd.Parameters.AddWithValue("@EntryDate",_objStudentLibraryCardInfo.EntryDate);
                cmd.Parameters.AddWithValue("@EntryBy",_objStudentLibraryCardInfo.EntryBy);
                cmd.ExecuteNonQuery();
                IsSave = true;
            }
            catch (Exception)
            {
                throw;
            }
            return IsSave;
        }
        public DataTable LoadStudentLiCard()
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT   dbo.tblStudentLibraryCard.StudentName, dbo.tblStudentLibraryCard.StudentID, dbo.tblStudentLibraryCard.IsueeDate, dbo.tblStudentLibraryCard.RenewDate,
                      dbo.tblStudentLibraryCard.ReturnDate, dbo.tblStudentLibraryCard.BookID AS BookID, dbo.tblbookInfo.WriterName, dbo.tblbookInfo.BookTitle,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE()) ELSE   DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE()) END AS TotalDay,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE())*50 ELSE DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE())*50 END AS Fine
                     FROM         dbo.tblbookInfo INNER JOIN
                      dbo.tblStudentLibraryCard ON dbo.tblbookInfo.BookID = dbo.tblStudentLibraryCard.BookID WHERE IsRetrun=0";

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
        public DataTable LoadStudentLiCard(string ID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT   dbo.tblStudentLibraryCard.StudentName, dbo.tblStudentLibraryCard.StudentID, dbo.tblStudentLibraryCard.IsueeDate, 
                      dbo.tblStudentLibraryCard.ReturnDate, dbo.tblStudentLibraryCard.RenewDate, dbo.tblStudentLibraryCard.BookID AS BookID, dbo.tblbookInfo.WriterName, dbo.tblbookInfo.BookTitle
                     FROM         dbo.tblbookInfo INNER JOIN
                      dbo.tblStudentLibraryCard ON dbo.tblbookInfo.BookID = dbo.tblStudentLibraryCard.BookID WHERE IsRetrun=0 AND StudentID='" + ID+"'";

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
        public bool DeleteStudent(string StudentID,string BookID)
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
                cmd.CommandText = "UPDATE  tblStudentLibraryCard SET IsRetrun=1 WHERE StudentID =@StudentID AND BookID=@BookID ";
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
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
        public bool UpdateStudent(string StudentName, string RenewDate, string StudentID, string BookID)
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
                cmd.CommandText = "UPDATE  tblStudentLibraryCard SET StudentName=@StudentName,RenewDate=@RenewDate WHERE StudentID =@StudentID AND BookID=@BookID ";
                cmd.Parameters.AddWithValue("@StudentName", StudentName);
                cmd.Parameters.AddWithValue("@RenewDate", RenewDate);
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
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

        public DataTable LoadStudentLiCardbyStudentID(string StudentID)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT   dbo.tblStudentLibraryCard.StudentName, dbo.tblStudentLibraryCard.StudentID, dbo.tblStudentLibraryCard.IsueeDate, 
                      dbo.tblStudentLibraryCard.ReturnDate, dbo.tblStudentLibraryCard.BookID AS BookID, dbo.tblbookInfo.WriterName, dbo.tblbookInfo.BookTitle,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE()) ELSE   DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE()) END AS TotalDay,CASE WHEN RenewDate IS NULL THEN  DATEDIFF(day,convert(datetime, ReturnDate, 103), GETDATE())*50 ELSE DATEDIFF(day,convert(datetime, RenewDate, 103), GETDATE())*50 END AS Fine,dbo.tblStudentLibraryCard.RenewDate
                     FROM         dbo.tblbookInfo INNER JOIN
                      dbo.tblStudentLibraryCard ON dbo.tblbookInfo.BookID = dbo.tblStudentLibraryCard.BookID WHERE StudentID=@StudentID AND IsRetrun=0 ";

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery, cn);
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
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