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
    public partial class FrmTeacherBookHis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadLiCard();
            }
        }
         public void LoadLiCard()
        {
            try
            {
                BLTeacherLibraryCardInfo _objCard = new BLTeacherLibraryCardInfo();
                DataTable dt = _objCard.LoadTeacherLiCard(Session["ID"].ToString());
                Session["dtBooklist"] = dt;
                gvTrBookList.DataSource = dt;
                gvTrBookList.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "LoadLiCard():" + ex.Message;

            }
         }
    }
}