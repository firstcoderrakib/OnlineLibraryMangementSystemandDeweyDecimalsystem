<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.index" %>

<!DOCTYPE html>
<html lang="en">
<head>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Meta -->
    <!-- start: CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/style-responsive.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext,latin-ext' rel='stylesheet' type='text/css' />
    <!-- end: CSS -->


    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	  	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<link  href="css/ie.css" rel="stylesheet">
	<![endif]-->

    <!--[if IE 9]>
		<link href="css/ie9.css" rel="stylesheet">
	<![endif]-->

    <!-- start: Favicon -->
    <link rel="shortcut icon" href="img/favicon.ico" />
    <!-- end: Favicon -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</head>

<body>
    <form id="form1" runat="server">
        <!-- start: Header -->
        <div class="navbar">
            <div class="navbar-inner">
                <div class="container-fluid">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".top-nav.nav-collapse,.sidebar-nav.nav-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="index.html"><span>DIU Library Management</span></a>

                    <!-- start: Header Menu -->
                    <div class="nav-no-collapse header-nav">
                        <ul class="nav pull-right">
						<li class="dropdown hidden-phone">		
                            <a href="Login.aspx">Login</a>				
						</li>
                            <li class="dropdown hidden-phone">		
                            <a href="Registration.aspx">Registration</a>				
						</li>
						
					</ul>
                    </div>
                    <!-- end: Header Menu -->

                </div>
            </div>
        </div>
        <!-- start: Header -->

        <div class="container-fluid-full">
            <div class="row-fluid">

                <!-- start: Main Menu -->
                <%--<div id="sidebar-left" class="span2">
				<div class="nav-collapse sidebar-nav">
					
				</div>
			</div>--%>
                <!-- end: Main Menu -->



                <!-- start: Content -->
                <div id="content" class="span10">


                    <ul class="breadcrumb">
                        <li>
                            <i class="icon-home"></i>
                            <a href="index.html">DIU</a>
                            <i class="icon-angle-right"></i>
                        </li>
                        <li><a href="#">Library</a></li>
                    </ul>

                    <div class="row-fluid">

                        <div class="span8 widget" ontablet="span7" ondesktop="span8">
                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                           <asp:Literal ID="lt" runat="server"></asp:Literal>
                        <div class="divChild" id="div_Area" style="width:800px; height:400px;"></div>
                        </div>

                      <%--  <div class="sparkLineStats span4 widget green" ontablet="span5" ondesktop="span4">

                            <div class="clearfix">s</div>

                        </div>--%>
                        <!-- End .sparkStats -->

                    </div>

                    <div class="row-fluid">
                        <fieldset>
                            <legend>Search your Book</legend>

                            <div style="width: 100%">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSearch" runat="server" Text=""></asp:TextBox></td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 100%">
                                <asp:GridView ID="gvBookList" AutoGenerateColumns="false" AllowPaging="true" PageSize="20" CssClass="table table-striped table-bordered bootstrap-datatable datatable" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvBookList_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Book ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBid" runat="server" Text='<%#Eval("BookID") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Book Title">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAu" runat="server" Text='<%#Eval("BookTitle") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Author Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("WriterName") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edition">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("EditionTitle") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Published Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("PublishedYear") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("CategoryTitle") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Shelf NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("ShelfTitle") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Cell">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("CellTitle") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Book Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblB" runat="server" Text='<%#Eval("NumberOfBook") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>


                            </div>
                            <!--Contain-->
                        </fieldset>
                        <div class="clearfix"></div>

                    </div>
                    <!--/row-->



                </div>
                <!--/.fluid-container-->

                <!-- end: Content -->
            </div>
            <!--/#content.span10-->
        </div>
        <!--/fluid-row-->

        <div class="modal hide fade" id="myModal">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">×</button>
                <h3>Settings</h3>
            </div>
            <div class="modal-body">
                <p>Here settings can be configured...</p>
            </div>
            <div class="modal-footer">
                <a href="#" class="btn" data-dismiss="modal">Close</a>
                <a href="#" class="btn btn-primary">Save changes</a>
            </div>
        </div>

        <div class="clearfix"></div>

        <footer>

            <p>
                <span style="text-align: left; float: left">&copy; 2016 <a href="http://jiji262.github.io/Bootstrap_Metro_Dashboard/" alt="Bootstrap_Metro_Dashboard">Developed by Rajib</a></span>

            </p>

        </footer>

        <script src="js/jquery-1.9.1.min.js"></script>
        <script src="js/jquery-migrate-1.0.0.min.js"></script>
        <script src="js/jquery-ui-1.10.0.custom.min.js"></script>

        <script src="js/jquery.ui.touch-punch.js"></script>

        <script src="js/modernizr.js"></script>

        <script src="js/bootstrap.min.js"></script>

        <script src="js/jquery.cookie.js"></script>

        <script src='js/fullcalendar.min.js'></script>

        <script src='js/jquery.dataTables.min.js'></script>

        <script src="js/excanvas.js"></script>
        <script src="js/jquery.flot.js"></script>
        <script src="js/jquery.flot.pie.js"></script>
        <script src="js/jquery.flot.stack.js"></script>
        <script src="js/jquery.flot.resize.min.js"></script>

        <script src="js/jquery.chosen.min.js"></script>

        <script src="js/jquery.uniform.min.js"></script>

        <script src="js/jquery.cleditor.min.js"></script>

        <script src="js/jquery.noty.js"></script>

        <script src="js/jquery.elfinder.min.js"></script>

        <script src="js/jquery.raty.min.js"></script>

        <script src="js/jquery.iphone.toggle.js"></script>

        <script src="js/jquery.uploadify-3.1.min.js"></script>

        <script src="js/jquery.gritter.min.js"></script>

        <script src="js/jquery.imagesloaded.js"></script>

        <script src="js/jquery.masonry.min.js"></script>

        <script src="js/jquery.knob.modified.js"></script>

        <script src="js/jquery.sparkline.min.js"></script>

        <script src="js/counter.js"></script>

        <script src="js/retina.js"></script>
        <script src="js/custom.js"></script>
        <!-- end: JavaScript-->
    </form>
</body>
</html>

