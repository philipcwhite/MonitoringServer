<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Options_Subscriptions_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
     <table style="width:100%;padding-bottom:10px;padding-right:0px">
        <tr>
        <td style="text-align:left;vertical-align:top;color:#485385;font-size:10pt;font-weight:bold"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Options/Default.aspx">Options</asp:HyperLink>&gt;Subscriptions</td>
        <td style="text-align:right"><asp:Button ID="OptionsButton" runat="server" Text="Options" CssClass="Button" PostBackUrl="~/Options/Default.aspx" /></td>
        </tr>
    </table>

      <table class='StaticTable' style='width: 100%'><thead><tr><th>Subscriptions</th></tr></thead><tr><td>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
         <table>
              <tr>
                  <td style="text-align:center;width:33%">All Devices</td>
                  <td style="text-align:center;width:33%">
                      <asp:Label ID="UsernameLabel" runat="server" Text="" Visible="false"></asp:Label></td>
                  <td style="text-align:center;width:33%">My Devices</td>
              </tr>
             <tr>
                 <td style="text-align:center">
                     <asp:ListBox ID="DevicesListBox" runat="server" Width="200px" SelectionMode="Multiple" Height="300px"></asp:ListBox>
                 </td>
                 <td style="text-align:center">
                     <asp:Button ID="RemoveButton" runat="server" Text="< Remove" CssClass="Button" />&nbsp;<asp:Button ID="AddButton" runat="server" Text="Add >" CssClass="Button" />
                 </td>
                 <td style="text-align:center">
                     <asp:ListBox ID="MyDevicesListBox" runat="server" Width="200px" SelectionMode="Multiple" Height="300px"></asp:ListBox>
                 </td>
             </tr>
          </table>
              </ContentTemplate>
          </asp:UpdatePanel>  
          

          <br />
          </td></tr></table>

</asp:Content>

