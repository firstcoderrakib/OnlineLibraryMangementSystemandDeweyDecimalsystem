using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BO;
using OnlineLibraryManagementSystem_Project.BL;

namespace OnlineLibraryManagementSystem_Project
{
    public partial class FrmTeacherInfo : System.Web.UI.Page
    {
        BLTeacherInfo _objBLTeacherInfo = new BLTeacherInfo();
        BOTeacherInfo _objBOTeacherInfo = new BOTeacherInfo();


        BODepartment _objBODepartment = new BODepartment();
        BLDepartment _objBLDepartment = new BLDepartment();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartment();
 
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
                    FileUpload1.SaveAs(Server.MapPath("~/TeacherImge/" + FileUpload1.PostedFile.FileName));
                }
                _objBOTeacherInfo.TeacherID = txtTeacherID.Text;
                _objBOTeacherInfo.TeacherName = txtTeacherName.Text;
                _objBOTeacherInfo.DepartmentID = ddlDepartment.SelectedValue.ToString().Trim();
                _objBOTeacherInfo.Address = txtAddress.Text;
                _objBOTeacherInfo.FatherName = txtFatherName.Text;
                _objBOTeacherInfo.MotherName = txtMotherName.Text;
                _objBOTeacherInfo.MobileNo = txtMobileNo.Text;
                _objBOTeacherInfo.Email = txtEmail.Text;
                _objBOTeacherInfo.TeacherPic = PicName;
                _objBOTeacherInfo.EntryBy="System";
                _objBOTeacherInfo.EntryDate = txtEntryDate.Text;
                bool IsSave = _objBLTeacherInfo.CreateTeacherInfo(_objBOTeacherInfo);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    txtTeacherName.Text = "";
                    txtTeacherID.Text = "";
                    txtAddress.Text = "";
                    txtFatherName.Text = "";
                    txtMotherName.Text = "";
                    txtMobileNo.Text = "";
                    txtEmail.Text = "";
                    txtEntryDate.Text = "";
                }
                //string PicName = string.Empty;
                //if (FileUpload1.PostedFile != null)
                //{
                //    PicName = FileUpload1.PostedFile.FileName;
                //    FileUpload1.SaveAs(Server.MapPath("~/TeacherImge/" + FileUpload1.PostedFile.FileName));
                //}
                //SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=OnlineLibraryMagamement;Integrated Security=True");
                //if (cn.State == ConnectionState.Open)
                //{
                //    cn.Close();

                //}
                //cn.Open();
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = cn;
                //cmd.CommandText = "INSERT INTO tblTeacherInfo(TeacherID,TeacherName,DepartmentID,Address,MobileNo,TeacherPic,Email,EntryBy,EntryDate)VALUES(@TeacherID,@TeacherName,@DepartmentID,@Address,@MobileNo,@TeacherPic,@Email,@EntryBy,@EntryDate)";
                //cmd.Parameters.AddWithValue("@TeacherID",txtTeacherID.Text);
                //cmd.Parameters.AddWithValue("@TeacherName",txtTeacherName.Text);
                //cmd.Parameters.AddWithValue("@DepartmentID", ddlDepartment.SelectedValue.ToString().Trim());
                //cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                //cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text);
                //cmd.Parameters.AddWithValue("@TeacherPic", PicName);
                //cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                //cmd.Parameters.AddWithValue("@EntryBy", txtEntryBy.Text);
                //cmd.Parameters.AddWithValue("@EntryDate", txtEntryDate.Text);
                //int i = cmd.ExecuteNonQuery();
                //if (i > 0)
                //{
                //    lblMess.Text = "Data Has been Successfully Saved";
                //    txtTeacherName.Text = "";
                //    txtTeacherID.Text = "";
                //    txtMobileNo.Text = "";
                //    txtEntryDate.Text = "";
                //    txtEntryBy.Text = "";
                //    txtEmail.Text = "";
                //    txtAddress.Text = "";
                //}
             
            }
            catch (Exception ex)
            {
                lblError.Text = "btnsave_Click():" + ex.Message;
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