<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="User_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginName ID="LoginName1" runat="server" /><br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" /><br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

