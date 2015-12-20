<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Options_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Options</h2>


    <table style='width: 100%'><tr><td style='vertical-align:top;padding-right:10px'>
   
        <table class='StaticTable' style='width: 100%'><thead><tr><th>User Options</th></tr></thead><tr><td>
            <asp:HyperLink ID="UpdateProfileHyperLink" runat="server" NavigateUrl="~/Options/UpdateProfile.aspx">Update Profile</asp:HyperLink>
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Log Out" /><br />
            
            
            </td></tr></table>

        <asp:Panel ID="AdminPanel" runat="server" Visible="false">
            <br />
            <table  class='StaticTable' style='width: 100%'><thead><tr><th>User Administration Options</th></tr></thead><tr><td>
                <asp:HyperLink ID="ManageUsersHyperLink" runat="server" NavigateUrl="~/Options/Users.aspx">Manage Users</asp:HyperLink>
   </td></tr></table>

        </asp:Panel>



 </td>
        <td style='padding-left:10px;vertical-align:top'>
        <table class='StaticTable' style='width: 100%'><thead><tr><th>Application Options</th></tr></thead><tr><td>
            
            
            
            </td></tr></table>
            </td></tr></table>

</asp:Content>

