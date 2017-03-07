using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;
namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLNewBook
    {
        public int GetBookID (string BookCategory)
        {
            int bookID = 0;
             SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            string SQLQuery = "SELECT (COUNT(*)+1) AS BookID FROM tblbookInfo WHERE BookCategoryID = '" + BookCategory + "'";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery,cn);
                object _objBookID = null;
                _objBookID = cmd.ExecuteScalar();
                if (_objBookID != null)
                {
                    bookID = int.Parse(_objBookID.ToString());
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
            return bookID;
        
 
        }

        public bool CreateNewBook( BONewBook _objNewbook)
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
                cmd = new SqlCommand("SP_CreateNewBook",cn);
                cmd.CommandType = CommandType.StoredProcedure;             
                cmd.Parameters.AddWithValue("@BookID", _objNewbook.BookID);
                cmd.Parameters.AddWithValue("@BookTitle", _objNewbook.BookName);
                cmd.Parameters.AddWithValue("@BookCategoryID",_objNewbook.BookCategoryID);
                cmd.Parameters.AddWithValue("@WriterName",_objNewbook.WriterName);
                cmd.Parameters.AddWithValue("@Edition",_objNewbook.Edition);
                cmd.Parameters.AddWithValue("@PublishedYear",_objNewbook.PublishedYear);
                cmd.Parameters.AddWithValue("@BookLanguageID",_objNewbook.BookLanguageID);
                cmd.Parameters.AddWithValue("@ShelfID",_objNewbook.ShelfID);
                cmd.Parameters.AddWithValue("@CellID",_objNewbook.CellID);
                cmd.Parameters.AddWithValue("@IssueTypeID",_objNewbook.IssueTypeID);
                cmd.Parameters.AddWithValue("@NumberOfBook",_objNewbook.NumberOfBook);
                cmd.Parameters.AddWithValue("@EntryDate",_objNewbook.EntryDate);
                cmd.Parameters.AddWithValue("@EntryBy", _objNewbook.EntryBy); 
                cmd.ExecuteNonQuery();
                IsSave = true;
                
            }
            catch (Exception)
            {
                throw;
            }
            return IsSave;
        }

        public DataTable GetBookInfo(string BookID)
        {
           
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = "SELECT BookTitle,WriterName,NumberOfBook FROM tblbookInfo WHERE BookID = '" + BookID + "'";
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

        
    }
}