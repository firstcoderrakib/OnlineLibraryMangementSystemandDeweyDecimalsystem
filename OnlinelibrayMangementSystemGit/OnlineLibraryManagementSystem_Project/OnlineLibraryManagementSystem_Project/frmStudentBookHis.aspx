<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="frmStudentBookHis.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.frmStudentBookHis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideManu" runat="server">
    <uc1:Menu runat="server" ID="Menu" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContNav" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
    <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span>Student Issued book list</h2>
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
                              <asp:GridView ID="gvBookList" CssClass="table table-striped table-bordered bootstrap-datatable datatable" DataKeyNames="StudentID,BookID" AllowPaging="true" PageSize="10"  AutoGenerateColumns="false"  runat="server" >
                                  <Columns>
                                      <asp:TemplateField HeaderText="Book ID">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("BookID") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>


                                       <asp:TemplateField HeaderText="Student ID">
                                          <ItemTemplate>
                                              <asp:Label ID="lblStudentID" runat="server" Text='<%#Eval("StudentID") %>'>'></asp:Label>
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:TextBox ID="txtStudentID" runat="server" Text='<%#Eval("StudentID") %>'></asp:TextBox>
                                          </EditItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Author Name">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("WriterName") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Book Title">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("BookTitle") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Student Name">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("StudentName") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Isuee Date">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("IsueeDate") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Return Date">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("ReturnDate") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Renew Date">
                                          <ItemTemplate>
                                              <asp:Label ID="Label1" runat="server" Text='<%#Eval("RenewDate") %>'>'></asp:Label>
                                          </ItemTemplate>
                                      </asp:TemplateField>




                                  </Columns>
                        </asp:GridView>
                        </table>
                    </div>                    
				</div>
			</div>
</asp:Content>
