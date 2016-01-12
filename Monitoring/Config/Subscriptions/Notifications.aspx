<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Notifications.aspx.vb" Inherits="Config_Subscriptions_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Config/Default.aspx">Configuration</asp:HyperLink>&gt;Subscriptions&gt;Manage Notifications</h2>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />

               <asp:Button ID="ManageSubscriptionButton" runat="server" Text="My Devices" CssClass="Button" PostBackUrl="~/Config/Subscriptions/MyDevices.aspx" Width="100px" />&nbsp;<asp:Button ID="ReturnButton" runat="server" Text="Config Home" CssClass="Button" PostBackUrl="~/Config/Default.aspx" Width="100px" />
<br />
    <br />
    <br />
    <br />

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

