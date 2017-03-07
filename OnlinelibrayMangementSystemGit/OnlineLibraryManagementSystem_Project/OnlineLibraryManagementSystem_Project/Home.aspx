<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineLibraryManagementSystem_Project.Home" %>

<%@ Register Src="~/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideManu" runat="server">
    <uc1:Menu runat="server" ID="Menu" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContNav" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainCon" runat="server">
</asp:Content>
