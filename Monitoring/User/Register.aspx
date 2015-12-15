<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="User_Register"  UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        First Name:<br />
        <asp:TextBox ID="FirstNameTextBox" runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="FirstNameRequiredFieldValidator" runat="server" ControlToValidate="FirstNameTextBox" ErrorMessage="Please enter first name." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Last Name:<br />
        <asp:TextBox ID="LastNameTextBox" runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="LastNameRequiredFieldValidator" runat="server" ControlToValidate="LastNameTextBox" ErrorMessage="Please enter last name." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        User Name:<br />
        <asp:TextBox ID="UserNameTextBox" runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" ControlToValidate="UserNameTextBox" ErrorMessage="Please enter user name." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Password:<br />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Width="120px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="Please enter a password." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Email Address:<br />
        <asp:TextBox ID="EmailTextBox" runat="server" Width="160px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Please enter an email address." ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
     <br />
        <asp:Button ID="RegisterButton" runat="server" Text="Register" SkinID="LoginButton" />
        <br />
        <br />
  
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>

</asp:Content>

