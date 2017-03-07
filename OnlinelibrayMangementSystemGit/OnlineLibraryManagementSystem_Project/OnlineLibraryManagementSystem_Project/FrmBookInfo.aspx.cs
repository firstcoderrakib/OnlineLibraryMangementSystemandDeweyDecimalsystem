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
    public partial class FrmBookInfo : System.Web.UI.Page
    {
        BLBookCategory _objBookCategory = new BLBookCategory();
        BLNewBook _objBLNewBook = new BLNewBook();
        BONewBook _objBONewBook = new BONewBook();
        BLBookCategory _objBLBookCategory = new BLBookCategory();
        BOAddCategoryTitle _objBOBookCategory = new BOAddCategoryTitle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBookLanguage();
                GetShelf();
                GetEdition();
                GetBookCategory();
                GetBookCell();
                GetIssueType();
                GetBookCell();
 
            }
            
        }

        public void GetBookCategory()
        {
            try
            {                
                DataTable dt = _objBookCategory.LoadBookCategory();
                
                ddlBookCategory.Items.Clear();
                ddlBookCategory.Items.Add(new ListItem("-Select book category-", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Value = dr["CategoryID"].ToString();
                    lst.Text =dr ["CategoryTitle"].ToString();
                    ddlBookCategory.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "GetBookCategory():"+ex.Message;
            }
        }
      

        protected void ddlBookCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int BookIdInvalue = 10000;               
                lblError.Text = string.Empty;
                int BookID =  _objBLNewBook.GetBookID(ddlBookCategory.SelectedValue.ToString().Trim());
                if (BookID == 0)
                {
                    BookID = 1;
                }
                BookID = BookIdInvalue + BookID;
                txtBookID.Text = ddlBookCategory.SelectedValue.ToString().Trim() + "-" + BookID.ToString();
                

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlBookCategory_SelectedIndexChanged():"+ex.Message;
            }
        }

        public void GetBookLanguage()
        {
            try
            {
                BLBookLanguage _objLanguage = new BLBookLanguage();
                DataTable dt = _objLanguage.LoadBookLanguage();
                ddlBookLanguage.Items.Clear();
                ddlBookLanguage.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["BookLanguage"].ToString();
                    lst.Value = dr["ID"].ToString();
                    ddlBookLanguage.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "GetBookLanguage():" + ex.Message;

            }
        }
        public void GetShelf()
        {
            try
            {
                BLShelf _objShelf = new BLShelf();
                DataTable dt = _objShelf.LoadShelf();
                
                ddlBookShelf.Items.Clear();
                ddlBookShelf.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text =dr["ShelfTitle"].ToString();
                    lst.Value = dr["ID"].ToString();
                    ddlBookShelf.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "GetShelf():"+ex.Message;
 
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
                lblError.Text = "GetIssueType():"+ex.Message;
            }
        }
        public void GetEdition()
        {
            try
            {


                BLEdition _obEdition = new BLEdition();
                DataTable dt = _obEdition.LoadEdition();
                ddlEdition.Items.Clear();
                ddlEdition.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["EditionTitle"].ToString();
                    lst.Value = dr["ID"].ToString();
                    ddlEdition.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "GetEdition():" + ex.Message;
            }
 
        }
        public void GetBookCell()
        {
            try
            {
                BLBookCell _objBookCell = new BLBookCell();
                DataTable dt = _objBookCell.LoadBookCell();
                ddlBookCell.Items.Clear();
                ddlBookCell.Items.Add(new ListItem("Select an Option", "0"));
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = dr["CellTitle"].ToString();
                    lst.Value = dr["ID"].ToString();
                    ddlBookCell.Items.Add(lst);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "GetBookCell():"+ex.Message;
            }
        }
            
      
     
 
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                _objBONewBook.BookID = txtBookID.Text;
                _objBONewBook.BookName = txtBookTitle.Text;
                _objBONewBook.BookCategoryID = ddlBookCategory.SelectedValue.ToString();
                _objBONewBook.WriterName = txtWriterName.Text;
                _objBONewBook.Edition = ddlEdition.SelectedValue.ToString();
                _objBONewBook.PublishedYear = txtPublishYear.Text;
                _objBONewBook.BookLanguageID = ddlBookLanguage.SelectedValue.ToString();
                _objBONewBook.ShelfID = ddlBookShelf.SelectedValue.ToString();
                _objBONewBook.CellID = ddlBookCell.SelectedValue.ToString();
                _objBONewBook.IssueTypeID = ddlIssueType.SelectedValue.ToString();
                _objBONewBook.NumberOfBook = txtNumberOfBook.Text;
                _objBONewBook.EntryDate = txtEntryDate.Text;
                _objBONewBook.EntryBy = "System";
               
                bool Issave =   _objBLNewBook.CreateNewBook(_objBONewBook);
                if (Issave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    txtBookID.Text = "";
                    txtBookTitle.Text = "";
                    txtPublishYear.Text = "";
                    txtNumberOfBook.Text = "";
                    txtEntryDate.Text = "";
                    txtWriterName.Text = "";
                }
               
            }
            catch (Exception ex)
            {
                lblError.Text = "btnsave_Click():"+ex.Message;
 
            }
        }
        //public void LoadBookLanguage()
        //{
        //    try
        //    {

        //        BLLanguageBook _objBLLanguage = new BLLanguageBook();
        //        DataTable dt = _objBLLanguage.LoadLanguageBook();
        //        ddlBookLanguage.Items.Clear();
        //        ddlBookLanguage.Items.Add(new ListItem("Select an Option", "0"));
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ListItem lst = new ListItem();
        //            lst.Text = dr["BookLanguage"].ToString();
        //            lst.Value = dr["ID"].ToString();
        //            ddlBookLanguage.Items.Add(lst);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblError.Text = "LoadBookLanguage():" + ex.Message;
        //    }
          
        //}

        protected void btnSaveBookCat_Click(object sender, EventArgs e)
        {
            try
            {
            _objBOBookCategory.CategoryID = txtBookCategoryID.Text;
                _objBOBookCategory.CategoryTitle = txtBookCategoryTitle.Text;
                bool IsSave = _objBLBookCategory.CreateBookCategory(_objBOBookCategory);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    GetBookCategory();
                    txtBookCategoryID.Text = "";
                    txtBookCategoryTitle.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnsave_Click():"+ex.Message;
            }
        }

        protected void ddlEdition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEdition_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ddlBookLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlBookCell_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlIssueType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlBookShalf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlBookShelf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSaveBookEdition_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblMess.Text = string.Empty;
            BOAddEdition _objBOEdition = new BOAddEdition();
            BLAddEdition _objBLEdition = new BLAddEdition();
            try
            {
                _objBOEdition.EditionTitle = txtEditionTitle.Text;
                bool IsSave = _objBLEdition.CreateEdition(_objBOEdition);
                if (IsSave)
                {
                    lblMess.Text = "Data Has been Successfully Saved";
                    txtEditionTitle.Text = "";
                    GetEdition();
                }
                else
                {
                    lblError.Text = "Data can't Saved";
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

        protected void btnBookLanguageTitle_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblMess.Text = string.Empty;
            BOAddLanguageBook _objBOLanguageBook = new BOAddLanguageBook();
            BLBookLanguage _objBLLanguageBook = new BLBookLanguage();
            try
            {
                _objBOLanguageBook.BookLanguage = txtBookLanguageTitle.Text;
                bool IsSave = _objBLLanguageBook.CrateLanguageBook(_objBOLanguageBook);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    GetBookLanguage();
                    //LoadBookLanguage();
                    txtBookLanguageTitle.Text = "";
                }
                else
                {
                    lblError.Text = "Data can't Saved";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnSaveBookShelf_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblMess.Text = string.Empty;
            BOAddShelf _objBOAddShelf = new BOAddShelf();
            BLShelf _objBLShelf = new BLShelf();
            try
            {
                _objBOAddShelf.ShelfTitle = txtShelfTitle.Text;
                bool IsSave = _objBLShelf.CreateShelf(_objBOAddShelf);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    GetShelf();
                    txtShelfTitle.Text = "";
                }
                else
                {
                    lblError.Text = "Data can't Saved";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnSaveBookCell_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblMess.Text = string.Empty;
            BOAddBookCell _objBOBookCell = new BOAddBookCell();
            BLBookCell _objBLBookCell = new BLBookCell();
            try
            {
                _objBOBookCell.BookCellTitle = txtCellTitle.Text;
                bool IsSave = _objBLBookCell.CreateBookCell(_objBOBookCell);
                if (IsSave)
                {
                    lblMess.Text = "Data has been Successfully Saved";
                    GetBookCell();
                    txtCellTitle.Text = "";

                }
                else
                {
                    lblError.Text = "Data can't Saved";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "btnsave_Click():" + ex.Message;
            }
        }
       
    }
}