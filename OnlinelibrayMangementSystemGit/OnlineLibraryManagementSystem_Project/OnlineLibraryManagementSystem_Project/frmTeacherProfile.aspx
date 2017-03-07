<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="frmTeacherProfile.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.frmTeacherProfile" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideManu" runat="server">
    <uc1:Menu runat="server" ID="Menu" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContNav" runat="server">
    <ul class="breadcrumb">
				<li>
					<i class="icon-home"></i>
					<a href="index.html">Home</a> 
					<i class="icon-angle-right"></i>
				</li>
				<li><a href="frmTeacherProfile.aspx">Teacher Profile</a></li>
			</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
     <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span><asp:Label ID="lblName" runat="server" Text="" ForeColor="Green"></asp:Label></h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
					<div class="box-content">
                        <div> <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label> </div>
                         <div style=" width:100%">
                          <div style="width:48%; float:left">
                              <table>
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label></td>
                                  </tr>

                                  <tr>
                                      <td>
                                          <asp:Label ID="Label2" runat="server" Text="Teacher ID:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblTeacherID" runat="server" Text=""></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
                                  </tr>

                                  <tr>
                                      <td>
                                          <asp:Label ID="Label6" runat="server" Text="Department:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label></td>
                                  </tr>

                                  <tr>
                                      <td>
                                          <asp:Label ID="Label4" runat="server" Text="Mobile No:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label></td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <asp:Label ID="Label5" runat="server" Text="Father Name:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblFatherName" runat="server" Text=""></asp:Label></td>
                                  </tr>

                                  <tr>
                                      <td>
                                          <asp:Label ID="Label7" runat="server" Text=" Mother Name:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblMotherName" runat="server" Text=""></asp:Label></td>
                                  </tr>

                                  <tr>
                                      <td>
                                          <asp:Label ID="Label8" runat="server" Text="Email:"></asp:Label></td>
                                      <td>
                                          <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
                                  </tr>

                              </table>
                          </div>
                          <div style="width:48%; float:left">
                              <asp:Image ID="imgTeacher" Width="100px" Height="100px" runat="server" /></div>
                       </div>
                     </div>
				</div>

			</div>   

</asp:Content>
