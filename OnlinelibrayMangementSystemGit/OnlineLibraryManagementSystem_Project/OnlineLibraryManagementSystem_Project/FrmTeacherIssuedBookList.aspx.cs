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
    public partial class FrmTeacherIssuedBookList : System.Web.UI.Page
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
                BLTeacherLibraryCardInfo _objCard = new BLTeacherLibraryCardInfo();
                DataTable dt = _objCard.LoadTeacherLiCard();
                Session["dtBooklist"] = dt;
                gvTrBookList.DataSource = dt;
                gvTrBookList.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "LoadLiCard():" + ex.Message;

            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                BLTeacherLibraryCardInfo _objCard = new BLTeacherLibraryCardInfo();
                DataTable dt = _objCard.LoadTeacherLiCardbyTeacherID(txtTeacherID.Text.Trim());
                gvTrBookList.DataSource = dt;
                gvTrBookList.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text =ex.Message;
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

        protected void gvTrBookList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                gvTrBookList.PageIndex = e.NewPageIndex;
                gvTrBookList.DataSource = (DataTable)Session["dtBooklist"];
                gvTrBookList.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void gvTrBookList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //string TrTeacherID = e.Keys["TeacherID"].ToString();
                string TrTeacherID=gvTrBookList.DataKeys[e.RowIndex].Values[0].ToString();
                string BookID=gvTrBookList.DataKeys[e.RowIndex].Values[1].ToString();
                BLTeacherLibraryCardInfo _objTeacher = new BLTeacherLibraryCardInfo();
                bool IsSave = _objTeacher.DeleteTeacher(TrTeacherID,BookID);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Deleted";
                    LoadLiCard();

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "gvTrBookList_RowDeleting()" + ex.Message;

            }
        }

        protected void gvTrBookList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvTrBookList.EditIndex = e.NewEditIndex;
                LoadLiCard();
            }
            catch (Exception ex)
            {
                lblError.Text = "gvTrBookList_RowEditing():"+ex.Message;
            }
        }

        protected void gvTrBookList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string TeacherName = ((Label)gvTrBookList.Rows[e.RowIndex].FindControl("lblTrName")).Text;
                string StudentID = ((Label)gvTrBookList.Rows[e.RowIndex].FindControl("lblTid")).Text;
                string BookID = ((Label)gvTrBookList.Rows[e.RowIndex].FindControl("lblBookID")).Text;
                string RenewDate = ((TextBox)gvTrBookList.Rows[e.RowIndex].FindControl("txtRenewDate")).Text;
                BLTeacherLibraryCardInfo _objTeacherLicard = new BLTeacherLibraryCardInfo();
                bool IsSave = _objTeacherLicard.UpdateTeacher(TeacherName,RenewDate, StudentID, BookID);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Updated";
                    gvTrBookList.EditIndex = -1;
                    LoadLiCard();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "gvTrBookList_RowUpdating():"+ex.Message;
            }
        }

        protected void gvTrBookList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTrBookList.EditIndex = -1;
            LoadLiCard();
        }
    }
}