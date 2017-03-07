<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FrmBookInfo.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.FrmBookInfo" %>
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
				<li><a href="FrmBookInfo.aspx">Book Information Entry</a></li>
			</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
    <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span>New Book Information Entry</h2>
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
                                <td style="margin-left: 160px"> <asp:Label ID="Label1" runat="server" Text="Book Category :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlBookCategory" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlBookCategory_SelectedIndexChanged" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewBookCategory" CssClass="btn btn-primary" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>

                            <tr>
                                <td> <asp:Label ID="Label2" runat="server" Text="Book ID:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtBookID" Width="205px"  CssClass="input-xlarge focused" Enabled="false" runat="server" ></asp:TextBox></td>
                            </tr>


                              <tr>
                                <td> <asp:Label ID="Label3" runat="server" Text="BookName:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtBookTitle" Width="205px"    CssClass="input-xlarge focused" runat="server" ></asp:TextBox></td>
                            </tr>

                            

                              <tr>
                                <td> <asp:Label ID="Label4" runat="server" Text="Author Name:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtWriterName"  Width="205px"    CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                  
                            </tr>

                            <tr>
                                <td style="margin-left: 160px"> <asp:Label ID="Label5" runat="server" Text="Edition :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlEdition" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlEdition_SelectedIndexChanged1" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewBookEditon" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>


                             <tr> 
                                <td> <asp:Label ID="Label6" runat="server" Text="Publish Year:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtPublishYear"  Width="205px"  CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                  <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtPublishYear" Format="dd/MM/yyyy" runat="server" />
                            </tr>


                              <tr>
                                <td style="margin-left: 160px"> <asp:Label ID="Label17" runat="server" Text="Language Book :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlBookLanguage" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlBookLanguage_SelectedIndexChanged" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewBookLanguage" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>

                          
                            <tr>
                                <td style="margin-left: 160px"> <asp:Label ID="Label11" runat="server" Text="Shelf :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlBookShelf" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlBookShelf_SelectedIndexChanged" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewBookShelf" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>



                              <tr>
                                <td style="margin-left: 160px"> <asp:Label ID="Label8" runat="server" Text="Book Cell :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlBookCell" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlBookCell_SelectedIndexChanged" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewBookCell" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>


                           

                             <tr>
                                <td style="margin-left: 160px"> <asp:Label ID="Label12" runat="server" Text="Issue Type :" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td style="margin-left: 120px"> <asp:DropDownList ID="ddlIssueType" date-rel="coshen" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlIssueType_SelectedIndexChanged" > </asp:DropDownList></td>
                                     <td><asp:Button ID="NewBookIssueType" runat="server"  Text="New.." /></td>
                                   </tr>
                                  </table>
                                </td>
                            </tr>





                              <tr>
                                <td> <asp:Label ID="Label9" runat="server" Text="Number Of Book:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtNumberOfBook"  Width="205px" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                            </tr>

                              <tr>
                                <td> <asp:Label ID="Label10" runat="server" Text= "Entry Date:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtEntryDate" Width="205px"  CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                  <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtEntryDate" Format="dd/MM/yyyy" runat="server" />

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
    <ajaxToolkit:ModalPopupExtender ID="MdBookCategory"  PopupControlID="pnlBookCategory" CancelControlID="btnCancleBookC" TargetControlID="NewBookCategory" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlBookCategory"  CssClass="Popup" Style=" display:none" runat="server">
         <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Add New Book Category Entry</h2>
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
                                     <asp:Label ID="Label7" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label13" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>


                              <tr>
                                <td> <asp:Label ID="Label15" runat="server" Text=" Category ID:" CssClass="control-label"></asp:Label></td>
                                <td> <asp:TextBox ID="txtBookCategoryID" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td> <asp:Label ID="Label16" runat="server" Text=" Book Category Title:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtBookCategoryTitle" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>

                          

                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSaveBookCat" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveBookCat_Click"  /></td>
                                            <td><asp:Button ID="btnCancleBookC" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
                                           </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                      </div>
				</div>
         
          </div>        
    </asp:Panel>
  <ajaxToolkit:ModalPopupExtender ID="MdbookEdition"  PopupControlID="pnlBookEdition" CancelControlID="btnCancleBookEdition" TargetControlID="NewBookEditon" runat="server"></ajaxToolkit:ModalPopupExtender> 
    <asp:Panel ID="pnlBookEdition" CssClass="Popup" Style=" display:none"  runat="server">
          <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Add New Edition Entry</h2>
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
                                     <asp:Label ID="Label14" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label18" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>
                            <tr>
                                <td> <asp:Label ID="Label19" runat="server" Text="Add New Edition Title:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtEditionTitle" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>

                           

                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSaveBookEdition" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveBookEdition_Click"/></td>
                                            <td><asp:Button ID="btnCancleBookEdition" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
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
     <ajaxToolkit:ModalPopupExtender ID="MdBookLanguage" PopupControlID="pnlBookLanguage" CancelControlID="btnBookLnguageClose" TargetControlID="NewBookLanguage" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlBookLanguage" CssClass="Popup" Style=" display:none"  runat="server">
         <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Add New Book Language Entry</h2>
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
                                     <asp:Label ID="Label23" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label24" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>
                            <tr>
                                <td> <asp:Label ID="Label25" runat="server" Text="Add Book Language Title:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtBookLanguageTitle" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnBookLanguageTitle" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnBookLanguageTitle_Click"/></td>
                                            <td><asp:Button ID="btnBookLnguageClose" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
                                           </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                      </div>
				</div>
                    
			</div>
    </asp:Panel>
     <ajaxToolkit:ModalPopupExtender ID="MdBookShelf" PopupControlID="pnlBookShelf" CancelControlID="btnCloseBookShelf" TargetControlID="NewBookShelf" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlBookShelf" CssClass="Popup" Style=" display:none"  runat="server">
          <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Add Shelf Information Entry</h2>
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
                                     <asp:Label ID="Label26" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label27" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>
                            <tr>
                                <td> <asp:Label ID="Label28" runat="server" Text="Add New Shelf No:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtShelfTitle" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSaveBookShelf" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveBookShelf_Click"/></td>
                                            <td><asp:Button ID="btnCloseBookShelf" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
                                           </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                      </div>
				</div>
                    
			</div>
    </asp:Panel>
     <ajaxToolkit:ModalPopupExtender ID="MdBookCell"  PopupControlID="pnlBCell" CancelControlID="btnCancleBookCell" TargetControlID="NewBookCell" runat="server"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlBCell" CssClass="Popup" Style=" display:none" runat="server">
        <div class="row-fluid sortable">
				<div class="box span12">
					<div class="box-header" data-original-title>
						<h2><i class="halflings-icon edit"></i><span class="break"></span> Add Cell Information Entry</h2>
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
                                     <asp:Label ID="Label29" runat="server" Text="" ForeColor="#009900"></asp:Label>
                                 </td>
                            </tr>

                            <tr>
                                <td>
                                      <asp:Label ID="Label30" runat="server" Text="" ForeColor="#ff3300"></asp:Label>
                                 </td>
                              </tr>
                        </table>
                        <table>
                            <tr>
                                <td> <asp:Label ID="Label31" runat="server" Text="Add New Cell No:" CssClass="control-label"></asp:Label></td>
                                <td>
                                    <table>
                                        <tr>
                                    <td> <asp:TextBox ID="txtCellTitle" CssClass="input-xlarge focused"  runat="server" ></asp:TextBox></td>
                                    
                                   </tr>
                                  </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <table>
                                        <tr>
                                            <td><asp:Button ID="btnSaveBookCell" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSaveBookCell_Click"/></td>
                                            <td><asp:Button ID="btnCancleBookCell" runat="server" CssClass="btn" Text="Cencel" /></td>
                                
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
