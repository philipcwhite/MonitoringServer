<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Services.aspx.vb" Inherits="Devices_Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <h2><asp:HyperLink ID="DevicesHyperLink" runat="server" NavigateUrl="~/Devices/Default.aspx">Devices</asp:HyperLink>&gt;<asp:HyperLink ID="HNHyperLink" runat="server"><asp:Label ID="HostNameLabel" runat="server" Text="Device"></asp:Label></asp:HyperLink>&gt;Services</h2>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server"></asp:Timer>
            <asp:PlaceHolder ID="ServicePlaceHolder" runat="server"></asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="float:right;padding-right:5px"><br />
    <asp:Button ID="ReturnButton" runat="server" Text="Return" Width="100" CssClass="Button" />
        <br />
        <br />
        <br />
        <br />
        <br />
</div>
</asp:Content>

