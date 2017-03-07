using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BL;
using OnlineLibraryManagementSystem_Project.BO;
namespace OnlineLibraryManagementSystem_Project
{
    public partial class FrmStudentInfo : System.Web.UI.Page
    {
        BLStudentinfo _objBLStudentInfo = new BLStudentinfo();
        BOStudentInfo _objBOStudentInfo = new BOStudentInfo();

        BODepartment _objBODepartment = new BODepartment();
        BLDepartment _objBLDepartment = new BLDepartment();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartment();
            }
        }
        public void GetBookDepartment()
        {
            try
            {
                BLDepartment _objDepartment = new BLDepartment();
                DataTable dt = _objDepartment.LoadDepartment();
                ddlDepartment.Items.Clear();
                ddlDepartment.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["DepartmentTitle"].ToString();
                    lst.Value = dr["DepartmentID"].ToString();
                    ddlDepartment.Items.Add(lst);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "GetBookDepartment():" + ex.Message;
            }
        }

        public void LoadDepartment()
        {
            try
            {
                BLDepartment _objDepartment = new BLDepartment();
                DataTable dt = _objDepartment.LoadDepartment();
                //ddlIssueType.DataSource = dt;
                //ddlIssueType.DataTextField = "IssueType";
                //ddlIssueType.DataValueField = "ID";
                //ddlIssueType.DataBind();
                ddlDepartment.Items.Clear();
                ddlDepartment.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["DepartmentTitle"].ToString();
                    lst.Value = dr["DepartmentID"].ToString();
                    ddlDepartment.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "LoadDepartment():" + ex.Message;
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string PicName = string.Empty;
                if (FileUpload1.PostedFile != null)
                {
                    PicName = FileUpload1.PostedFile.FileName;
                    FileUpload1.SaveAs(Server.MapPath("~/StudentImage/" + FileUpload1.PostedFile.FileName));
                }
                _objBOStudentInfo.StudentID = txtStudentID.Text;
                _objBOStudentInfo.StudentName = txtStudentName.Text;
                _objBOStudentInfo.DepartmentID = ddlDepartment.SelectedValue.ToString();
                _objBOStudentInfo.Address = txtAddress.Text;
                _objBOStudentInfo.FatherName = txtFatherName.Text;
                _objBOStudentInfo.MotherName = txtMotherName.Text;
                _objBOStudentInfo.MobileNo = txtMobileNo.Text;
                _objBOStudentInfo.Email = txtEmail.Text;
                _objBOStudentInfo.StudentPic = PicName;
                _objBOStudentInfo.EntryBy = "System";
                _objBOStudentInfo.EntryDate = txtEntryDate.Text;
                bool IsSave = _objBLStudentInfo.CreateStudentInfo(_objBOStudentInfo);
                if (IsSave)
                {
                    lblError.Text = "Data has been Successfully Saved";
                    txtStudentName.Text = "";
                    txtStudentID.Text = "";
                    txtMobileNo.Text = "";
                    txtEntryDate.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                }
             
            }
            catch (Exception ex)
            {
                lblError.Text = "btnsave_Click():" + ex.Message;
            }
        }

        protected void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                _objBODepartment.DepartmentTitle = txtDepartmentTitle.Text;
                bool IsSave = _objBLDepartment.CreateDepartmentInfo(_objBODepartment);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    GetBookDepartment();
                    txtDepartmentTitle.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}