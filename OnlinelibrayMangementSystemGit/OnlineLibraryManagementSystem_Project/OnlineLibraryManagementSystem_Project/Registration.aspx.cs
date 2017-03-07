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
    public partial class Registration : System.Web.UI.Page
    {
        BLRegistration _objBLRegistration = new BLRegistration();
        BORegistration _objBORegistration = new BORegistration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserType();
                GetBookDepartment();

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
        public void GetUserType()
        {
            try
            {
               
                BLUserType _ojbUserType = new BLUserType();
                DataTable dt = _ojbUserType.LoadUserType();
                ddlUserType.Items.Clear();
                ddlUserType.Items.Add(new ListItem("Select an Option","0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["UserType"].ToString();
                    lst.Value = dr["UserID"].ToString();
                    ddlUserType.Items.Add(lst);
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "GetUserType():" + ex.Message;
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                lblMess.Text = string.Empty;
                lblError.Text = string.Empty;
                if(string.IsNullOrEmpty(txtFullName.Text))
                {
                    lblError.Text = "Please Provide Full Name";
                    txtFullName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    lblError.Text = "Please Provide User Name";
                    txtUserName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    lblError.Text = "Please Provide Password";
                    txtPassword.Focus();
                    return;
                }


                if (string.IsNullOrEmpty(txtID.Text))
                {
                    lblError.Text = "Please Provide University ID";
                    txtID.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ddlDepartment.SelectedValue.ToString()))
                {
                    lblError.Text = "Please Provide Department";
                    ddlDepartment.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtFatherName.Text))
                {
                    lblError.Text = "Please Provide Father Name";
                    txtFullName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtMotherName.Text))
                {
                    lblError.Text = "Please Provide Mother Name";
                    txtFatherName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtMobileNo.Text))
                {
                    lblError.Text = "Please Provide Mobile No";
                    txtMobileNo.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    lblError.Text = "Please Provide Email Address";
                    txtEmail.Focus();
                    return;
                }
                if (! txtEmail.Text.Contains("@"))
                {
                    lblError.Text = "Please Provide Valid E-mail Address.";
                    txtEmail.Focus();
                    return;
 
                }

                if (string.IsNullOrEmpty(ddlUserType.SelectedValue.ToString()))
                {
                    lblError.Text = "Please Provide User Type";
                    ddlUserType.Focus();
                    return;
                }
                string PicName = string.Empty;
                if (FileUpload1.HasFile)
                {
                    PicName = FileUpload1.PostedFile.FileName;
                    if (ddlUserType.SelectedValue.ToString() == "1")
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/StudentImage/" + FileUpload1.PostedFile.FileName));
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/TeacherImge/" + FileUpload1.PostedFile.FileName));
                    }
                }
                _objBORegistration.FullName = txtFullName.Text;
                _objBORegistration.UserName = txtUserName.Text.Trim();
                _objBORegistration.Address = txtAddress.Text;
                _objBORegistration.Password = txtPassword.Text.Trim();
                _objBORegistration.UniversityID = txtID.Text;
                _objBORegistration.Department = ddlDepartment.SelectedValue.ToString();
                _objBORegistration.FatherName = txtFatherName.Text;
                _objBORegistration.MotherName = txtMotherName.Text;
                _objBORegistration.MobileNo = txtMobileNo.Text;
                _objBORegistration.Email = txtEmail.Text;
                _objBORegistration.Picture = PicName;
                _objBORegistration.UserType = ddlUserType.SelectedValue.ToString();
                bool IsSave = _objBLRegistration.CreateRegistration(_objBORegistration);
                if (IsSave)
                {
                    Response.Redirect("~/Login.aspx",false);
                }
            }
               
            catch (Exception ex)
            {
                lblError.Text = "btnSignUp_Click():"+ex.Message;
            }
        }

    }
}