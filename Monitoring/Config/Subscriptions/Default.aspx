<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Options_Subscriptions_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

     <h2><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Configs/Default.aspx">Configuration</asp:HyperLink>&gt;Subscriptions</h2>
    <br />

      <table class='StaticTable' style='width: 700px'><thead><tr><th>Subscriptions</th></tr></thead><tr><td>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
         <table>
              <tr>
                  <td style="text-align:center;width:33%;font-size:12px">All Devices</td>
                  <td style="text-align:center;width:33%">
                      <asp:Label ID="UsernameLabel" runat="server" Text="" Visible="false"></asp:Label></td>
                  <td style="text-align:center;width:33%;font-size:12px">My Devices</td>
              </tr>
             <tr>
                 <td style="text-align:center">
                     <asp:ListBox ID="DevicesListBox" runat="server" Width="200px" SelectionMode="Multiple" Height="300px" CssClass="TextBox"></asp:ListBox>
                 </td>
                 <td style="text-align:center">
                     <asp:Button ID="RemoveButton" runat="server" Text="< Remove" CssClass="Button" />&nbsp;<asp:Button ID="AddButton" runat="server" Text="Add >" CssClass="Button" />
                 </td>
                 <td style="text-align:center">
                     <asp:ListBox ID="MyDevicesListBox" runat="server" Width="200px" SelectionMode="Multiple" Height="300px" CssClass="TextBox"></asp:ListBox>
                 </td>
             </tr>
          </table>
              </ContentTemplate>
          </asp:UpdatePanel>  
          

          <br />
          </td></tr></table>

</asp:Content>

