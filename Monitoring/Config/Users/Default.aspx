<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Options_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
        <h2><asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;Users</h2>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="UsersPlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="UsersTimer" runat="server"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    
</asp:Content>

