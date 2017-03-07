using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLAddEdition
    {
        public bool CreateEdition(BOAddEdition _objEdition)
        {
            SqlConnection cn = new SqlConnection(BLGlobalVar.Connection);
            SqlCommand cmd=null;
            bool IsSave=false;
            string SQLQuery = "INSERT INTO tbl_Edition(EditionTitle)VALUES(@EditionTitle)";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();
                cmd = new SqlCommand(SQLQuery,cn);
                cmd.Parameters.AddWithValue("@EditionTitle",_objEdition.EditionTitle);
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