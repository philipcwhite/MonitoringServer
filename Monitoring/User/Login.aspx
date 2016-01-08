<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>User&gt;Login</h2>
    <br />
        <table class='StaticTable' style='width: 300px'><thead><tr><th>Login</th></tr></thead><tr><td>
          <table style="width:250px">
              <tr>
                  <td style="width:125px">Username:</td>
                  <td style="width:125px"><asp:TextBox ID="UserNameTextBox" runat="server" Width="120px" CssClass="TextBox"></asp:TextBox></td>
              </tr>
              <tr>
                  <td>Password:</td>
                  <td><asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Width="120px" CssClass="TextBox"></asp:TextBox></td>
              </tr>
              <tr>
                  <td></td>
                  <td style="text-align:right; padding-right:10px"><asp:Button ID="RegisterButton" runat="server" Text="Register" PostBackUrl="~/User/Register.aspx" CssClass="Button" CausesValidation="False" UseSubmitBehavior="False" /> <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="Button" /></td>
              </tr>
          </table>
        <br />
    </td></tr></table>
</asp:Content>

