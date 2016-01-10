<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Options_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Configuration</h2>
    <br />
    <table style='width: 100%'><tr><td style='vertical-align:top;padding-right:10px'>
   
        <table class='StaticTable' style='width: 100%'><thead><tr><th>User Options</th></tr></thead><tr><td style="height:80px;vertical-align:top">
            <asp:HyperLink ID="UpdateProfileHyperLink" runat="server" NavigateUrl="~/Config/Users/UpdateProfile.aspx">Update Profile</asp:HyperLink>
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Log Out" /><br />
            
            
            </td></tr></table>

        <asp:Panel ID="AdminPanel1" runat="server" Visible="false">
            <br />
            <table  class='StaticTable' style='width: 100%'><thead><tr><th>User Administration</th></tr></thead><tr><td>
                <asp:HyperLink ID="ManageUsersHyperLink" runat="server" NavigateUrl="~/Config/Users/Default.aspx">Manage Users</asp:HyperLink>
   </td></tr></table>

        </asp:Panel>



 </td>
        <td style='padding-left:10px;vertical-align:top'>
        <table class='StaticTable' style='width: 100%'><thead><tr><th>Application Options</th></tr></thead><tr><td style="height:80px;vertical-align:top">
      
            
            
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Config/Subscriptions/Default.aspx">Subscriptions</asp:HyperLink>
      
            
            
            </td></tr></table>



                    <asp:Panel ID="AdminPanel2" runat="server" Visible="false">
            <br />
            <table  class='StaticTable' style='width: 100%'><thead><tr><th>Application Administration</th></tr></thead><tr><td>
                <asp:HyperLink ID="ThresholdsHyperLink" runat="server" NavigateUrl="~/Config/Thresholds/GlobalThresholds.aspx">Global Thresholds</asp:HyperLink>
   </td></tr></table>

        </asp:Panel>




            </td></tr></table>

</asp:Content>

