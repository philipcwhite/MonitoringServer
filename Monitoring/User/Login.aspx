<%@ Page Title="" Language="VB" MasterPageFile="~/User/MasterPage.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
        User Name:<br />
        <asp:TextBox ID="UserNameTextBox" runat="server" Width="120px"></asp:TextBox><br />
        Password:<br />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" Width="120px"></asp:TextBox>
            <br />
            <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" SkinID="LoginButton" />
            <br />
            <br />
            Not a User?<br />
            <br />
            <asp:Button ID="RegisterButton" runat="server" Text="Register" SkinID="LoginButton" PostBackUrl="~/User/Register.aspx" />
            <br />
    </div>
</asp:Content>

