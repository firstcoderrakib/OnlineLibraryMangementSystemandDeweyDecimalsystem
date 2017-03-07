﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmStudentLibraryCard.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.FrmStudentLibraryCard" %>

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
				<li><a href="FrmStudentLibraryCard.aspx">Student Library Card Information Entry</a></li>
			</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
     <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span>Student Library Card Information Entry</h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
		<div class="box-content">

        <asp:Label ID="lblError" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
        <asp:Label ID="lblMess" runat="server" Text="" ForeColor="#009900"></asp:Label>
                       
                        <table>
                             <tr>
                                <td> <asp:Label ID="Label3" runat="server" Text="Student ID:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtStudentID" placeholder="Please Student ID" CssClass="input-xlarge focused" runat="server" ></asp:TextBox></td>
                                <td> <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                            </tr>

                            <tr>
                                <td> <asp:Label ID="Label2" runat="server" Text="Student Name:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtStudentName" placehfolder="Please Student Name" CssClass="input-xlarge focused" runat="server"></asp:TextBox>
                                    <asp:HiddenField ID="hdEmail" runat="server" Value="" />
                                </td>
                            </tr>


                            <%--  <tr>
                                <td style="margin-left: 160px"> <asp:Label ID="Label18" runat="server" Text="Department :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlDepartment" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewDepartment" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>--%>

                              <tr>
                                <td> <asp:Label ID="Label1" runat="server" Text="Department:" CssClass="control-label"></asp:Label></td>
                               <td><asp:DropDownList ID="ddlDepartment"  date-rel="coshen" Width="283px" runat="server"></asp:DropDownList></td>
                                <td> <asp:Button ID="NewDepartment" runat="server" Text= "New.." />  </td>
                            </tr>



                         <%--   <tr>
                                <td><asp:Label ID="Label1" runat="server" Text="Department"></asp:Label></td>
                                <td><asp:DropDownList ID="ddlDepartment" Width="283px" data-rel="chosen" runat="server" ></asp:DropDownList></td>
                            </tr>--%>



                            <tr>
                                <td> <asp:Label ID="Label4" runat="server" Text="Book ID:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtBookID"  CssClass="input-xlarge focused" runat="server" AutoPostBack="true" OnTextChanged="txtBookID_TextChanged"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td> <asp:Label ID="Label7" runat="server" Text="Book Name:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtBookName"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td> <asp:Label ID="Label13" runat="server" Text="Author Name:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtAuthorName"  CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td> <asp:Label ID="Label14" runat="server" Text="Stock:" CssClass="control-label"></asp:Label></td>
                                <td><asp:Label ID="lblStock" runat="server" ForeColor="Green" Text="0"></asp:Label></td>
                            </tr>

                            <tr>
                                <td> <asp:Label ID="Label5" runat="server" Text="Issue Type:" CssClass="control-label"></asp:Label></td>
                               <td><asp:DropDownList ID="ddlIssueType"   Width="283px" runat="server"></asp:DropDownList></td>
                                <td> <asp:Button ID="NewBookIssueType" runat="server" Text="New.." />  </td>
                            </tr>
                             <tr>
                                <td> <asp:Label ID="Label12" runat="server" Text="Issue Date:" CssClass="control-label"></asp:Label></td>
                                <td><asp:TextBox ID="txtIssueDate"   CssClass="input-xlarge focused" runat="server"></asp:TextBox> </td>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtIssueDate" Format="dd/MM/yyyy" runat="server" />
                            </tr>
                            <tr>
                                <td> <asp:Label ID="Label6" runat="server" Text="ReturnDate:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtReturnDate" CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtReturnDate" Format="dd/MM/yyyy" runat="server" />
                            </tr>
                           <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click" /></td>
                                            <td><asp:Button ID="btncancal" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
                                           </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
				</div>

                 <div class="box-content">
                     <asp:Label ID="lblStudent" runat="server"></asp:Label>
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1"  PopupControlID="PnlStudentInfo" CancelControlID="btnClose" TargetControlID="lblStudent" runat="server"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="pnlStudentInfo" runat="server" CssClass="Popup" align="center" style = "display:none" >
                        <table>
                            <tr>
                                <td></td><td></td>
                                <td> <asp:Image ID="imgPic" runat="server" Width="100px" Height="100px"/></td>
                            </tr>
                        </table>
                        <table>
                             <tr>
                                <td> <asp:Label ID="Label8" runat="server" Text="Student Name"></asp:Label> </td>
                                <td> <asp:Label ID="lblNme" runat="server"></asp:Label>  </td>

                            </tr>

                             <tr>
                                <td> <asp:Label ID="Label9" runat="server" Text="Student ID"></asp:Label> </td>
                                <td> <asp:Label ID="lblID" runat="server"></asp:Label>  </td>

                            </tr>

                             <tr>
                                
                                <td> <asp:Label ID="Label10" runat="server" Text="Department"></asp:Label> </td>
                                  
                                  
                                  
                                <td> <asp:Label ID="lblDepart" runat="server"></asp:Label>  </td>

                            </tr>

                             <tr>
                                <td> <asp:Label ID="Label11" runat="server" Text="Issue Book Amount"></asp:Label> </td>
                                <td> <asp:Label ID="lblIssuebook" runat="server" ></asp:Label>  </td>
                                 

                            </tr>
                        </table>
                        <asp:Button ID="btnClose" runat="server" Text="Close" />
                    </asp:Panel>
                  </div>
               </div>
         </div>
        <ajaxToolkit:ModalPopupExtender ID="MdStDepartment"  PopupControlID="pnlDepartment" CancelControlID="btnCloseDepartment" TargetControlID="NewDepartment" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlDepartment" Style="display:none"  CssClass="Popup" runat="server">
         <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Department Entry</h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
					<div class="box-content">
                        <table>
                            <tr>
                                <td>
                                     <asp:Label ID="Label15" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label16" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>  
                            <tr>
                                <td> <asp:Label ID="Label17" runat="server" Text="Department Name:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtDepartmentTitle" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSaveDepartment" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveDepartment_Click"/></td>
                                            <td><asp:Button ID="btnCloseDepartment" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
                                           </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                       </div>
				</div>

			</div>

    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="MdIssueType"  PopupControlID="pnlIssueType" CancelControlID="btnCancleBookIssueType" TargetControlID="NewBookIssueType" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlIssueType" CssClass="Popup" Style=" display:none"  runat="server">
        <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Add New Issue Type Entry</h2>
						<div class="box-icon">
							<a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a>
							<a href="#" class="btn-minimize"><i class="halflings-icon chevron-up"></i></a>
							<a href="#" class="btn-close"><i class="halflings-icon remove"></i></a>
						</div>
					</div>
					<div class="box-content">
                        <table>
                            <tr>
                                <td>
                                     <asp:Label ID="Label20" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label21" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>
                            <tr>
                                <td> <asp:Label ID="Label22" runat="server" Text="Add New Issue Type:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtIssueType" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSaveBookIssueType" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveBookIssueType_Click"/></td>
                                            <td><asp:Button ID="btnCancleBookIssueType" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
                                           </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                      </div>
				</div>
                    
			</div>
    </asp:Panel>

</asp:Content>
