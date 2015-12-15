<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Options_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>User Options</h2>


    <table style='width: 100%'><tr><td style='padding:10px;vertical-align:top'>
   
        <table class='DeviceTable' style='width: 100%'><thead><tr><th>User Options</th></tr></thead><tr><td>
            Update Profile<br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Log Out" /><br />
            

            </td></tr></table>

 </td>
        <td style='padding:10px;vertical-align:top'>
        <table class='DeviceTable' style='width: 100%'><thead><tr><th>Application Options</th></tr></thead><tr><td>
            
            
            
            </td></tr></table>
            </td></tr></table>

</asp:Content>

