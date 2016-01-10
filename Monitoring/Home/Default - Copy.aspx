<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default - Copy.aspx.vb" Inherits="Main_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Home</h2>
    <br />
    <asp:UpdatePanel ID="HomeUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="HomePlaceHolder" runat="server"></asp:PlaceHolder>
            <asp:Timer ID="HomeTimer" runat="server"></asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

