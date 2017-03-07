using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineLibraryManagementSystem_Project.BL;
using System.Data;
using System.Text;
namespace OnlineLibraryManagementSystem_Project
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllBook();
                LoadAttbyGrap();
            }
        }
        public void LoadAllBook()
        {
            BLIndex _objIndex = new BLIndex();
            DataTable dt = _objIndex.GetAllBook();
            gvBookList.DataSource = dt;
            gvBookList.DataBind();
            Session["dtAllbook"] = dt;
        }

        protected void gvBookList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBookList.PageIndex = e.NewPageIndex;
            gvBookList.DataSource = (DataTable)Session["dtAllbook"];
            gvBookList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BLIndex _objIndex = new BLIndex();
            DataTable dt = _objIndex.GetAllBook(txtSearch.Text);
            gvBookList.DataSource = dt;
            gvBookList.DataBind();
            Session["dtAllbook"] = dt;
        }
        public void LoadAttbyGrap()
        {
            StringBuilder str = new StringBuilder();
            try
            {
                BLIndex _objIndex = new BLIndex();
                DataTable dt = _objIndex.GetBookNumber();
                DataTable personTable = new DataTable("ChartInfo");
                personTable.Columns.Add("Label", typeof(string));
                personTable.Columns.Add("AmountoBook", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {

                    DataRow row = personTable.NewRow();

                    personTable.Rows.Add(dr["CategoryTitle"].ToString(),dr["TotalBook"].ToString());                                 


                }
                str.Append(@"<script type=*text/javascript*> google.load( *visualization*, *1*, {packages:[*corechart*]});
                        google.setOnLoadCallback(drawChart);
                       function drawChart() {
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Label');
                        data.addColumn('number', 'Book Amount');     
                        data.addColumn({type: 'string', role: 'annotation'});                                              
                        data.addRows([");
                int count = personTable.Rows.Count - 1;
                for (int i = 0; i <= count; i++)
                {
                    if (count == i)
                    {
                        str.Append("['" + personTable.Rows[i]["Label"].ToString() + "'," + personTable.Rows[i]["AmountoBook"].ToString() + ",'" + personTable.Rows[i]["AmountoBook"].ToString() + "']");
                    }
                    else
                    {
                        str.Append("['" + personTable.Rows[i]["Label"].ToString() + "'," + personTable.Rows[i]["AmountoBook"].ToString() + ",'" + personTable.Rows[i]["AmountoBook"].ToString() + "'],");
                    }

                }
                str.Append("]);");
                str.Append("var view = new google.visualization.DataView(data); view.setColumns([0, 1, 1, 2]); var chart = new google.visualization.ColumnChart(document.getElementById('div_Area'));");
                str.Append(" chart.draw(view, {title: 'DIU Library Book Sumary',chartArea: {top:39},height: 400,width: 800,legend: {position: 'none'},series: {  0: {type: 'bars'}, 1: {type: 'line',color: 'grey',lineWidth: 0,pointSize: 0,visibleInLegend: false}}, vAxis: { minValue: 0, maxValue: 100,format: '#' },hAxis: {  minValue: 0, maxValue: 100, format: '#'}});}");
                str.Append("</script>");
                lt.Text = str.ToString().Replace('*', '"');
            }
            catch (Exception ex)
            {
                lblError.Text = "LoadClasswisePassFail():" + ex.Message;
            }
        }
    }
}