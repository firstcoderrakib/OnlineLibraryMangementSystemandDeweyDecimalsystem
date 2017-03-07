using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using OnlineLibraryManagementSystem_Project.BL;
using OnlineLibraryManagementSystem_Project.BO;
using System.Net;
namespace OnlineLibraryManagementSystem_Project
{
    public partial class FrmTeacherLibraryCard : System.Web.UI.Page
    {
        BOTeacherLibraryCardInfo _objBOTeacherLibraryCardInfo = new BOTeacherLibraryCardInfo();
        BLTeacherLibraryCardInfo _objBLTeacherLibraryCardInfo = new BLTeacherLibraryCardInfo();
        BLTeacherInfo _objTeacher = new BLTeacherInfo();
        BOTeacherInfo _objBOTeacher = new BOTeacherInfo();

        BODepartment _objBODepartment = new BODepartment();
        BLDepartment _objBLDepartment = new BLDepartment();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetIssueType();

                LoadDepartment();
            }
        }

        public void GetIssueType()
        {
            try
            {
                BLIssueType _objIssueType = new BLIssueType();
                DataTable dt = _objIssueType.LoadIssueType();
                //ddlIssueType.DataSource = dt;
                //ddlIssueType.DataTextField = "IssueType";
                //ddlIssueType.DataValueField = "ID";
                //ddlIssueType.DataBind();
                ddlIssueType.Items.Clear();
                ddlIssueType.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["IssueType"].ToString();
                    lst.Value = dr["ID"].ToString();
                    ddlIssueType.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "GetIssueType():" + ex.Message;
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


        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                _objBOTeacherLibraryCardInfo.TeacherID = txtTeacherID.Text;
                _objBOTeacherLibraryCardInfo.TeacherName = txtTeacherName.Text;
                _objBOTeacherLibraryCardInfo.BookID = txtBookID.Text;
                _objBOTeacherLibraryCardInfo.IsueeDate = txtIssueDate.Text;
                _objBOTeacherLibraryCardInfo.ReturnDate = txtReturnDate.Text;
                _objBOTeacherLibraryCardInfo.EntryBy = "System";
                _objBOTeacherLibraryCardInfo.EntryDate = "System";
                _objBOTeacherLibraryCardInfo.IssueType = int.Parse(ddlIssueType.SelectedValue.ToString());
                _objBOTeacherLibraryCardInfo.IsReturn = 0;
                _objBOTeacherLibraryCardInfo.IsRenew = 0;
                bool IsSave = _objBLTeacherLibraryCardInfo.CreateTeacherLibraryCardInfo(_objBOTeacherLibraryCardInfo);
                if (IsSave)
                {
                    SendMail();
                    lblError.Text = "Data has been Successfully Saved";
                    txtTeacherName.Text = "";
                    txtTeacherID.Text = "";
                    txtBookID.Text = "";
                    txtBookName.Text = "";
                    txtAuthorName.Text = "";
                    lblStock.Text = "";
                    txtReturnDate.Text = "";
                    txtIssueDate.Text = "";
                    

                    
                }
               
            }
            catch (Exception ex)
            {
                lblError.Text = "btnsave_Click():"+ex.Message;
            }
        }
        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = BLGlobalVar.FromEmailAddress;
            string fromPassword = BLGlobalVar.FromEmailPassword;
            // any address where the email will be sending
            var toAddress = hdEmail.Value.ToString();
            //Password of your gmail address

            // Passing the values and make a email formate to display
            string subject = BLGlobalVar.EmailSubject;
            string body = "Dear Teacher " + txtTeacherName.Text+ ",\n You has been issued  " + txtBookName.Text + " from DIU Library at " + System.DateTime.Now + "\n BR \n Librain \n DIU";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = BLGlobalVar.SMTPServer;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 300000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string ImgeUrl = "TeacherImge/{0}";
                DataTable dtTeacher = _objTeacher.GetTeacherInfo(txtTeacherID.Text);
                foreach (DataRow dr in dtTeacher.Rows)
                {
                    
                    lblNme.Text = dr["TeacherName"].ToString();
                    txtTeacherName.Text = dr["TeacherName"].ToString();
                    hdEmail.Value=dr["Email"].ToString();
                    ddlDepartment.SelectedValue = dr["DepartmentID"].ToString();
                    lblID.Text = dr["TeacherID"].ToString();
                    lblDepart.Text = dr["DepartmentTitle"].ToString();
                    ImgeUrl = string.Format(ImgeUrl, dr["TeacherPic"].ToString());
                    imgPic.ImageUrl = ImgeUrl;
                }
                lblIssuebook.Text = _objTeacher.GetTeacherBookNumber(txtTeacherID.Text).ToString();
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;

            }
        }

        public void LoadDepartment()
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
                lblError.Text = "LoadDepartment():" + ex.Message;
            }
        }



        //public void LoadDepartment()
        //{
        //    try
        //    {
        //        BLDepartment _objDepartment = new BLDepartment();
        //        DataTable dt = _objDepartment.LoadDepartment();
        //        //ddlIssueType.DataSource = dt;
        //        //ddlIssueType.DataTextField = "IssueType";
        //        //ddlIssueType.DataValueField = "ID";
        //        //ddlIssueType.DataBind();
        //        ddlDepartment.Items.Clear();
        //        ddlDepartment.Items.Add(new ListItem("Select an Option", "0"));
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ListItem lst = new ListItem();
        //            lst.Text = dr["DepartmentTitle"].ToString();
        //            lst.Value = dr["DepartmentID"].ToString();
        //            ddlDepartment.Items.Add(lst);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = "LoadDepartment():" + ex.Message;
        //    }
        //}

        protected void txtBookID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                BLNewBook _objNewBook = new BLNewBook();
                DataTable dt = _objNewBook.GetBookInfo(txtBookID.Text.Trim());
                foreach (DataRow dr in dt.Rows)
                {
                    txtBookName.Text=dr["BookTitle"].ToString();
                    txtAuthorName.Text=dr["WriterName"].ToString();
                    lblStock.Text = dr["NumberOfBook"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "txtBookID_TextChanged():"+ex.Message;
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

        protected void btnSaveBookIssueType_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblMess.Text = string.Empty;
            BOAddIssueType _objBOIssueType = new BOAddIssueType();
            BLIssueType _objBLIssueType = new BLIssueType();
            try
            {
                _objBOIssueType.IssueType = txtIssueType.Text;
                bool IsSave = _objBLIssueType.CreateIssueType(_objBOIssueType);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    GetIssueType();
                    txtIssueType.Text = "";
                }
                else
                {
                    lblError.Text = "Data can't  Saved";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
      
    }
}