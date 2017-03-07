<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmTeacherInfo.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.FrmTeacherInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
				<li><a href="FrmBook.aspx">Teacher Information Entry </a></li>
			</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
     <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span>Teacher Information Entry</h2>
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
                                     <asp:Label ID="lblMess" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="lblError" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                       
                        <table>
                           
                             <tr>
                                <td> <asp:Label ID="Label1" runat="server" Text="TeacherID:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtTeacherID"  placeholder="Please Teacher ID" CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td> <asp:Label ID="Label2" runat="server" Text="Teacher Name:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtTeacherName"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                             <tr>
                                <td> <asp:Label ID="Label3" runat="server" Text="Department:" CssClass="control-label"></asp:Label></td>
                               <td><asp:DropDownList ID="ddlDepartment"  date-rel="coshen" Width="283px" runat="server"></asp:DropDownList></td>
                                <td> <asp:Button ID="NewDepartment" runat="server" Text= "New.." />  </td>
                            </tr>



                           <%-- <tr>
                                <td> <asp:Label ID="Label3" runat="server" Text="Department:" CssClass="control-label"></asp:Label></td>
                               <td> <asp:DropDownList ID="ddlDepartment" data-rel="chosen" Width="284px" CssClass="input-xlarge focused" runat="server"></asp:DropDownList></td>
                            </tr>--%>
                            <tr>
                                <td> <asp:Label ID="Label4" runat="server" Text="Address:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtAddress"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                             <tr>
                                <td> <asp:Label ID="Label8" runat="server" Text="Father Name:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtFatherName"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                             <tr>
                                <td> <asp:Label ID="Label10" runat="server" Text="MotherName:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtMotherName"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td> <asp:Label ID="Label5" runat="server" Text="MobileNo:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtMobileNo"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td> <asp:Label ID="Label6" runat="server" Text="Email:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtEmail"  CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                            </tr>

                             <tr>
                                <td> <asp:Label ID="Label7" runat="server" Text="TeacherPic:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            </tr>
                             <tr>
                                 <td> <asp:Label ID="Label9" runat="server" Text="EntryDate:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtEntryDate"   CssClass="input-xlarge focused" runat="server"></asp:TextBox></td>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEntryDate" Format="dd/MM/yyyy" runat="server" />
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
                   

			</div>

	</div>

        <ajaxToolkit:ModalPopupExtender ID="MdTrDepartment"  PopupControlID="pnlDepartment" CancelControlID="btnCloseDepartment" TargetControlID="NewDepartment" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlDepartment"  Style="display:none"    CssClass="Popup" runat="server">
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
</asp:Content>
