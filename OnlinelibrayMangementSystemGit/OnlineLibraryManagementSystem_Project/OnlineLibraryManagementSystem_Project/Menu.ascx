<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="OnlineLibraryManagementSystem_Project.Menu" %>

<ul class="nav nav-tabs nav-stacked main-menu">
	<li><a href="index.html"><i class="icon-bar-chart"></i><span class="hidden-tablet"> Dashboard</span></a></li>
    <% System.Data.DataTable dt = (System.Data.DataTable)Session["dtPermission"];
       foreach(System.Data.DataRow dr in dt.Rows)
       {
    %>
     <li><a href='<% Response.Write(dr["PageUrl"].ToString());%>'><i class="halflings-icon book"></i><span class="hidden-tablet"><%Response.Write(dr["MenuName"].ToString());%></span></a></li>	
    <%} %>
	
</ul>
