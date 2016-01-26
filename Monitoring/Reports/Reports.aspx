<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Reports.aspx.vb" Inherits="Reports_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Reports/Default.aspx">Reports</asp:HyperLink>&gt;<asp:Label ID="ReportLabel" runat="server"></asp:Label></h2>
    <br />
    <asp:PlaceHolder ID="ReportPlaceHolder" runat="server"></asp:PlaceHolder>
</asp:Content>

