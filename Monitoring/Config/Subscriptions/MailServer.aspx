<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MailServer.aspx.vb" Inherits="Config_Subscriptions_MailServer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;Mail Server</h2>
    <br />
    <table style="width:300px">
       <tr>
            <td>Hostname of Relay Server:</td>
            <td>
                <asp:TextBox ID="HostNameTextBox" runat="server" CssClass="TextBox"></asp:TextBox></td>
        </tr>
         <tr>
            <td>From Email Address:</td>
            <td>
                <asp:TextBox ID="AdminTextBox" runat="server" CssClass="TextBox"></asp:TextBox></td>
        </tr>  
         <tr>
            <td></td>
            <td>
                <asp:Button ID="ReturnButton" runat="server" Text="Return" PostBackUrl="~/Config/Default.aspx"  CssClass="Button"/>   <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="Button" /></td>
        </tr>
    </table>
</asp:Content>

