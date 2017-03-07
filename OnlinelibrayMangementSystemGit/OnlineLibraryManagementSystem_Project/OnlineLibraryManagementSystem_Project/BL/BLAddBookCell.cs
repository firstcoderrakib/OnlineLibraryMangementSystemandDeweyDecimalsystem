using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLAddBookCell
    {
        public bool CreateAddBookCellTitle(BOAddBookCell _objBookCell)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd = null;
            bool IsSave = false;
            string SQLQuery = "INSERT INTO tblCellInfo(CellID,CellTitle)VALUES(@CellID,@CellTitle)";

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery,cn);
                cmd.Parameters.AddWithValue("@CellID",_objBookCell.Id);
                cmd.Parameters.AddWithValue("@CellTitle",_objBookCell.BookCellTitle);
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