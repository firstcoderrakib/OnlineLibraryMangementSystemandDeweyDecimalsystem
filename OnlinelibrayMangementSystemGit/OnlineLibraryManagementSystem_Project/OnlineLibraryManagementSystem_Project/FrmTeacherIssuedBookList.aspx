<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmTeacherIssuedBookList.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.FrmTeacherIssuedBookList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
    </style>
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
				<li><a href="FrmTeacherIssuedBookList.aspx">Book Information Entry</a></li>
			</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
    <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span>Teacher Issued book list</h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
					<div class="box-content">
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblMess" runat="server" Text="" ForeColor="#009900"></asp:Label>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Teacher ID:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtTeacherID" runat="server"></asp:TextBox></td>
                                <td> <asp:Button ID="btnSearch" runat="server"  Text="Search" OnClick="btnSearch_Click" /></td>
                                <td>
                                    <asp:Button ID="btnRelod" runat="server" Text="Reload" OnClick="btnRelod_Click"/></td>
                            </tr>
                        </table>
                        <table>
                              <asp:GridView ID="gvTrBookList" CssClass="table table-striped table-bordered bootstrap-datatable datatable" AllowPaging="true" PageSize="10"  DataKeyNames="TeacherID,BookID" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvTrBookList_PageIndexChanging" OnRowDeleting="gvTrBookList_RowDeleting" OnRowEditing="gvTrBookList_RowEditing" OnRowCancelingEdit="gvTrBookList_RowCancelingEdit" OnRowUpdating="gvTrBookList_RowUpdating">
                                  <Columns>
                                      <asp:TemplateField HeaderText="Book ID">
                                          <ItemTemplate>
                                              <asp:Label ID="lblBookID" runat="server" Text='<%#Eval("BookID") %>'>'></asp:Label>
                                          </ItemTemplate>
                                        
                                      </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Teacher ID">
                                          <ItemTemplate>
                                              <asp:Label ID="lblTeacherID" runat="server" Text='<%#Eval("TeacherID") %>'>'></asp:Label>
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:label ID="lblTid" runat="server" Text='<%#Eval("TeacherID") %>'></asp:label>
                                          </EditItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Author Name">
                                          <ItemTemplate>
                                              <asp:Label ID="lblAu" runat="server" Text='<%#Eval("WriterName") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Book Title">
                                          <ItemTemplate>
                                              <asp:Label ID="lblB" runat="server" Text='<%#Eval("BookTitle") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Teacher Name">
                                          <ItemTemplate>
                                              <asp:Label ID="lblTrName" runat="server" Text='<%#Eval("TeacherName") %>'>'></asp:Label>
                                          </ItemTemplate>
                                        
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Isuee Date">
                                          <ItemTemplate>
                                              <asp:Label ID="lblIs" runat="server" Text='<%#Eval("IsueeDate") %>'>'></asp:Label>
                                          </ItemTemplate>
                                         
                                      </asp:TemplateField>


                                       <asp:TemplateField HeaderText="Return Date">
                                          <ItemTemplate>
                                              <asp:Label ID="lblRe" runat="server" Text='<%#Eval("ReturnDate") %>'>'></asp:Label>
                                          </ItemTemplate>
                                          
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Renew Date">
                                          <ItemTemplate>
                                              <asp:Label ID="lblRenuDate" runat="server" Text='<%#Eval("RenewDate") %>'>'></asp:Label>
                                          </ItemTemplate>
                                           <EditItemTemplate>
                                              <asp:TextBox ID="txtRenewDate" runat="server"  Width="90px"  Text='<%#Eval("RenewDate") %>'>'></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtRenewDate" Format="dd/MM/yyyy" runat="server" />

                                          </EditItemTemplate>
                                      </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Fine Day">
                                          <ItemTemplate>
                                              <asp:Label ID="lblFineday" runat="server" Text='<%#Convert.ToInt32(Eval("TotalDay"))>0?Eval("TotalDay"):0 %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Fine">
                                          <ItemTemplate>
                                              <asp:Label ID="lblFine" runat="server" Text='<%#Convert.ToInt32(Eval("Fine"))>0?Eval("Fine"):0 %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                      <asp:CommandField ButtonType="Image" ShowDeleteButton="true" ShowEditButton="true" DeleteImageUrl="~/img/sidebar-search-close-brown.png" EditImageUrl="~/img/portlet-config-icon.png" HeaderText="Option" EditText="Renue" DeleteText="Retrun" />
                                  </Columns>
                        </asp:GridView>
                        </table>
                      
                       
                    </div>
				</div>

			</div>
</asp:Content>
