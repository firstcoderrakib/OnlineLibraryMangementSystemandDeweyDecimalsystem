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
    public partial class frmStudentProfile : System.Web.UI.Page
    {
        BLStudentinfo _objBLStudent = new BLStudentinfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSTudentProfile();
            }
        }
        public void LoadSTudentProfile()
        {
            try
            {
                DataTable dt = _objBLStudent.GetStudentinfo(Session["ID"].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    lblName.Text ="Welcome "+ dr["StudentName"].ToString();
                    lblFullName.Text = dr["StudentName"].ToString();
                    lblStudentID.Text = dr["StudentID"].ToString();
                    lblAddress.Text = dr["Address"].ToString();
                    lblDepartment.Text = dr["DepartmentTitle"].ToString();
                    lblFatherName.Text = dr["FatherName"].ToString();
                    lblMotherName.Text = dr["MotherName"].ToString();
                    lblMobileNo.Text = dr["MobileNo"].ToString();
                    lblEmail.Text = dr["Email"].ToString();

                    imgStudent.ImageUrl = "~/StudentImage/" + dr["StudentPic"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "LoadSTudentProfile():"+ex.Message;
            }
        }
    }
}