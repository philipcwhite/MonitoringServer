<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="User_Register"  UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <h2><asp:HyperLink ID="UserHyperLink" runat="server" NavigateUrl="~/User/Login.aspx">User</asp:HyperLink>&gt;Register</h2>
    <br />
        <table class='StaticTable' style='width: 500px'><thead><tr><th>Register</th></tr></thead><tr><td>
         <table>
             <tr><td style="width:110px">First Name:</td><td style="width:170px"><asp:TextBox ID="FirstNameTextBox" runat="server" Width="120px" CssClass="TextBox"></asp:TextBox></td><td style="width:210px"><asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ControlToValidate="FirstNameTextBox" ErrorMessage="Please enter first name." ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
             <tr><td>Last Name:</td><td><asp:TextBox ID="LastNameTextBox" runat="server" Width="120px" CssClass="TextBox"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="Please enter last name." ForeColor="Red"></asp:RequiredFieldValidator></td></tr>
             <tr><td>User Name:</td><td>
        <asp:TextBox ID="UserNameTextBox" runat="server" Width="120px" CssClass="TextBox"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" ControlToValidate="UserNameTextBox" ErrorMessage="Please enter user name." ForeColor="Red"></asp:RequiredFieldValidator>
                 </td></tr>
             <tr><td>Password:</td><td>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Width="120px" CssClass="TextBox"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="Please enter a password." ForeColor="Red"></asp:RequiredFieldValidator>
                 </td></tr>
             <tr><td>Email Address:</td><td>
        <asp:TextBox ID="EmailTextBox" runat="server" Width="160px" CssClass="TextBox"></asp:TextBox></td><td><asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Please enter an email address." ForeColor="Red"></asp:RequiredFieldValidator>
                 </td></tr>
             <tr><td></td><td><asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="Button" /></td><td></td></tr>
             <tr><td colspan="3"><asp:Label ID="ResultLabel" runat="server"></asp:Label></td></tr>


         </table>

  
        
            </td></tr></table>
</asp:Content>

