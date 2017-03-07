using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using OnlineLibraryManagementSystem_Project.BL;

namespace OnlineLibraryManagementSystem_Project
{
    public partial class FrmStudentIssuedBookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLiCard();
            }

        }
        public void LoadLiCard()
        {
            try
            {
                BLStudentLibraryCard _objCard = new BLStudentLibraryCard();
                DataTable dt = _objCard.LoadStudentLiCard();
                Session["dtBooklist"] = dt;
                gvBookList.DataSource = dt;
                gvBookList.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = "LoadLiCard():" + ex.Message;
            }
        }

        protected void gvBookList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                lblError.Text = string.Empty;
                gvBookList.PageIndex = e.NewPageIndex;
                gvBookList.DataSource = (DataTable)Session["dtBooklist"];
                gvBookList.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
           
        }

        protected void gvBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // string StrStuentID = e.Keys["StudentID"].ToString();
                string StrStuentID = gvBookList.DataKeys[e.RowIndex].Values[0].ToString();
                string BookID = gvBookList.DataKeys[e.RowIndex].Values[1].ToString();
                BLStudentLibraryCard _objStudent = new BLStudentLibraryCard();
                bool IsSave = _objStudent.DeleteStudent(StrStuentID, BookID);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Deleted";
                    LoadLiCard();

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "gvBookList_RowDeleting():" + ex.Message;

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BLStudentLibraryCard _objCard = new BLStudentLibraryCard();
                DataTable dt = _objCard.LoadStudentLiCardbyStudentID(txtStudentID.Text.Trim());
                gvBookList.DataSource = dt;
                gvBookList.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;

            }
        }

        protected void btnRelod_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                LoadLiCard();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void gvBookList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvBookList.EditIndex = e.NewEditIndex;
                LoadLiCard();
            }
            catch (Exception ex)
            {
                lblError.Text = "gvBookList_RowEditing():"+ex.Message;
            }
        }

        protected void gvBookList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBookList.EditIndex = -1;
            LoadLiCard();
        }

        protected void gvBookList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string StudentName = ((Label)gvBookList.Rows[e.RowIndex].FindControl("lblSt")).Text;
                string StudentID = ((Label)gvBookList.Rows[e.RowIndex].FindControl("lblSID")).Text;
                string BookID = ((Label)gvBookList.Rows[e.RowIndex].FindControl("lblBid")).Text;
                string RenewDate = ((TextBox)gvBookList.Rows[e.RowIndex].FindControl("txtRenuwDate")).Text;
                BLStudentLibraryCard _objStuent = new BLStudentLibraryCard();
                   bool IsSave=  _objStuent.UpdateStudent(StudentName,RenewDate,StudentID,BookID);
                   if (IsSave)
                   {
                       lblMess.Text = "Data has been Successfully Updated";
                       gvBookList.EditIndex = -1;
                       LoadLiCard();
                   }

            }
            catch (Exception ex)
            {
                lblError.Text = "gvBookList_RowUpdating():" + ex.Message;
 
            }
        }
    }
}