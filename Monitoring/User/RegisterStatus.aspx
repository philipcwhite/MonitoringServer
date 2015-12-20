<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="RegisterStatus.aspx.vb" Inherits="User_RegisterStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2><asp:HyperLink ID="UserHyperLink" runat="server" NavigateUrl="~/User/Login.aspx">User</asp:HyperLink>&gt;Register Status</h2>
    <table class='StaticTable' style='width: 100%'><thead><tr><th>Update User</th></tr></thead><tr><td style="text-align:center">
          
    Success!  Please wait for an administrator to approve your account.
        <br />

        <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="Button" PostBackUrl="~/User/Login.aspx" />
    </td></tr></table>
</asp:Content>

