<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="User_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        First Name:<br />
        <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox><br />
        Last Name:<br />
        <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox><br />
        User Name:<br />
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox><br />
        Email Address:<br />
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox><br />
     <br />
        <asp:Button ID="RegisterButton" runat="server" Text="Register" SkinID="LoginButton" />
        <br />
        <br />
  
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>

</asp:Content>

