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
    public partial class frmTeacherProfile : System.Web.UI.Page
    {
        BLTeacherInfo _objBLTeacher = new BLTeacherInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTecherProfile();
            }
        }
        public void LoadTecherProfile()
        {
            try
            {
                DataTable dt = _objBLTeacher.GetTeacherInfo(Session["ID"].ToString());
                foreach (DataRow dr in dt.Rows)
                {
                    lblName.Text ="Welcome" + dr["TeacherName"].ToString();
                    lblFullName.Text = dr["TeacherName"].ToString();
                    lblTeacherID.Text = dr["TeacherID"].ToString();
                    lblAddress.Text = dr["Address"].ToString();
                    lblDepartment.Text = dr["DepartmentTitle"].ToString();
                    lblFatherName.Text = dr["FatherName"].ToString();
                    lblMotherName.Text = dr["MotherName"].ToString();
                    lblMobileNo.Text = dr["MobileNo"].ToString();
                    lblEmail.Text = dr["Email"].ToString();
                    imgTeacher.ImageUrl = "~/TeacherImge/" + dr["TeacherPic"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "LoadTecherProfile():" + ex.Message;
            }
        }
    }
}