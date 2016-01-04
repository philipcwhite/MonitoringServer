<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="DeleteConfirm.aspx.vb" Inherits="Options_DeleleConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table style="width:100%;padding-bottom:10px;padding-right:0px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold"><asp:HyperLink ID="OptionsHyperLink" runat="server" NavigateUrl="~/Options/Default.aspx">Options</asp:HyperLink>&gt;Delete Confirm</td>
        <td style="text-align:right"><asp:Button ID="OptionsButton" runat="server" Text="Options" CssClass="Button" PostBackUrl="~/Options/Default.aspx" /></td>
        </tr>
    </table>
  
        <table class='StaticTable' style='width: 100%'><thead><tr><th>Update User</th></tr></thead><tr><td style="text-align:center">
          Confirm delete of <asp:Label ID="UserLabel" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="Button" PostBackUrl="~/Options/" />  <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" CssClass="Button" />
            </td></tr></table>

</asp:Content>

