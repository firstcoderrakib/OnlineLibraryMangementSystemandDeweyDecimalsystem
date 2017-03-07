using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystem_Project.BL;
namespace OnlineLibraryManagementSystem_Project
{
    public partial class frmStudentBookHis : System.Web.UI.Page
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
                DataTable dt = _objCard.LoadStudentLiCard(Session["ID"].ToString());
                Session["dtBooklist"] = dt;
                gvBookList.DataSource = dt;
                gvBookList.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = "LoadLiCard():" + ex.Message;
            }
        }
    }
}