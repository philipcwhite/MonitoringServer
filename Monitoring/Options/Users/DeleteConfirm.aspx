<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="DeleteConfirm.aspx.vb" Inherits="Options_DeleleConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2>
        <asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Options/Default.aspx">Options</asp:HyperLink>&gt;<asp:HyperLink ID="UsersHyperLink" runat="server" NavigateUrl="~/Options/Users/">Users</asp:HyperLink>&gt;Delete User</h2>
    
  
        <table class='StaticTable' style='width: 100%'><thead><tr><th>Update User</th></tr></thead><tr><td style="text-align:center">
          Confirm delete of <asp:Label ID="UserLabel" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button" PostBackUrl="~/Options/" />  <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" CssClass="Button" />
            </td></tr></table>

</asp:Content>

