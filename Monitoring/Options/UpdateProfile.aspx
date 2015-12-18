<%@ Page Title="" Language="VB" MasterPageFile="~/Options/OptionsMasterPage.master" AutoEventWireup="false" CodeFile="UpdateProfile.aspx.vb" Inherits="Options_UpdateProfile"  UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Update User Account</h2>
    <table>
        <tr>
            <td>User Name:</td>
            <td><asp:Label ID="UserNameLabel" runat="server" Text="UserName"></asp:Label></td>
        </tr>
        <tr>
            <td>Old Password:</td>
            <td><asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox></td>
        </tr>
                <tr>
            <td>New Password:</td>
            <td> <asp:TextBox ID="NewPasswordTextBox" runat="server"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>First Name:</td>
            <td> <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>Last Name:</td>
            <td> <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                    </td>
        </tr>
                <tr>
            <td>Email Address:</td>
            <td> <asp:TextBox ID="EmailAddressTextBox" runat="server"></asp:TextBox>
                    </td>
        
        </tr>
                <tr>
            <td></td>
            <td><asp:Label ID="StatusLabel" runat="server" ForeColor="Red"></asp:Label> </td>
      
        </tr>
        <tr>
           <td>
               <asp:Button ID="ReturnButton" runat="server" Text="Return" SkinID="Button"  /> &nbsp;<asp:Button ID="SubmitButton" runat="server" Text="Submit" SkinID="Button" /></td>
            <td></td>
        
        </tr>
        </table>



    <br />
    
</asp:Content>

