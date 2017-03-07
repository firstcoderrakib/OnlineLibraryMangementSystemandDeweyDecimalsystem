using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OnlineLibraryManagementSystem_Project.BL;
namespace OnlineLibraryManagementSystem_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               BLLogin _objBLLogin=new BLLogin ();
               DataTable dt = _objBLLogin.GetLogin(txtUserName.Text.Trim(),txtPassword.Text.Trim());
               if (dt.Rows.Count > 0)
               {
                   foreach (DataRow dr in dt.Rows)
                   {
                       if (txtUserName.Text == dr["UserName"].ToString() && txtPassword.Text == dr["Password"].ToString())
                       {
                           Session["UserName"] = dr["UserName"].ToString();
                           Session["ID"] = dr["StudentID"].ToString();
                           DataTable dtPermission = _objBLLogin.GetPagePermition(dr["UserType"].ToString());
                           Session["dtPermission"] = dtPermission;
                           Response.Redirect("~/Home.aspx");
                       }
                       else
                       {
                           lblError.Text = "UserName or Password Incorrect!!";
                           
                           
                       }
                   }
               }
               else
               {
                   lblError.Text = "UserName or Password Incorrect!!";
               }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}