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
using System.Net;
namespace OnlineLibraryManagementSystem_Project
{
    public partial class FrmStudentLibraryCard : System.Web.UI.Page
    {
        BOStudentLibraryCardInfo _objBOStudentLibraryCardInfo = new BOStudentLibraryCardInfo();
        BLStudentLibraryCard _objBLStudentLibraryCardInfo = new BLStudentLibraryCard();
        BLStudentinfo _objStudent = new BLStudentinfo();

        BODepartment _objBODepartment = new BODepartment();
        BLDepartment _objBLDepartment = new BLDepartment();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartment();
                GetIssueType();
 
            }
        }
         
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                _objBOStudentLibraryCardInfo.StudentName = txtStudentName.Text;
                _objBOStudentLibraryCardInfo.StudentID = txtStudentID.Text;
                _objBOStudentLibraryCardInfo.BookID = txtBookID.Text;
                _objBOStudentLibraryCardInfo.IsueeDate = txtIssueDate.Text;
                _objBOStudentLibraryCardInfo.ReturnDate = txtReturnDate.Text;
                _objBOStudentLibraryCardInfo.EntryBy = "System";
                _objBOStudentLibraryCardInfo.EntryDate = "System";
                _objBOStudentLibraryCardInfo.IssueType=int.Parse(ddlIssueType.SelectedValue.ToString());
                _objBOStudentLibraryCardInfo.IsRetrun = 0;
                _objBOStudentLibraryCardInfo.IsRenew = 0;
                bool IsSave = _objBLStudentLibraryCardInfo.CreateStudentInfo(_objBOStudentLibraryCardInfo);
                if (IsSave)
                {
                    SendMail();
                    lblMess.Text = "Data has been Successfully Saved";                    
                    txtStudentName.Text = "";
                    txtStudentID.Text = "";
                    txtBookID.Text = "";
                    txtIssueDate.Text = "";
                    txtReturnDate.Text = "";
                    txtAuthorName.Text = "";
                    lblStock.Text = "";
                    txtBookName.Text = "";
                   
                    


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
            var toAddress =hdEmail.Value.ToString();
            //Password of your gmail address
            
            // Passing the values and make a email formate to display
            string subject = BLGlobalVar.EmailSubject;
            string body = "Dear  " + txtStudentName.Text + ",\n You has been issued  " + txtBookName.Text + " from DIU Library at " + System.DateTime.Now + "\n BR \n Librain \n DIU";
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

       
        public void GetBookDepartment()
        {
            try
            {
                BLDepartment _objDepartment = new BLDepartment();
                DataTable dt = _objDepartment.LoadDepartment();
                ddlDepartment.Items.Clear();
                ddlDepartment.Items.Add(new ListItem("Select an Option","0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["DepartmentTitle"].ToString();
                    lst.Value = dr["DepartmentID"].ToString();
                    ddlDepartment.Items.Add(lst);
                }
               
            }
            catch(Exception ex)
            {
                lblError.Text="GetBookDepartment():"+ex.Message;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string ImageUrl = "StudentImage/{0}";
                DataTable dtTeacher = _objStudent.GetStudentinfo(txtStudentID.Text);
                foreach (DataRow dr in dtTeacher.Rows)
                {
                    lblNme.Text = dr["StudentName"].ToString();
                    txtStudentName.Text = dr["StudentName"].ToString();
                    hdEmail.Value = dr["Email"].ToString();
                    ddlDepartment.SelectedValue = dr["DepartmentID"].ToString();
                    lblID.Text = dr["StudentID"].ToString();
                    lblDepart.Text = dr["DepartmentTitle"].ToString();
                    ImageUrl = string.Format(ImageUrl, dr["StudentPic"].ToString());
                    imgPic.ImageUrl = "StudentImage/img.jpg";

                }
                lblIssuebook.Text = _objStudent.GetStudentBookNumber(txtStudentID.Text).ToString();
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                lblError.Text=ex.Message;
 
            }
            
        }
        public void GetIssueType()
        {
            try
            {
                BLIssueType _objIssueType = new BLIssueType();
                DataTable dt = _objIssueType.LoadIssueType();
               
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
                lblError.Text = "txtBookID_TextChanged():" + ex.Message;
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

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