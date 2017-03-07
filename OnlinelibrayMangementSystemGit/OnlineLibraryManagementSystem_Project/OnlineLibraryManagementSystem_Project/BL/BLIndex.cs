using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLIndex
    {
        public DataTable GetAllBook()
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblbookLaguage.BookLanguage, dbo.tbl_Edition.EditionTitle, dbo.tbl_BookCategory.CategoryTitle, dbo.tblShelfInfo.ShelfTitle, dbo.tblCellInfo.CellTitle, 
                      dbo.tblbookInfo.BookID, dbo.tblbookInfo.BookTitle, dbo.tblbookInfo.WriterName, dbo.tblbookInfo.PublishedYear, dbo.tblbookInfo.NumberOfBook, 
                      dbo.tbl_Issue.IssueType
FROM         dbo.tbl_BookCategory INNER JOIN
                      dbo.tblbookLaguage INNER JOIN
                      dbo.tblbookInfo ON dbo.tblbookLaguage.ID = dbo.tblbookInfo.BookLanguageID INNER JOIN
                      dbo.tbl_Edition ON dbo.tblbookInfo.Edition = dbo.tbl_Edition.ID ON dbo.tbl_BookCategory.CategoryID = dbo.tblbookInfo.BookCategoryID INNER JOIN
                      dbo.tblShelfInfo ON dbo.tblbookInfo.ShelfID = dbo.tblShelfInfo.ID INNER JOIN
                      dbo.tblCellInfo ON dbo.tblbookInfo.CellID = dbo.tblCellInfo.ID INNER JOIN
                      dbo.tbl_Issue ON dbo.tblbookInfo.IssueTypeID = dbo.tbl_Issue.ID";
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

        public DataTable GetAllBook(string BookName)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tblbookLaguage.BookLanguage, dbo.tbl_Edition.EditionTitle, dbo.tbl_BookCategory.CategoryTitle, dbo.tblShelfInfo.ShelfTitle, dbo.tblCellInfo.CellTitle, 
                      dbo.tblbookInfo.BookID, dbo.tblbookInfo.BookTitle, dbo.tblbookInfo.WriterName, dbo.tblbookInfo.PublishedYear, dbo.tblbookInfo.NumberOfBook, 
                      dbo.tbl_Issue.IssueType
FROM         dbo.tbl_BookCategory INNER JOIN
                      dbo.tblbookLaguage INNER JOIN
                      dbo.tblbookInfo ON dbo.tblbookLaguage.ID = dbo.tblbookInfo.BookLanguageID INNER JOIN
                      dbo.tbl_Edition ON dbo.tblbookInfo.Edition = dbo.tbl_Edition.ID ON dbo.tbl_BookCategory.CategoryID = dbo.tblbookInfo.BookCategoryID INNER JOIN
                      dbo.tblShelfInfo ON dbo.tblbookInfo.ShelfID = dbo.tblShelfInfo.ID INNER JOIN
                      dbo.tblCellInfo ON dbo.tblbookInfo.CellID = dbo.tblCellInfo.ID INNER JOIN
                      dbo.tbl_Issue ON dbo.tblbookInfo.IssueTypeID = dbo.tbl_Issue.ID WHERE dbo.tblbookInfo.BookTitle like '%"+BookName+"%'";
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
        public DataTable GetBookNumber()
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            SqlDataAdapter ad = null;
            DataTable dt = new DataTable();
            string SQLQuery = @"SELECT     dbo.tbl_BookCategory.CategoryTitle,ISNULL(SUM(dbo.tblbookInfo.NumberOfBook),0) AS TotalBook
FROM         dbo.tbl_BookCategory  LEFT OUTER JOIN
                      dbo.tblbookInfo ON dbo.tbl_BookCategory.CategoryID = dbo.tblbookInfo.BookCategoryID GROUP BY dbo.tbl_BookCategory.CategoryTitle";
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