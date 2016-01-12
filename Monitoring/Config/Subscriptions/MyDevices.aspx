<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MyDevices.aspx.vb" Inherits="Options_Subscriptions_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 

     <h2><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;Subscriptions&gt;My Devices</h2>
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
                     <asp:Button ID="RemoveButton" runat="server" Text="< Remove" CssClass="Button" Width="90px" />&nbsp;<asp:Button ID="AddButton" runat="server" Text="Add >" CssClass="Button" Width="90px" />
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
    <br />
                   <asp:Button ID="ManageSubscriptionButton" runat="server" Text="Notifications" CssClass="Button" PostBackUrl="~/Config/Subscriptions/Notifications.aspx" Width="100px" />&nbsp;<asp:Button ID="ReturnButton" runat="server" Text="Config Home" CssClass="Button" PostBackUrl="~/Config/Default.aspx" Width="100px" />
<br />
    <br />
    <br />
    <br />
</asp:Content>

